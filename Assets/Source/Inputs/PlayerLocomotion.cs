using UnityEngine;

namespace Source.Inputs
{
    public class PlayerLocomotion : MonoBehaviour
    {
        private InputManager inputManager;
        
        Vector3 moveDirection;
        Rigidbody playerRigidbody;

        [Header("Camera Transform")] 
        public Transform playerCamera;

        [Header("Movement Speed")]
        public float movementSpeed;
        
        [Header ("Rotation Speed")]
        public float rotationSpeed;

        [Header("Rotation Variables")]
        private Quaternion targetRotation;
        private Quaternion playerRotation;
        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            playerRigidbody = GetComponent<Rigidbody>();
        }

        public void HandleAllMovement()
        {
            HandleMovement();
            HandleRotation();
        }
        
        private void HandleMovement()
        {
            moveDirection = playerCamera.forward * inputManager.verticalMovementInput;
            moveDirection = moveDirection + playerCamera.right * inputManager.horizontalMovementInput;
            moveDirection.Normalize();
            moveDirection.y = 0;
            moveDirection = moveDirection * movementSpeed;

            Vector3 movementVelocity = moveDirection;
            playerRigidbody.velocity = movementVelocity;
        }

        private void HandleRotation()
        {
            targetRotation = Quaternion.Euler(0, playerCamera.eulerAngles.y, 0);
            playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (inputManager.verticalMovementInput != 0 || inputManager.horizontalMovementInput !=0)
            {
                transform.rotation = playerRotation;
            }
        }
    }
}
