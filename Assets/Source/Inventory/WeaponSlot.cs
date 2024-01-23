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
        public GameObject m4a1Icon;


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
            
            if (gunsData != null && gunsData.GunName == "M4A1")
            {
                m4a1Icon.SetActive(true);
            }
            else
            {
                m4a1Icon.SetActive(false);
            }
        }
    }
    
}
