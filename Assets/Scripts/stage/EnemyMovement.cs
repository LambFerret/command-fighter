using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stage
{
    public class EnemyMovement : MonoBehaviour
    {
        public float speed = 1f;
        public float reviveTime = 5f;
        private Vector2 _direction = Vector2.left;
        private Vector2 _movement;
        private Transform _initialTransform;
        private GameObject _parent;

        public float detectionRange = 5.0f;
        public LayerMask groundLayer;
        public Transform groundCheck;
        public float groundCheckDistance = 0.5f;

        private Rigidbody2D _rb;
        private bool facingRight = true;
        private bool playerInSight = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnDrawGizmos()
        { Vector2 groundCheckPos = facingRight
                ? groundCheck.position
                : new Vector2(groundCheck.position.x - groundCheckDistance * 2, groundCheck.position.y);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheckPos, groundCheckDistance);
        }

        private void Update()
        {
            // Check if ground in front is ending
            Vector2 groundCheckPos = facingRight
                ? groundCheck.position
                : new Vector2(groundCheck.position.x - groundCheckDistance * 2, groundCheck.position.y);
            if (!Physics2D.OverlapCircle(groundCheckPos, groundCheckDistance, groundLayer))
            {
                TurnAround();
            }

            // Check if the player is in front within a certain distance
            RaycastHit2D hit = Physics2D.Raycast(transform.position, facingRight ? Vector2.right : Vector2.left,
                detectionRange, LayerMask.GetMask("Player"));
            if (hit.collider is not null && hit.collider.CompareTag("Player"))
            {
                if (!playerInSight)
                {
                    StartCoroutine(ChasePlayer());
                }
            }
            else
            {
                playerInSight = false;
            }

            // Move
            if (!playerInSight)
            {
                float moveDirection = facingRight ? 1f : -1f;
                _rb.velocity = new Vector2(speed * moveDirection, _rb.velocity.y);
            }
        }

        private void TurnAround()
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180f, 0);
        }

        private IEnumerator ChasePlayer()
        {
            playerInSight = true;

            yield return new WaitForSeconds(1f);

            float moveDirection = facingRight ? 1f : -1f;
            _rb.velocity = new Vector2(speed * 2 * moveDirection, _rb.velocity.y);
        }

        private void Start()
        {
            _initialTransform = transform;
            _parent = transform.parent.gameObject;
        }

        private void OnDestroy()
        {
            StartCoroutine(Revive());
        }

        private IEnumerator Revive()
        {
            yield return new WaitForSeconds(reviveTime);
            Instantiate(gameObject, _initialTransform.position, Quaternion.identity, _parent.transform);
        }
    }
}