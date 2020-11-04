using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class Item : ScriptableObject
{
    public Sprite icon;
    public Color color = Color.white;

    public InventoryObject prefab;

    public float healthRestored = 50f;
    public float staminaRestored = 0f;

    public void Use()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (healthRestored == 0 && staminaRestored == 0)
        {
            // Put it back in the world
            Instantiate(prefab, player.transform.position + player.transform.forward, player.transform.rotation);
        }
        else
        {
            // Consume it
            if (player)
            {
                HealthScript playerHealth = player.GetComponent<HealthScript>();
                if (playerHealth)
                {
                    playerHealth.AddToHealth(healthRestored);
                    playerHealth.AddToStamina(staminaRestored);
                }
            }
        }
    }
}
