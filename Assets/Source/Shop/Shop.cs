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
            }
            else if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.Escape))
            {
                shop.SetActive(false);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                shop.SetActive(false);
            }
        }
    }
}
