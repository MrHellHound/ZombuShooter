using Source.Inputs;
using UnityEngine;

namespace Source.CameraScripts
{
    public class PlayerCamera : MonoBehaviour
    {
        public InputManager inputManager;
        
        [SerializeField] private Transform cameraPivot;
        [SerializeField] private Camera cameraObject;
        [SerializeField] private GameObject player;

        Vector3 cameraFollowVelocity;
        Vector3 targetPosition;
        Vector3 cameraRotation;
        Quaternion targetRotation;
        
        [Header("Camera Speeds")]
        [SerializeField] private float sensitivity = 1.0f;
        [SerializeField] private float cameraSmoothTime = 0.2f;
        
        float lookAmountVertical;
        float lookAmountHorizontal;
        float maximumPivotAngle = 15;
        float minimumPivotAngle = -15;

        public void HandleAllCameraMovement()
        {
            FollowPlayer();
            RotateCamera();
        }

        private void FollowPlayer()
        {
            targetPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraFollowVelocity, cameraSmoothTime * Time.deltaTime);
            transform.position = targetPosition;
        }

        private void RotateCamera()
        {
            lookAmountVertical += inputManager.horizontalCameraInput * sensitivity;
            lookAmountHorizontal += inputManager.verticalCameraInput * sensitivity;
            lookAmountHorizontal = Mathf.Clamp(lookAmountHorizontal, minimumPivotAngle, maximumPivotAngle);

            cameraRotation = Vector3.zero;
            cameraRotation.y = lookAmountVertical;
            targetRotation = Quaternion.Euler(cameraRotation);
            targetRotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraSmoothTime);
            transform.rotation = targetRotation;
    
            cameraRotation = Vector3.zero;
            cameraRotation.x = lookAmountHorizontal;
            targetRotation = Quaternion.Euler(cameraRotation);
            targetRotation = Quaternion.Slerp(cameraPivot.localRotation, targetRotation, cameraSmoothTime);
            cameraPivot.localRotation = targetRotation;
        }
    }
}
