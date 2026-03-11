using UnityEngine;

[CreateAssetMenu(fileName = "Nowa Pochodnia", menuName = "Piramida/Przedmioty/Pochodnia")]
public class TorchItem : Item
{
    [Header("Ustawienia Swiatla")]
    public float burnTime = 60f;    // Zgodnie z GDD: czas palenia
    public float lightRadius = 5f;  // Promień oświetlenia

    public override void Use(Player player)
    {
        // Tutaj wywołamy logikę oświetlenia w przyszłości
        Debug.Log($"Uzyto pochodni: {itemName}. Bedzie swiecic przez {burnTime}s.");
    }
}