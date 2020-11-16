using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Inventory/Recipe", order = 1)]
public class Recipe : ScriptableObject
{
    public Item[] ingredients;
    public GameObject product;
    public int weaponUnlock = -1;
}
