using UnityEngine;

namespace Source.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Tooltip("Скорость персонажа")]
        public float speed;
        [Tooltip("Скорость поворота")]
        public float rotationSpeed;

        public float offset;
        
        void Update()
        {
            Movement();
            Rotation();
        }

        private void Movement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
            Vector3 movement = new Vector3(-verticalInput, 0, horizontalInput).normalized;
            
            transform.Translate(movement * speed * Time.deltaTime);
            
            transform.position = new Vector3(transform.position.x, 1.1f, transform.position.z);
        }

        private void Rotation()
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = Camera.main.transform.position.y;
                Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);

           
                Vector3 lookDirection = targetPosition - transform.position;
                lookDirection.y = 0;

                Quaternion rotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
