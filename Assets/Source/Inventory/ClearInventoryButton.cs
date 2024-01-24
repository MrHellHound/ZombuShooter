using System.Collections.Generic;
using UnityEngine;

namespace Source.Inventory
{
    public class ClearInventoryButton : MonoBehaviour
    {
        public List<WeaponSlot> weaponSlots;

        public void OnClearButtonClicked()
        {
            ClearAllSlots();
        }

        private void ClearAllSlots()
        {
            foreach (var slot in weaponSlots)
            {
                slot.occupied = false;
                slot.gunsData = null;
            }
        }
    }
}
