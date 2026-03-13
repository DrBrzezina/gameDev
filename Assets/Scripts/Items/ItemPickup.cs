using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [Header("Ustawienia Przedmiotu")]
    public Item itemData; // Tutaj w inspektorze przeciągniesz plik z folderu Data!

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawdzamy, czy to gracz wszedł w przedmiot
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            // Dodajemy przedmiot do ekwipunku gracza
            player.AddItem(itemData);
            
            Debug.Log($"Podniesiono: {itemData.itemName}");

            // Niszczymy obiekt na mapie, bo został zebrany
            Destroy(gameObject);
        }
    }
}