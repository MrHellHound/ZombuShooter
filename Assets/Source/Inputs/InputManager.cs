using Source.Player;
using UnityEngine;
namespace Source.Inputs
{
    public class InputManager : MonoBehaviour
    {
        PlayerControls playerControls;
        AnimatorManager animatorManager;

        [Header("Player Movement")]
        public float verticalMovementInput;
        public float horizontalMovementInput;
        public Vector2 movementInput;
        
        [Header("Camera Rotation")]
        public float verticalCameraInput;
        public float horizontalCameraInput;
        public Vector2 cameraInput;

        private void Awake()
        {
            animatorManager = GetComponent<AnimatorManager>();
        }

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();

                playerControls.PlayerInputs.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
                playerControls.PlayerInputs.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            }
            
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        public void HandleAllInputs()
        {
            HandleMovementInput();
            HandleCameraInput();
        }
        
        private void HandleMovementInput()
        {
            horizontalMovementInput = movementInput.x;
            verticalMovementInput = movementInput.y;
            animatorManager.HandleAnimatorValues(horizontalMovementInput, verticalMovementInput);
        }

        private void HandleCameraInput()
        {
            horizontalCameraInput = cameraInput.x;
            verticalCameraInput = cameraInput.y;
        }
    }
}
