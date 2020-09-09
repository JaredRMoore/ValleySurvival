using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPointer : MonoBehaviour
{
    public LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // central pixel ray
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3.0f, layerMask))
            {
                Interactible interactible = hit.collider.GetComponent<Interactible>();
                if (interactible != null)
                {
                    interactible.Activate();
                }
            }
        }
    }
}
