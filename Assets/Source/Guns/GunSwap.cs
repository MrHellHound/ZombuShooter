using UnityEngine;

namespace Source.Guns
{
    public class GunSwap : MonoBehaviour
    {
        [Header("Моделька оружия")] [SerializeField] private GameObject mainGun;

        [Header("Спрайт оружия")] [SerializeField] private GameObject mainGunInfo;

        private void Update() => UIChanger();
        
        private void UIChanger()
        {
            // GunInfo
            if (mainGun.activeInHierarchy)
            {
                mainGunInfo.SetActive(true);
            }
            else 
            {
                mainGunInfo.SetActive(false);
            }
        }
    }
}
