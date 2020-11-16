using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour
{
    public void Craft(Recipe recipe)
    {
        Inventory inventory = GetComponent<Inventory>();
        List<Item> items = new List<Item>(inventory.items);

        foreach (Item ingredient in recipe.ingredients)
        {
            int index = items.IndexOf(ingredient);
            // we dont have this ingedient, so finish
            if (index == -1)
                return;
            // remove the item
            items[index] = null;
        }

        // we have all the ingredients!!
        // copy our list with the items removed into our inventory
        inventory.items = items.ToArray();

        if (recipe.product != null)
            Instantiate(recipe.product, transform.position, transform.rotation);

        WeaponManager wm = GetComponent<WeaponManager>();

        if (recipe.weaponUnlock >= 0)
            wm.UnlockWeapon(recipe.weaponUnlock);
    }
}
