using UnityEngine;

namespace Source.Player
{
    public class PlayerRotation : MonoBehaviour
   {
    public float speed;
   // public new Camera camera;

        void Update()
        {
            Look();
        }

    void Look()
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Plane playerPlane = new Plane(Vector3.up, transform.position);
                //Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                float hitdist;

               // if (playerPlane.Raycast(ray, out hitdist))
                {
                   // Vector3 targetPoint = ray.GetPoint(hitdist);
                   //  Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                   // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
                }
            }
        }
   }
}