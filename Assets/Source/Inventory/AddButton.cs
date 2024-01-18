using Source.Guns;
using UnityEngine;

namespace Source.Inventory
{
    public class AddButton : MonoBehaviour
    {
        public WeaponSlot[] weaponSlots;

        private int selectedSlotIndex = -1;

        public void SelectSlot(int slotIndex)
        {
            selectedSlotIndex = slotIndex;
        }

        public void AddWeaponToSelectedSlot(GunsData newWeapon)
        {
            if (selectedSlotIndex >= 0 && selectedSlotIndex < weaponSlots.Length)
            {
                WeaponSlot selectedSlot = weaponSlots[selectedSlotIndex];

                if (!selectedSlot.occupied)
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
                        selectedSlot.occupied = true;
                        selectedSlot.gunsData = newWeapon;
                    }
                }
            }
        }
    }
}
