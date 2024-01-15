using Source.Guns;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Inventory
{
    public class AddButton : MonoBehaviour
    {
        public WeaponSlot[] weaponSlots = new WeaponSlot[3];
        public GunsData gunsData;

        public void AddWeaponToSlot(GunsData newWeapon)
        {
            Image weaponIcon = gunsData.MainSprite; 

            for (int i = 0; i < weaponSlots.Length; i++)
            {
                if (!weaponSlots[i].occupied)
                {
                    bool canAddWeapon = true;
                    for (int j = 0; j < weaponSlots.Length; j++)
                    {
                        if (weaponSlots[j].occupied && weaponSlots[j].gunsData == newWeapon)
                        {
                            canAddWeapon = false;
                            break;
                        }
                    }

                    if (canAddWeapon)
                    {
                        weaponSlots[i].occupied = true;
                        weaponSlots[i].gunsData = newWeapon;
                        weaponSlots[i].SetIcon(weaponIcon.sprite);
                        break;
                    }
                }
            }
        }
    }
}
