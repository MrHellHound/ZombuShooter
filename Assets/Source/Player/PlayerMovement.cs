using UnityEngine;

namespace Source.Player
{
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private Transform _model;
        [SerializeField] private float _speed = 5;
        [SerializeField] private float _turnSpeed = 360;
        private Vector3 _input;
        public Camera camera;
        private void Update() {
            GatherInput();
            Look();
            Move();
        }

        private void GatherInput() {
            
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10;
                Vector3 targetPosition = camera.ScreenToWorldPoint(mousePosition);
                _input = (targetPosition - transform.position).normalized;
                _input.y = 0;
            }
            else
            {
                _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            }
        }

        private void Look() {
            if (_input == Vector3.zero) return;
            
                Quaternion rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
                _model.rotation = Quaternion.RotateTowards(_model.rotation, rot, _turnSpeed * Time.deltaTime);
        }

        private void Move() {
            //if (!Input.GetKey(KeyCode.Mouse1))
            //{
                _rigidBody.MovePosition(transform.position + _input.ToIso() * _input.normalized.magnitude * _speed * Time.deltaTime);
            //}
        }
    }

    public static class Helpers 
    {
        private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
    }
}