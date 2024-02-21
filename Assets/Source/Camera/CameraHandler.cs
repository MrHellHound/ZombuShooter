using Source.Properties;
using UnityEngine;

namespace Source.Camera
{
    public class CameraHandler : MonoBehaviour
    {
        public Transform camTrans;
        public Transform pivot;
        public Transform character;
        public Transform mTransform;

        public CharacterStatus characterStatus;
        public CameraConfig cameraConfig;
        public bool leftPivot;
        public float delta;

        public float mouseX;
        public float mouseY;
        public float smoothX;
        public float smoothY;
        public float smoothXVelocity;
        public float smoothYVelocity;
        public float lockAngle;
        public float titlAngle;

        void Update()
        {
            FixedTick();
        }

        void FixedTick()
        {
            delta = Time.deltaTime;

            HandlePosition();
            HandleRotation();

            Vector3 targetPosition = Vector3.Lerp(mTransform.position, character.position, 1);
            mTransform.position = targetPosition;
        }

        void HandlePosition()
        {
            float targetX = cameraConfig.normalX;
            float targetY = cameraConfig.normalY;
            float targetZ = cameraConfig.normalZ;
            
            if (characterStatus.isAiming)
            {
                targetX = cameraConfig.aimX;
                targetZ = cameraConfig.aimZ;
            }

            if(leftPivot)
            {
                targetX = -targetX;
            }

            Vector3 newPivotPosition = pivot.localPosition;
            newPivotPosition.x = targetX;
            newPivotPosition.y = targetY;

            Vector3 newCameraPosition = camTrans.localPosition;
            newCameraPosition.z = targetZ;

            float t = delta * cameraConfig.pivotSpeed;
            pivot.localPosition = Vector3.Lerp(pivot.localPosition, newPivotPosition, t);
            camTrans.localPosition = Vector3.Lerp(camTrans.localPosition, newCameraPosition, t);
        }

        void HandleRotation()
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

            if(cameraConfig.turnSmooth > 0)
            {
                smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref smoothXVelocity, cameraConfig.turnSmooth);
                smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref smoothYVelocity, cameraConfig.turnSmooth);
            }
            else
            {
                smoothX = mouseX;
                smoothY = mouseY;
            }

            lockAngle += smoothX * cameraConfig.yRotSpeed;
            Quaternion targetRot = Quaternion.Euler(0, lockAngle, 0);
            mTransform.rotation = targetRot;

            titlAngle -= smoothY * cameraConfig.yRotSpeed;
            titlAngle = Mathf.Clamp(titlAngle, cameraConfig.minAngle, cameraConfig.maxAngle);
            pivot.localRotation = Quaternion.Euler(titlAngle, 0, 0);
        }
    }
}
