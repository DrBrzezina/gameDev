using UnityEngine;
using UnityEngine.Tilemaps; // Dodaj to!

public class LevelGenerator : MonoBehaviour
{
    [Header("Loot Settings")]
    public GameObject itemPickupPrefab; // Prefab z Twoim skryptem ItemPickup
    public List<Item> possibleLoot;     // Lista przedmiotów z folderu Data
    [Range(0, 1)] public float lootSpawnChance = 0.2f; // 20% szansy na przedmiot w pokoju

// Zaktualizuj metodę CreateRoom lub dodaj nową:
    void PlaceLootInRoom(int x, int y, int w, int h)
    {
     // Losujemy, czy w tym pokoju w ogóle pojawi się skarb
        if (Random.value < lootSpawnChance)
        {
            // Wybieramy losowe miejsce wewnątrz pokoju
            int spawnX = Random.Range(x, x + w);
            int spawnY = Random.Range(y, y + h);
            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
    
            // Wybieramy losowy przedmiot z listy
            Item randomItem = possibleLoot[Random.Range(0, possibleLoot.Count)];

            // Logika spawnowania (wykonana przez Unity, ale kod przygotowany):
            Debug.Log($"Planowane spawnowanie {randomItem.itemName} na pozycji {spawnPos}");
        
            // Ta linia zadziała w Unity:
            // GameObject loot = Instantiate(itemPickupPrefab, spawnPos, Quaternion.identity);
            // loot.GetComponent<ItemPickup>().itemData = randomItem;
        }
    }   
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