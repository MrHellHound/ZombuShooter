using UnityEngine;

namespace Source.Player
{
    public class PlayerController : MonoBehaviour
    {
        public CharacterMovement cm;

        public void Update()
        {
            cm.MoveUpdate();
        }
    }
}
