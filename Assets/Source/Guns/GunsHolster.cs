using UnityEngine;

public class GunsHolster : MonoBehaviour
{
    public int weaponSwitch = 0;
    [Tooltip("Количество слотов оружия")] 
    public int inventorySlots;
    void Start()
    {
        SelectWeapon();
    }
    
    void Update()
    {
        int currentWeapon = weaponSwitch;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponSwitch >= inventorySlots - 1)
            {
                weaponSwitch = 0;
            }
            else
            {
                weaponSwitch++;
            }
            
        }
    
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponSwitch <= 0)
            {
                weaponSwitch = inventorySlots - 1; 
            }
            else 
            { 
                weaponSwitch--;
            }           
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSwitch = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            weaponSwitch = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            weaponSwitch = 2;
        }

        if (currentWeapon != weaponSwitch)
        {
            SelectWeapon();
        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponSwitch)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
