using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    public Item item;
    public float respawnTime = 300f; // 5 minutes
     
    public void Pickup()
    {
        Inventory.instance.Pickup(item);
        gameObject.SetActive(false);
        if (respawnTime > 0)
            StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        gameObject.SetActive(true);
    }
}
