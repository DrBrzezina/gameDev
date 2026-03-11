using UnityEngine;
using System; // Wymagane dla Action
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    // Definicja zdarzenia śmierci
    public static event Action OnPlayerDeath;

    public enum PlayerClass { Warrior, Mage, Thief }

    [Header("Attributes")]
    public string playerName;
    public PlayerClass characterClass;
    public int health;
    public int maxHealth = 100; // Warto mieć max HP
    public int attack;
    public int defense;
    public int experience = 0;
    public int level = 1;

    [Header("Inventory")]
    public List<Item> inventory = new List<Item>(); // Poprawione na List<Item> zgodnie z sugestią!

    // Metoda do otrzymywania obrażeń
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{playerName} otrzymał {damage} obrażeń. Pozostałe HP: {health}");

        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{playerName} zginął w piramidzie...");
        // Odpalamy zdarzenie - powiadamiamy wszystkich "słuchaczy"
        OnPlayerDeath?.Invoke();
    }

    public void Attack(Enemy enemy)
    {
        int damage = Mathf.Max(0, attack - enemy.defense);
        enemy.TakeDamage(damage);
    }
}