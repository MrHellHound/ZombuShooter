using Source.Guns;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Inventory
{
    [System.Serializable]

    public class WeaponSlot : MonoBehaviour
    {
        public bool occupied;
        public GunsData gunsData;
        public Image icon;
        
        public WeaponSlot()
        {
            occupied = false;
            gunsData = null;
        }
        public void SetIcon(Sprite sprite)
        {
            if (icon != null)
            {
                icon.sprite = sprite;
            }
        }
    }
    
}
