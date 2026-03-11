using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int health;
    public int attack;
    public int defense;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{enemyName} otrzymał {damage} obrażeń. Pozostałe HP: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // To rozwiązuje błąd z Planu Poprawek (zawieszanie gry przy 0 HP)
        Debug.Log($"{enemyName} został pokonany!");
        Destroy(gameObject); 
    }
}