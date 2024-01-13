using UnityEngine;

namespace Source.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float sightSpeed = 2f;
        public bool isSighting;

        public Rigidbody rb;

        private void Start()
        {
            isSighting = false;
        }

        void Update()
        {
            Move();
        }
        void Move()
        {
            
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
                rb.AddForce(movement * sightSpeed);
                isSighting = true;
            }
            else
            {
                Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
                rb.AddForce(movement * moveSpeed);
                isSighting = false;
            }
        }
    }
}
