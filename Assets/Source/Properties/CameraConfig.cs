using UnityEngine;

namespace Source.Properties
{
    [CreateAssetMenu(menuName = "Camera/Config")]
    public class CameraConfig : ScriptableObject
    {
        public float turnSmooth;
        public float pivotSpeed;
        public float xRotSpeed;
        public float yRotSpeed;
        public float minAngle;
        public float maxAngle;
        public float normalX;
        public float normalY;
        public float normalZ;
        public float aimZ;
        public float aimX;
    }
}
