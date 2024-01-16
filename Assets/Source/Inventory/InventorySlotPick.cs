using System.Collections.Generic;
using Source.Guns;
using UnityEngine;

namespace Source.Inventory
{
    public class InventorySlotPick : MonoBehaviour
    {
        public List<AddButton> addButtonList;
        public GunsData apcData;

        public void OnSlotButtonClicked(int buttonIndex)
        {
            if (buttonIndex >= 0 && buttonIndex < addButtonList.Count)
            {
                addButtonList[buttonIndex].AddWeaponToSlot(apcData);
            }
        }
    }
}
