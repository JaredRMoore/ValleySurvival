using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour
{
    public void Craft(Recipe recipe)
    {
        Instantiate(recipe.product, transform.position, transform.rotation);
    }
}
