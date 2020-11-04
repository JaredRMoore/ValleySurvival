using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image icon;
    public Item item;

    // Start is called before the first frame update
    private void Start()
    {
        SetItem(item);
        Button button = GetComponent<Button>();
        if (button)
            button.onClick.AddListener(UseItem);
    }

    void UseItem()
    {
        if (item)
        {
            item.Use();
            SetItem(null);
            // To do - set the corresponding slot in the inventory
        }
    }

    public void SetItem(Item it)
    {
        item = it;
        if (icon != null)
        {
            if (item != null)
            {
                icon.sprite = item.icon;
                icon.color = item.color;
            }
            // Turn the item off if the slot is empty
            icon.gameObject.SetActive(item != null);
        }
    }
}
