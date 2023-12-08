using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject objectToToggle; // Referens till det objekt som ska aktiveras/inaktiveras

    // Update k�rs en g�ng per frame
    void Update()
    {
        // Kolla om tangenten E trycks ned
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Byt aktivtillst�ndet f�r det angivna objektet (aktivera om inaktivt, inaktivera om aktivt)
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
