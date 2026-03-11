using UnityEngine;
using UnityEngine.Tilemaps; // Dodaj to!

public class LevelGenerator : MonoBehaviour
{
    [Header("Tilemap References")]
    public Tilemap groundTilemap; // Referencja do warstwy podłogi
    public Tilemap wallTilemap;   // Referencja do warstwy ścian
    
    [Header("Tiles")]
    public TileBase floorTile;    // Tu przeciągniesz kafel podłogi (np. piasek)
    public TileBase wallTile;     // Tu przeciągniesz kafel ściany (kamień)

    public int width = 20;
    public int height = 20;

    public void GenerateMap()
    {
        // Najpierw czyścimy mapę, jeśli generujemy ją ponownie
        groundTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();

        // Generujemy podłogę na całym obszarze
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Ustawiamy kafelek podłogi na pozycji Vector3Int
                groundTilemap.SetTile(new Vector3Int(x, y, 0), floorTile);
                
                // Przykładowo: obramowanie mapy ścianami
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    wallTilemap.SetTile(new Vector3Int(x, y, 0), wallTile);
                }
            }
        }

        // Twoja dotychczasowa logika losowania pomieszczeń:
        int roomsCount = Random.Range(5, 11);
        for (int i = 0; i < roomsCount; i++)
        {
            int rx = Random.Range(1, width - 1);
            int ry = Random.Range(1, height - 1);
            
            // Możemy tu dodać specjalny kafel skarbca lub po prostu wyczyścić ścianę
            groundTilemap.SetTile(new Vector3Int(rx, ry, 0), floorTile);
            Debug.Log($"Wygenerowano pomieszczenie na: {rx},{ry}");
        }
    }
}