using Source.Properties;
using UnityEngine;

namespace Source.Player
{
    public class CharacterMovement : MonoBehaviour
    {
        private Animator anim;
        public float force;
        public CharacterController controller;
        public float smoothTime;
        float _smoothVelocity;



        public void MoveUpdate()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref _smoothVelocity, smoothTime);
                transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
                Vector3 move = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;
                
                controller.Move(move.normalized *force*Time.deltaTime);
            }
            
        }
    }
}
