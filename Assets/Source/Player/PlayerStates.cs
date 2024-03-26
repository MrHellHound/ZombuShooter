using UnityEngine;

namespace Source.Player
{
    [CreateAssetMenu(menuName = "PlayerStates", fileName = "New states")]
    public class PlayerStates : ScriptableObject
    {
        [SerializeField] private bool _isWalking;
        public bool IsWalking
        {
            get => _isWalking;
            set => _isWalking = value;
        }
        
        [SerializeField] private bool _isRunning;
        public bool IsRunning
        {
            get => _isWalking;
            set => _isWalking = value;
        }
        
        [SerializeField] private bool _isSighting;
        public bool IsSighting
        {
            get => _isSighting;
            set => _isSighting = value;
        }
    }
}
