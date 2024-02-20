using UnityEngine;

namespace Source.Guns
{
    public class GunRotation : MonoBehaviour
    {
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (mainCamera != null)
            {
                Vector3 directionToCamera = mainCamera.transform.position - transform.position;
                
                Quaternion rotationToCamera = Quaternion.LookRotation(-directionToCamera, Vector3.up);
                
                transform.rotation = rotationToCamera;
            }
        }
    }
}
