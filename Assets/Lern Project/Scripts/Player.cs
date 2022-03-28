using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Player : MonoBehaviour
    {
        public KeyCode keySpell1;
        public KeyCode keySpell2;
        
        public GameObject shieldPrefab;
        public GameObject bulletPrefab;
        public Transform spawnPosition;
        public Transform spawnBulletPosition;
        [SerializeField] private Animator _anim;

        private bool _isSpawnShield;
        private bool _isFire;

        [SerializeField] private float _cooldownTime1;
        [SerializeField] private float _cooldownTime2;
        [SerializeField] private bool _cooldown1;
        [SerializeField] private bool _cooldown2;
        [HideInInspector] public int level = 1;

        private Vector3 _direction;
        public float speed = 2f;
        public float speedRotate = 20f;
        private bool _isSprint;
        [SerializeField] private float _jumpForce = 10f;

        private ShieldGenerator _shieldGenerator;
        private Gun _gun;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _gun = new Gun(bulletPrefab, spawnPosition);
            _shieldGenerator = new ShieldGenerator(10, shieldPrefab, spawnPosition);
        }

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
            if (Input.GetKeyDown(keySpell1) && _cooldown1)
                _isSpawnShield = true;
            if (Input.GetKeyDown(keySpell2) && _cooldown2)
                _isFire = true;
            
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");

            _isSprint = Input.GetButton("Sprint");

            _anim.SetBool("IsWalking", _direction != Vector3.zero);
            
            if (Input.GetKeyDown(KeyCode.Space))
                GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        private void FixedUpdate()
        {
            if (_isSpawnShield)
            {
                _isSpawnShield = false;
                _cooldown1 = false;
                StartCoroutine(Cooldown1(_cooldownTime1, 1));
                _shieldGenerator.Spawn();
            }

            if (_isFire)
            {
                _isFire = false;
                _cooldown2 = false;
                StartCoroutine(Cooldown1(_cooldownTime2, 2));
                _gun.Spawn();
            }
            
            Move(Time.fixedDeltaTime);
        }

        private IEnumerator Cooldown1(float time, int numSpell)
        {
            yield return new WaitForSeconds(time);
            switch (numSpell)
            {
                case 1:
                    _cooldown1 = true;
                    break;
                case 2:
                    _cooldown2 = true;
                    break;
            }
        }

        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * (_isSprint ? speed * 2 : speed) * delta;
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0));
        }
    }
}
