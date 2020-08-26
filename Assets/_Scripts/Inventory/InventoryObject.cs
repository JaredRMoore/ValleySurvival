using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    public Item item;

    public void Pickup()
    {
        Inventory.instance.Pickup(item);
        gameObject.SetActive(false);
    }
}
