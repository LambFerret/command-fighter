using System;
using System.Collections;
using events;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace stage
{
    public class SwordDamage : MonoBehaviour
    {
        public int powerThreshold = 1;
        private Vector3 lastPosition;
        private float speed;

        private void Start()
        {
            lastPosition = transform.position;
        }

        private void Update()
        {
            // Calculate speed as distance over time
            speed = Vector3.Distance(transform.position, lastPosition) / Time.deltaTime;

            // Store the current position for the next frame
            lastPosition = transform.position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var p = other.GetComponent<EnemyMovement>();
            if (p == null) return;
            var power  = (int) Math.Floor(speed);
            if (power < powerThreshold) return;
            Debug.Log(power);
            Destroy(other.gameObject);
            // var ev = Schedule<PlayerKillEnemy>();
            // ev.damage = power;
        }
    }
}