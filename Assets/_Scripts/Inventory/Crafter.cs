using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour
{
    public void Craft(Recipe recipe)
    {
        Instantiate(recipe.product, transform.position, transform.rotation);

        // To do: Remove items from inventory upon crafting
        // Check for required items before
        // Move position forward
        // Using raycast to place
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
