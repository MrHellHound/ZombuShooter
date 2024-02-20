using UnityEngine;

namespace Source.Player
{
    public class CursorLock : MonoBehaviour
    {
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
