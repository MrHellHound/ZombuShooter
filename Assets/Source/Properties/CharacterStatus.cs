using UnityEngine;

namespace Source.Properties
{
    [CreateAssetMenu(menuName = "Character/status")]
    public class CharacterStatus : ScriptableObject
    {
        public bool isAiming;
        public bool isRunning;
        public bool isGrounded;
    }
}
