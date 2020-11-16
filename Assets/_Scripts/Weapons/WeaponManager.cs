using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponHandler[] weapons;

    private int current_Weapon_Index;

    public bool[] weaponsUnlocked = new bool[2];

    // Start is called before the first frame update
    void Start()
    {
        current_Weapon_Index = -1;
        //weapons[current_Weapon_Index].gameObject.SetActive(false);
    }

    public void UnlockWeapon(int index)
    {
        weaponsUnlocked[index] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponsUnlocked[0])
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TurnOnSelectedWeapon(0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                TurnOnSelectedWeapon(0);
            }
        }
        if (weaponsUnlocked[1])
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TurnOnSelectedWeapon(1);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                TurnOnSelectedWeapon(1);
            }
        }
        // Sheathe current weapon
        if (Input.GetKeyDown(KeyCode.F) && current_Weapon_Index >= 0)
        {
            TurnOffSelectedWeapon(current_Weapon_Index);
            current_Weapon_Index = -1;
        }
    }
    void TurnOnSelectedWeapon(int weaponIndex)
    {
        if (current_Weapon_Index == weaponIndex)
            return;

        // Turn off the current weapon
        if (current_Weapon_Index >= 0)
            weapons[current_Weapon_Index].gameObject.SetActive(false);

        // Turn on the selected weapon
        weapons[weaponIndex].gameObject.SetActive(true);

        // Store the current selected weapon index
        current_Weapon_Index = weaponIndex;
    }

    void TurnOffSelectedWeapon(int weaponIndex)
    {
        // Turn off the current weapon
        weapons[current_Weapon_Index].gameObject.SetActive(false);
    }

    public WeaponHandler GetCurrentSelectedWeapon()
    {
        if (current_Weapon_Index < 0)
            return null;
        return weapons[current_Weapon_Index];
    }
}
