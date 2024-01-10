using UnityEngine;

namespace Source.Player
{
    public class Playermovement_2 : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float sightSpeed = 2f;
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
                Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * sightSpeed * Time.deltaTime;
                transform.Translate(movement);
            }
            else
            {
                Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
                transform.Translate(movement);
            }
        }
    }
}
