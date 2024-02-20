using UnityEngine;

namespace Source.Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private GameObject shop;
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
            {
                shop.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.Escape))
            {
                shop.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                shop.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
