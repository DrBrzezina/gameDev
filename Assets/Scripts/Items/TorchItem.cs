using UnityEngine;

[CreateAssetMenu(fileName = "Nowa Pochodnia", menuName = "Piramida/Przedmioty/Pochodnia")]
public class TorchItem : Item
{
    [Header("Ustawienia Swiatla")]
    public float burnTime = 60f;    // Czas palenia z dokumentacji
    public float lightRadius = 5f;  // Zasieg swiatla

    public override void Use(Player player)
    {
        // 1. Szukamy TorchManager na scenie
        TorchManager torchManager = GameObject.FindObjectOfType<TorchManager>();

        // 2. Jeśli menedżer istnieje, odpalamy pochodnię
        if (torchManager != null)
        {
            torchManager.LightTorch(burnTime);
            Debug.Log($"Uzyto: {itemName}. Przekazano {burnTime}s do TorchManager.");
        }
        else
        {
            // To zabezpieczenie, gdybyś zapomniał wrzucić skrypt na scenę w Unity
            Debug.LogWarning("Brak TorchManager na scenie! Nie mozna zapalic pochodni.");
        }
    }
}