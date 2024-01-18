using System.Collections.Generic;
using Source.Guns;
using UnityEngine;

namespace Source.Inventory
{
    public class InventorySlotPick : MonoBehaviour
    {
        public List<AddButton> addButtons;

        public void OnSlotButtonClicked(int slotIndex)
        {
            foreach (var addButton in addButtons)
            {
                addButton.SelectSlot(slotIndex);
            }
        }
        
        public void OnAddWeaponButtonClicked(GunsData newWeapon)
        {
            foreach (var addButton in addButtons)
            {
                addButton.AddWeaponToSelectedSlot(newWeapon);
            }
        }
    }
}
