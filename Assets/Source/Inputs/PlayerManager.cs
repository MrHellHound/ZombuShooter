using Source.CameraScripts;
using UnityEngine;

namespace Source.Inputs
{
    public class PlayerManager : MonoBehaviour
    {
        InputManager inputManager;
        PlayerLocomotion playerLocomotion;
        PlayerCamera playerCamera;
        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
            playerCamera = FindObjectOfType<PlayerCamera>();
        }

        private void Update()
        {
            inputManager.HandleAllInputs();
        }

        private void FixedUpdate()
        {
            playerLocomotion.HandleAllMovement();
        }

        private void LateUpdate()
        {
            playerCamera.HandleAllCameraMovement();
        }
    }
}
