using UnityEngine;

/// <summary>
/// Bazowa klasa abstrakcyjna dla wszystkich przedmiotów w grze "Piramida Złotych Skarbów".
/// Pozwala na tworzenie konkretnych przedmiotów jako assety w folderze Project (PPM -> Create -> Piramida -> ...).
/// </summary>
public abstract class Item : ScriptableObject
{
    [Header("Podstawowe Informacje")]
    public string itemName;      // Nazwa przedmiotu (np. "Ognista Pochodnia")
    
    [TextArea(3, 10)]
    public string description;   // Opis fabularny lub techniczny przedmiotu

    [Header("Wizualia i Ekonomia")]
    public Sprite icon;          // Ikona z Twojej listy zasobów (np. regular_torch.png)
    public int goldValue;        // Wartość przedmiotu (Skarby Faraona)

    /// <summary>
    /// Metoda abstrakcyjna wywoływana, gdy gracz używa przedmiotu.
    /// Każdy typ przedmiotu (np. Eliksir, Pochodnia) nadpisze tę metodę własną logiką.
    /// </summary>
    /// <param name="player">Referencja do gracza, który korzysta z przedmiotu.</param>
    public abstract void Use(Player player);
}