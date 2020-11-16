using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public ItemUI[] slots;
    public ItemUI slotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SetInventory(inventory);
    }

    void SetInventory(Inventory inv)
    {
        inventory = inv;

        // Make the slots
        slots = new ItemUI[inventory.items.Length];

        // Make a slot UI for each slot in the inventory
        // These will be positioned by our layout group
        for (int i = 0; i < inventory.items.Length; i++)
        {
            slots [i] = Instantiate(slotPrefab, transform);
            Button button = slots[i].GetComponent<Button>();
            if (button)
            {
                int index = i;
                button.onClick.AddListener(() => OnItemClicked(index)); 
            }
        }

        // Set the correct item in every slot
        for (int i=0; i < slots.Length; i++)
        {
            slots[i].SetItem(inventory.items[i]);
        }
    }

    void OnItemClicked(int index)
    {
        inventory.items[index] = null;
        slots[index].SetItem(inventory.items[index]);
    }

    private void Update()
    {
        // Set the correct item in every slot
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetItem(inventory.items[i]);
        }
    }
}
