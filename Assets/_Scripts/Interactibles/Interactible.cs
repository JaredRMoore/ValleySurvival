using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactible : MonoBehaviour
{
    public UnityEvent onActivate;
    public UnityEvent onFail;
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;
    public string message;
    public Item requiredItem;

    public void Activate()
    {
        if (requiredItem == null || Inventory.instance.hasItem(requiredItem))
        {
            onActivate.Invoke();
        }
        else
        {
            onFail.Invoke();
        }
    }
    // For dialogue prompts
    public void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
    }
    public void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke();
    }
}
