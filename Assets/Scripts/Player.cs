using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public enum PlayerClass { Warrior, Mage, Thief }

    [Header("Attributes")]
    public string playerName;
    public PlayerClass characterClass;
    public int health;
    public int attack;
    public int defense;
    public int experience = 0;
    public int level = 1;

    [Header("Inventory")]
    public List<string> inventory = new List<string>();

    public void Attack(Enemy enemy)
    {
        // Logika z dokumentacji: Obliczanie obrażeń
        int damage = Mathf.Max(0, attack - enemy.defense);
        enemy.TakeDamage(damage);
        Debug.Log($"{playerName} atakuje {enemy.name} za {damage} pkt!");
    }

    public void AddItem(string item)
    {
        inventory.Add(item);
        Debug.Log($"Dodano przedmiot: {item}");
    }
}