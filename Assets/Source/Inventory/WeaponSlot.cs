using Source.Guns;
using UnityEngine;

namespace Source.Inventory
{
    [System.Serializable]

    public class WeaponSlot : MonoBehaviour
    {
        public bool occupied;
        public GunsData gunsData;

        public GameObject apc9Icon;


        private void Update()
        {
            WeaponCheck();
        }

        public WeaponSlot()
        {
            occupied = false;
            gunsData = null;
        }

        private void WeaponCheck()
        {
            // APC-9
            if (gunsData != null && gunsData.GunName == "APC-9")
            {
                apc9Icon.SetActive(true);
            }
            else
            {
                apc9Icon.SetActive(false);
            }
        }
    }
    
}
