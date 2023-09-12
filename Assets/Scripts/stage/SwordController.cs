using UnityEngine;

namespace stage
{
    public class SwordController : MonoBehaviour
    {
        public GameObject leftHand;
        public GameObject rightHand;

        void Update()
        {
            // Calculate midpoint between the two hands
            Vector3 midpoint = (leftHand.transform.position + rightHand.transform.position) / 2;

            // Move the sword to the midpoint
            transform.position = midpoint;

            // Calculate the direction between the two hands
            Vector3 direction = rightHand.transform.position - leftHand.transform.position;

            // Calculate the angle between the two hands
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate the sword to this angle
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Optionally, adjust the holding anchors here if necessary
        }
    }
}