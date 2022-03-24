using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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

        private NavMeshAgent _agent;

        void Awake()
        {
            _player = FindObjectOfType<Player>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            //_agent.SetDestination(_player.transform.position);
        }

        private void Update()
        {
            //Ray ray = new Ray(_spawnPosition.position, transform.forward);
            //Debug.DrawRay(_spawnPosition.position, transform.forward * 6, Color.blue);
            //if (Physics.Raycast(ray, out RaycastHit hit, 6))
            //{
            //    Debug.DrawRay(_spawnPosition.position, transform.forward * hit.distance, Color.blue);
            //    Debug.DrawRay(hit.point, hit.normal, Color.magenta);
                
            //    if (hit.collider.CompareTag("Player"))
            //    {
            //        if (_isFire)
            //            Fire();
            //    }
            //}
            
            if (NavMesh.SamplePosition(_agent.transform.position, out NavMeshHit navMeshHit, 0.2f, NavMesh.AllAreas))
                print(NavMesh.GetAreaCost((int)Mathf.Log(navMeshHit.mask, 2)));
        }
        //000001000
        private void Fire()
        {
            _isFire = false;
            var shieldObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Bullet>();
            shield.Init(_player.transform,10, 0.6f);
            Invoke(nameof(Reloading), _cooldown);
        }

        private void Reloading()
        {
            _isFire = true;
        }
    }
}
