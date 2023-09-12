using System;
using UnityEngine;

namespace stage
{
    public class ArmMovement : MonoBehaviour
    {
        public Transform objectA;
        public Transform centerPosition;
        public float maxDistance = 5.0f;
        public float minDistance = 1.0f;

        public KeyCode moveLeftKey = KeyCode.A;
        public KeyCode moveRightKey = KeyCode.D;
        public KeyCode moveInKey = KeyCode.W;
        public KeyCode moveOutKey = KeyCode.S;

        public float speed = 0.1f;

        private float angle = 0f; // in radians
        private float radius = 1f;

        public float maxRadian = Mathf.PI; // default 180 degrees
        public float minRadian = 0f; // default 0 degrees

        private void Update()
        {
            // Update the angle based on user input.
            if (Input.GetKey(moveLeftKey)) angle -= speed;
            if (Input.GetKey(moveRightKey)) angle += speed;

            // Update the radius based on user input.
            if (Input.GetKey(moveInKey)) radius -= speed;
            if (Input.GetKey(moveOutKey)) radius += speed;

            // Clamp the angle and radius to the specified bounds.
            angle = Mathf.Clamp(angle, minRadian, maxRadian);
            radius = Mathf.Clamp(radius, minDistance, maxDistance);

            // Calculate the x and y position based on polar coordinates.
            float x = centerPosition.position.x + radius * Mathf.Cos(angle);
            float y = centerPosition.position.y + radius * Mathf.Sin(angle);

            objectA.position = new Vector3(x, y, objectA.position.z);
        }
    }
}