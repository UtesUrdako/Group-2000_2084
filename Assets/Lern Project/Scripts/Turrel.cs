using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LernProject
{
    public class Turrel : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _speedRotate;

        void Start()
        {
            _player = FindObjectOfType<Player>();

        }

        void FixedUpdate()
        {
            var direction =
                _player.transform.position - transform.position;

            var pr = Vector3.Dot(
                transform.forward,
                direction);
            var abs = Mathf.Abs(pr);
            var rad = Mathf.Sin(abs);
            var deg = rad * Mathf.Rad2Deg;

            if (deg <= 45f)
            {
                Debug.Log("I see you");
            }
            
            direction.Set(direction.x, 0, direction.z);
            var stepRotate = Vector3.RotateTowards(transform.forward,
                    direction,
                    _speedRotate * Time.fixedDeltaTime,
                    0f);
            
            transform.rotation = Quaternion.LookRotation(stepRotate);
        }
    }
}