using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Test : MonoBehaviour
{
//     private float health = 100f;
//     public GameObject prefabAsteroid;
//     public float radiusArea;
//     
//     // Start is called before the first frame update
//     void Start()
//     {
//         var show = new Show(2);
//         show.ShowTime();
//     }
//
//     private void Update()
//     {
//         health -= Time.deltaTime;
// //0.000000000000000000000000000000000000000001
//         if (Mathf.Approximately(health, 0))
//         {
//             Debug.Log("Health = 0");
//             enabled = false;
//         }
//
//         int[] values = new int[8]; // 0 1 2 3 4 5
//         var value = values[Random.Range(0, values.Length)];
//
//         Vector3 point = Random.insideUnitSphere;
//
//         Instantiate(prefabAsteroid, transform.position + point * radiusArea, Random.rotation);
//     }
    
    //[SerializeField] private Player _player;
    public GameObject enemyPrefab;
    public Transform spawnPosition;
    public float spawnTime = 10;
    public float t = 0;
    public int count = 5;

    void Start()
    {
        //_player = FindObjectOfType<Player>();
    }

    void Update()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        t = t + Time.deltaTime;
        if ((t >= spawnTime) && (count > 0))
        {
            var enemyObj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            t = 0;
            count--;
        }
    }
}


public class Show
{
    private float _time;
    public Show(float time)
    {
        _time = time;
    }

    public void ShowTime()
    {
        Debug.Log($"Show time {_time}!");
    }
}