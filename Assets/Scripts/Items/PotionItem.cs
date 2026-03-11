using UnityEngine;

[CreateAssetMenu(fileName = "Nowy Eliksir", menuName = "Piramida/Przedmioty/Eliksir")]
public class PotionItem : Item
{
    [Header("Ustawienia Eliksiru")]
    public int healAmount = 20;

    public override void Use(Player player)
    {
        // Sprawdzamy czy gracz w ogóle potrzebuje leczenia
        if (player.health < player.maxHealth)
        {
            player.health = Mathf.Min(player.maxHealth, player.health + healAmount);
            Debug.Log($"{player.playerName} uleczony o {healAmount}. Aktualne HP: {player.health}");
        }
        else
        {
            Debug.Log("Zdrowie jest już pełne!");
        }
    }
}