using Source.Guns;
using UnityEngine;

namespace Source.Inventory
{
    public class AddButton : MonoBehaviour
    {
        public WeaponSlot[] weaponSlots;

        private int _selectedSlotIndex = -1;

        public void SelectSlot(int slotIndex)
        {
            _selectedSlotIndex = slotIndex;
        }

        public void AddWeaponToSelectedSlot(GunsData newWeapon)
        {
            if (_selectedSlotIndex >= 0 && _selectedSlotIndex < weaponSlots.Length)
            {
                WeaponSlot selectedSlot = weaponSlots[_selectedSlotIndex];
                
                if (IsWeaponAlreadyInInventory(newWeapon))
                {
                    return;
                }

                if (!selectedSlot.occupied)
                {
                    selectedSlot.gunsData = newWeapon;
                    selectedSlot.occupied = true;
                }
                else
                {
                    TrySwapWeaponWithOtherSlots(newWeapon);
                }
            }
        }

        private bool IsWeaponAlreadyInInventory(GunsData weaponToCheck)
        {
            for (int i = 0; i < weaponSlots.Length; i++)
            {
                if (weaponSlots[i].occupied && weaponSlots[i].gunsData == weaponToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        private void TrySwapWeaponWithOtherSlots(GunsData newWeapon)
        {
            for (int i = 0; i < weaponSlots.Length; i++)
            {
                WeaponSlot currentSlot = weaponSlots[i];

                if (currentSlot.occupied && currentSlot.gunsData == newWeapon)
                {
                    SwapWeaponsInSlots(_selectedSlotIndex, i);
                    return;
                }
            }
        }

        private void SwapWeaponsInSlots(int firstSlotIndex, int secondSlotIndex)
        {
            if (firstSlotIndex >= 0 && firstSlotIndex < weaponSlots.Length &&
                secondSlotIndex >= 0 && secondSlotIndex < weaponSlots.Length)
            {
                (weaponSlots[firstSlotIndex].gunsData, weaponSlots[secondSlotIndex].gunsData) =
                    (weaponSlots[secondSlotIndex].gunsData, weaponSlots[firstSlotIndex].gunsData);
            }
        }
    }
}
