using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LernProject
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _cooldown;
        [SerializeField] private bool _isFire;

        [SerializeField] private UnityEvent _event;

        void Start()
        {
            _player = FindObjectOfType<Player>();

        }

        private void Update()
        {
            Ray ray = new Ray(_spawnPosition.position, transform.forward);
            //Debug.DrawRay(_spawnPosition.position, transform.forward * 6, Color.blue);
            if (Physics.Raycast(ray, out RaycastHit hit, 6))
            {
                Debug.DrawRay(_spawnPosition.position, transform.forward * hit.distance, Color.blue);
                Debug.DrawRay(hit.point, hit.normal, Color.magenta);
                
                if (hit.collider.CompareTag("Player"))
                {
                    if (_isFire)
                        Fire();
                }
            }
        }

        private void Fire()
        {
            _isFire = false;
            var shieldObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Bullet>();
            shield.Init(_player.transform,10, 0.6f);
            _event?.Invoke();
            Invoke(nameof(Reloading), _cooldown);
        }

        private void Reloading()
        {
            _isFire = true;
        }
    }
}
