using UnityEngine;

public class GameTester : MonoBehaviour
{
    void Start()
    {
        Debug.Log("=== ROZPOCZYNAM TESTY LOGIKI ===");
        
        Player p = GetComponent<Player>();
        if(p == null) p = gameObject.AddComponent<Player>();

        // Test 1: Czy PD się dodaje?
        p.AddExperience(50);
        Debug.Log(p.experience == 50 ? "TEST 1 PASSED" : "TEST 1 FAILED");

        // Test 2: Czy Level Up działa?
        p.AddExperience(60); // Razem 110, powinien być lvl 2
        Debug.Log(p.level == 2 ? "TEST 2 PASSED (Level Up)" : "TEST 2 FAILED");
        
        Debug.Log("=== KONIEC TESTÓW ===");
    }
}