using UnityEngine;

[CreateAssetMenu(fileName = "Nowy Skarb", menuName = "Piramida/Przedmioty/Skarb")]
public class TreasureItem : Item
{
    public override void Use(Player player)
    {
        // Skarby po "użyciu" w ekwipunku mogą np. dawać złoto lub punkty chwały
        Debug.Log($"Skarb {itemName} ma wartosc {goldValue} sztuk zlota.");
    }
}