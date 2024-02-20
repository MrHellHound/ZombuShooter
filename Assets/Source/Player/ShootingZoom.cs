using Invector.vCharacterController;
using UnityEngine;

namespace Source.Player
{
    public class ShootingZoom : MonoBehaviour
    {
        [SerializeField] public vThirdPersonController vThirdPersonController;
        [SerializeField] public vThirdPersonCamera vThirdPersonCamera;
        [SerializeField] private float transitionSpeed = 2f;
        
        private float _targetRightOffset;
        private float _targetDefaultDistance;
        private float _targetHeight;

        private void Update()
        {
            if (vThirdPersonController.isStrafing)
            {
                _targetRightOffset = 0.4f;
                _targetDefaultDistance = 1.2f;
                _targetHeight = 1.75f;
            }
            else
            {
                _targetRightOffset = 0.15f;
                _targetDefaultDistance = 1.5f;
                _targetHeight = 1.4f;
            }
            
            vThirdPersonCamera.rightOffset = Mathf.Lerp(vThirdPersonCamera.rightOffset, _targetRightOffset, Time.deltaTime * transitionSpeed);
            vThirdPersonCamera.defaultDistance = Mathf.Lerp(vThirdPersonCamera.defaultDistance, _targetDefaultDistance, Time.deltaTime * transitionSpeed);
            vThirdPersonCamera.height = Mathf.Lerp(vThirdPersonCamera.height, _targetHeight, Time.deltaTime * transitionSpeed);
        }
    }
}