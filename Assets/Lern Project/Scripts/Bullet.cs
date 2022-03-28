using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage = 3;
        [SerializeField] private float _force = 3;
        private float _speed;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(float lifeTime, float speed)
        {
            _speed = speed;
            Destroy(gameObject, lifeTime);
            
            _rigidbody.AddForce(transform.forward * _force);
        }
    
        // void FixedUpdate()
        // {
        //     //transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
        //     //transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        // }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
            {
                Debug.Log("Hit!");
                takeDamage.Hit(_damage);
            }
        }
    }
}