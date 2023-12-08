using UnityEngine;
using TMPro;

public class PickupObject : MonoBehaviour
{
    // Flagga som indikerar om objektet är upplyft
    private bool isPickedUp = false;

    // Förskjutning från spelarens position när objektet är upplyft
    private Vector3 offset;

    // Flagga som indikerar om objektet kan plockas upp
    private bool Canpickup = false;

    // Referens till TMP Text-elementet för plocka upp-texten
    public TextMeshProUGUI pickupText;

    [Header("Inställningar för teckensnittsstil")]
    public float normalFontSize = 18f; // Ange önskad normala teckensnittsstorlek
    public float pickedUpFontSize = 24f; // Ange önskad teckensnittsstorlek när objektet är upplyft
    public bool isBold = false; // Sätt till true för att göra teckensnittet fett

    private void Update()
    {
        // Kontrollera om "E"-tangenten trycks ned för att plocka upp eller släppa objektet
        if (Input.GetKeyDown(KeyCode.E) && Canpickup)
        {
            if (!isPickedUp)
            {
                // Markera objektet som upplyft och beräkna förskjutningen från spelarens position
                isPickedUp = true;
                offset = transform.position - GetPlayerPosition();

                // Visa plocka upp-texten med en större teckensnittsstorlek och fetstil om det är specificerat
                if (pickupText != null)
                {
                    pickupText.text = "Tryck 'E' för att Släppa";
                    SetTextProperties(pickedUpFontSize);
                }
            }
            else
            {
                // Släpp objektet
                isPickedUp = false;

                // Dölj plocka upp-texten och återställ teckensnittsstorleken till normal
                if (pickupText != null)
                {
                    pickupText.text = "Tryck 'E' för att Plocka Upp";
                    SetTextProperties(normalFontSize);
                }
            }
        }

        // Om objektet är upplyft, uppdatera dess position baserat på spelarens position
        if (isPickedUp)
        {
            transform.position = GetPlayerPosition() + offset;
        }
    }

    // Triggers-metod som anropas när objektet träffar en annan collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Canpickup = true;

            // Visa plocka upp-texten med normal teckensnittsstorlek
            if (pickupText != null && !isPickedUp)
            {
                pickupText.text = "Tryck 'E' för att Plocka Upp";
                SetTextProperties(normalFontSize);
            }
        }
    }

    // Triggers-metod som anropas när objektet lämnar en annan collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Canpickup = false;

            // Dölj plocka upp-texten och återställ teckensnittsstorleken till normal
            if (pickupText != null)
            {
                pickupText.text = "";
                SetTextProperties(normalFontSize);
            }
        }
    }

    // Metod för att ställa in egenskaper för texten
    private void SetTextProperties(float fontSize)
    {
        if (pickupText != null)
        {
            pickupText.fontSize = fontSize;
            pickupText.fontWeight = isBold ? FontWeight.Bold : FontWeight.Regular;
        }
    }

    // Metod för att hämta spelarens position
    private Vector3 GetPlayerPosition()
    {
        // Ersätt detta med den faktiska positionen för din spelarkaraktär
        return Camera.main.transform.position;
    }
}
