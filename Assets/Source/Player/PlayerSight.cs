using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Player
{
   public class PlayerSight : MonoBehaviour
   {
      [SerializeField] private Camera cam;
      [SerializeField] private PlayerStates playerStates;
      private bool _isSighting;
      private PlayerControls _playerControls;
      
      private void Awake()
      {
         _playerControls = new PlayerControls();
      }

      private void OnEnable()
      {
         _playerControls.Enable();
         _playerControls.PlayerInputs.Sight.started += OnSight;
         _playerControls.PlayerInputs.Sight.canceled += OffSight;
      }

      private void OnDisable()
      {
         _playerControls.Disable();
         _playerControls.PlayerInputs.Sight.started -= OnSight;
         _playerControls.PlayerInputs.Sight.canceled -= OffSight;
      }
      
      private void OnSight(InputAction.CallbackContext context)
      {
         cam.fieldOfView = 40;
         playerStates.IsSighting = true;
      }
      
      private void OffSight(InputAction.CallbackContext context)
      {
         cam.fieldOfView = 60;
         playerStates.IsSighting = false;
      }
   }
}
