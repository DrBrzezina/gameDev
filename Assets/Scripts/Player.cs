using UnityEngine;
using System;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public enum PlayerClass { Warrior, Mage, Thief }

    [Header("Statystyki")]
    public string playerName;
    public PlayerClass characterClass;
    public int health;
    public int maxHealth = 100;
    public int attack;
    public int defense;
    public int experience = 0;
    public int level = 1;

    [Header("Ekwipunek")]
    // Zmienione z List<string> na List<Item> - teraz przechowujemy prawdziwe obiekty!
    public List<Item> inventory = new List<Item>();

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{playerName} otrzymał {damage} obrażeń. HP: {health}");

        if (health <= 0)
        {
            health = 0;
            OnPlayerDeath?.Invoke();
        }
    }

    public void Attack(Enemy enemy)
    {
        int damage = Mathf.Max(0, attack - enemy.defense);
        enemy.TakeDamage(damage);
    }

    // Nowa metoda dodawania przedmiotów
    public void AddItem(Item newItem)
    {
        inventory.Add(newItem);
        Debug.Log($"Podniesiono przedmiot: {newItem.itemName}");
    }

    // Metoda używania przedmiotu z inwentarza
    public void UseItem(int index)
    {
        if (index >= 0 && index < inventory.Count)
        {
            Item itemToUse = inventory[index];
            itemToUse.Use(this);

            // Jeśli to eliksir, usuwamy go po użyciu
            if (itemToUse is PotionItem)
            {
                inventory.RemoveAt(index);
            }
        }
    }
}