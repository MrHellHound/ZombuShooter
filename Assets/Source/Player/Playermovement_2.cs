
using UnityEngine;

namespace Source.Player
{
    public class Playermovement_2 : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float speed;
        public Camera camera;

        void Update()
        {
            Look();
            Move();
        }

        void Look()
        {
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            float hitdist;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            }
        }

        void Move()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
}
