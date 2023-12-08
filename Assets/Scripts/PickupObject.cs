using UnityEngine;
using TMPro;

public class PickupObject : MonoBehaviour
{
    // Flagga som indikerar om objektet �r upplyft
    private bool isPickedUp = false;

    // F�rskjutning fr�n spelarens position n�r objektet �r upplyft
    private Vector3 offset;

    // Flagga som indikerar om objektet kan plockas upp
    private bool Canpickup = false;

    // Referens till TMP Text-elementet f�r plocka upp-texten
    public TextMeshProUGUI pickupText;

    [Header("Inst�llningar f�r teckensnittsstil")]
    public float normalFontSize = 18f; // Ange �nskad normala teckensnittsstorlek
    public float pickedUpFontSize = 24f; // Ange �nskad teckensnittsstorlek n�r objektet �r upplyft
    public bool isBold = false; // S�tt till true f�r att g�ra teckensnittet fett

    private void Update()
    {
        // Kontrollera om "E"-tangenten trycks ned f�r att plocka upp eller sl�ppa objektet
        if (Input.GetKeyDown(KeyCode.E) && Canpickup)
        {
            if (!isPickedUp)
            {
                // Markera objektet som upplyft och ber�kna f�rskjutningen fr�n spelarens position
                isPickedUp = true;
                offset = transform.position - GetPlayerPosition();

                // Visa plocka upp-texten med en st�rre teckensnittsstorlek och fetstil om det �r specificerat
                if (pickupText != null)
                {
                    pickupText.text = "Tryck 'E' f�r att Sl�ppa";
                    SetTextProperties(pickedUpFontSize);
                }
            }
            else
            {
                // Sl�pp objektet
                isPickedUp = false;

                // D�lj plocka upp-texten och �terst�ll teckensnittsstorleken till normal
                if (pickupText != null)
                {
                    pickupText.text = "Tryck 'E' f�r att Plocka Upp";
                    SetTextProperties(normalFontSize);
                }
            }
        }

        // Om objektet �r upplyft, uppdatera dess position baserat p� spelarens position
        if (isPickedUp)
        {
            transform.position = GetPlayerPosition() + offset;
        }
    }

    // Triggers-metod som anropas n�r objektet tr�ffar en annan collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Canpickup = true;

            // Visa plocka upp-texten med normal teckensnittsstorlek
            if (pickupText != null && !isPickedUp)
            {
                pickupText.text = "Tryck 'E' f�r att Plocka Upp";
                SetTextProperties(normalFontSize);
            }
        }
    }

    // Triggers-metod som anropas n�r objektet l�mnar en annan collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Canpickup = false;

            // D�lj plocka upp-texten och �terst�ll teckensnittsstorleken till normal
            if (pickupText != null)
            {
                pickupText.text = "";
                SetTextProperties(normalFontSize);
            }
        }
    }

    // Metod f�r att st�lla in egenskaper f�r texten
    private void SetTextProperties(float fontSize)
    {
        if (pickupText != null)
        {
            pickupText.fontSize = fontSize;
            pickupText.fontWeight = isBold ? FontWeight.Bold : FontWeight.Regular;
        }
    }

    // Metod f�r att h�mta spelarens position
    private Vector3 GetPlayerPosition()
    {
        // Ers�tt detta med den faktiska positionen f�r din spelarkarakt�r
        return Camera.main.transform.position;
    }
}
