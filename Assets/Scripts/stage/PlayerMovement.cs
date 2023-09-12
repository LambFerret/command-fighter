using System;
using UnityEngine;

namespace stage
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 1.0f;
        public Transform groundCheck;
        public LayerMask groundLayer;

        private LineRenderer _rightArm;
        private LineRenderer _leftArm;

        private float _horizontal;
        private float _speed = 10f;
        private float _jumpForce = 10f;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rightArm = GameObject.Find("RightArm").GetComponent<LineRenderer>();
            _leftArm = GameObject.Find("LeftArm").GetComponent<LineRenderer>();
            _rb = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            _rightArm.SetPosition(0, _rightArm.gameObject.transform.position);
            _leftArm.SetPosition(0, _leftArm.gameObject.transform.position);
            _rightArm.SetPosition(1, transform.position);
            _leftArm.SetPosition(1, transform.position);
            if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                _horizontal = -1f; // Move left
            }
            else if (Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftShift))
            {
                _horizontal = 1f; // Move right
            }
            else
            {
                _horizontal = 0; // Don't move horizontally
            }

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            }

            if (Input.GetKeyUp(KeyCode.Space) && _rb.velocity.y > 0)
            {
                _rb.velocity *= new Vector2(1, 0.5f);
            }
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }


    }
}