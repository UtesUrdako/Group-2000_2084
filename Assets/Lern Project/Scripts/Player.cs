using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Player : MonoBehaviour
    {
        public KeyCode keySpell1;
        
        public GameObject shieldPrefab;
        public Transform spawnPosition;

        private bool _isSpawnShield;
        [HideInInspector] public int level = 1;

        private Vector3 _direction;
        public float speed = 2f;
        public float speedRotate = 20f;
        private bool _isSprint;
        
        void Start()
        {
            var point1 = new Vector3(1f, 5f, 1462f);
            var point2 = new Vector3(16f, 5f, 142f);
            
            var dist = Vector3.Distance(point1, point2);
            Debug.Log(dist);
            Debug.Log(Vector3.one.magnitude);
        }

        void Update()
        {
            if (Input.GetKeyDown(keySpell1))
                _isSpawnShield = true;
            
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");

            _isSprint = Input.GetButton("Sprint");
        }

        private void FixedUpdate()
        {
            if (_isSpawnShield)
            {
                _isSpawnShield = false;
                SpawnShield();
            }
            
            Move(Time.fixedDeltaTime);

            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0));
        }

        private void SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, spawnPosition.position, spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Shield>();
            shield.Init(10 * level);
            
            shield.transform.SetParent(spawnPosition);
        }

        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * (_isSprint ? speed * 2 : speed) * delta;



            var parent = transform.parent;
        }
    }
}
