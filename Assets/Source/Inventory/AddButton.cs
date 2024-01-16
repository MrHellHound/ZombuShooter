using Source.Guns;
using UnityEngine;

namespace Source.Inventory
{
    public class AddButton : MonoBehaviour
    {
        public int slotIndex;
        public WeaponSlot[] weaponSlots;

        public void AddWeaponToSlot(GunsData newWeapon)
        {
            if (slotIndex >= 0 && slotIndex < weaponSlots.Length)
            {
                WeaponSlot currentSlot = weaponSlots[slotIndex];

                if (!currentSlot.occupied)
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
                        currentSlot.occupied = true;
                        currentSlot.gunsData = newWeapon;
                    }
                }
            }
        }
    }
}
