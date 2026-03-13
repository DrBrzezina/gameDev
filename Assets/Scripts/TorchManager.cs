using UnityEngine;

public class TorchManager : MonoBehaviour
{
    [Header("Current Torch Status")]
    public bool isTorchLit = false;
    public float currentBurnTime = 0f;
    public float maxBurnTime = 0f;

    [Header("Settings")]
    public float warningThreshold = 10f; // Powiadomienie, gdy zostanie 10 sekund

    private void Update()
    {
        // Jeśli pochodnia jest zapalona, odliczamy czas
        if (isTorchLit && currentBurnTime > 0)
        {
            currentBurnTime -= Time.deltaTime;

            // Logika ostrzegania (opcjonalnie)
            if (currentBurnTime <= warningThreshold && currentBurnTime > warningThreshold - Time.deltaTime)
            {
                Debug.LogWarning("Twoja pochodnia zaraz zgaśnie! Robi się ciemno...");
            }

            // Co się dzieje, gdy czas się skończy
            if (currentBurnTime <= 0)
            {
                ExtinguishTorch();
            }
        }
    }

    // Metoda wywoływana przez TorchItem.cs
    public void LightTorch(float burnTime)
    {
        isTorchLit = true;
        maxBurnTime = burnTime;
        currentBurnTime = burnTime;
        Debug.Log($"Pochodnia zapalona! Czas: {burnTime} sekund.");
    }

    private void ExtinguishTorch()
    {
        isTorchLit = false;
        currentBurnTime = 0;
        Debug.LogError("Pochodnia zgasła! Jesteś w całkowitej ciemności.");
        // Tutaj w przyszłości wywołamy karę do statystyk lub ciemność na ekranie
    }

    // Funkcja pomocnicza do UI - zwraca procent wypalenia (0-1)
    public float GetTorchLifePercent()
    {
        if (maxBurnTime <= 0) return 0;
        return currentBurnTime / maxBurnTime;
    }
}