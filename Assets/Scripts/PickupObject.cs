using UnityEngine;
using TMPro;

public class PickupObject : MonoBehaviour
{
    private bool isPickedUp = false;
    private Vector3 offset;
    private bool Canpickup = false;
    public TextMeshProUGUI pickupText; // Reference to the TMP Text element

    [Header("Font Style Settings")]
    public float normalFontSize = 18f; // Set your desired normal font size
    public float pickedUpFontSize = 24f; // Set your desired font size when the object is picked up
    public bool isBold = false; // Set to true to make the font bold

    private void Update()
    {
        // Check for the "E" key to pick up or drop the object
        if (Input.GetKeyDown(KeyCode.E) && Canpickup)
        {
            if (!isPickedUp)
            {
                // Set the object as picked up and calculate the offset from the player's position
                isPickedUp = true;
                offset = transform.position - GetPlayerPosition();

                // Display the pickup text with a larger font size and bold if specified
                if (pickupText != null)
                {
                    pickupText.text = "Press 'E' to Drop";
                    SetTextProperties(pickedUpFontSize);
                }
            }
            else
            {
                // Release the object
                isPickedUp = false;

                // Hide the pickup text and set the font size back to normal
                if (pickupText != null)
                {
                    pickupText.text = "Press 'E' to Pick Up";
                    SetTextProperties(normalFontSize);
                }
            }
        }

        // If the object is picked up, update its position based on the player's position
        if (isPickedUp)
        {
            transform.position = GetPlayerPosition() + offset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Canpickup = true;

            // Display the pickup text with the normal font size
            if (pickupText != null && !isPickedUp)
            {
                pickupText.text = "Press 'E' to Pick Up";
                SetTextProperties(normalFontSize);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Canpickup = false;

            // Hide the pickup text and set the font size back to normal
            if (pickupText != null)
            {
                pickupText.text = "";
                SetTextProperties(normalFontSize);
            }
        }
    }

    private void SetTextProperties(float fontSize)
    {
        if (pickupText != null)
        {
            pickupText.fontSize = fontSize;
            pickupText.fontWeight = isBold ? FontWeight.Bold : FontWeight.Regular;
        }
    }

    private Vector3 GetPlayerPosition()
    {
        // Replace this with the actual position of your player character
        return Camera.main.transform.position;
    }
}
