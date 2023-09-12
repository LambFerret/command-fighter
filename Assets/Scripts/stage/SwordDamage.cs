using System;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace stage
{
    public class SwordDamage : MonoBehaviour
    {
        public int powerThreshold = 1;
        private Vector3 _lastPosition;
        private float _speed;

        private void Start()
        {
            _lastPosition = transform.position;
        }

        private void Update()
        {
            var position = transform.position;
            _speed = Vector3.Distance(position, _lastPosition) / Time.deltaTime;
            _lastPosition = position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var p = other.GetComponent<EnemyMovement>();
            if (p == null) return;
            var power = (int)Math.Floor(_speed);
            if (power < powerThreshold) return;
            Debug.Log(power);
            Destroy(other.gameObject);
            // var ev = Schedule<PlayerKillEnemy>();
            // ev.damage = power;
        }
    }
}