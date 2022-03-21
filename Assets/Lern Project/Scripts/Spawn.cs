using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    //[SerializeField] private Transform[] _spawnPoints;
    private List<Transform> _enemies;

    [SerializeField] private float _timeCuldown;

    private void Awake()
    {
        _enemies = new List<Transform>();
    }

    void Start()
    {
        StartCoroutine(Spawner(5));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StopCoroutine(nameof(Spawner));
        }
    }

    private IEnumerator Spawner(int count)
    {
        while (true)
        {
            for (int i = 0; i < 10000; i++)
            {
                //_enemies.Add(Instantiate(_enemyPrefab, transform.position, Quaternion.identity));
                _enemies.Add((new GameObject()).GetComponent<Transform>());
                yield return new WaitForSeconds(_timeCuldown);

                if (i == 3)
                    yield break;
            }

            yield return new WaitForSeconds(10f);

            foreach (var enemy in _enemies)
            {
                enemy.Rotate(Vector3.up, Time.deltaTime);
                Destroy(enemy.gameObject);
                yield return new WaitForSeconds(_timeCuldown);
            }

            _enemies.Clear();
        }

    }
}
