using UnityEngine;
using System;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    [Header("Tożsamość Scavengera")]
    public string playerName = "Scavenger";
    
    [Header("Statystyki Życia")]
    public int health;
    public int maxHealth = 100;
    public int attack = 15;
    public int defense = 5;

    [Header("System Poziomów")]
    public int level = 1;
    public int experience = 0;
    public int expToNextLevel = 100;

    [Header("Ekwipunek")]
    public List<Item> inventory = new List<Item>();

    private void Start()
    {
        // Ustawiamy życie na max przy starcie
        health = maxHealth;
        Debug.Log($"Scavenger {playerName} wchodzi do piramidy.");
    }

    // --- SYSTEM OBRAŻEŃ I WALKI ---

    public void TakeDamage(int damage)
    {
        // Uwzględniamy obronę (minimalne obrażenia to 1)
        int finalDamage = Mathf.Max(1, damage - defense);
        health -= finalDamage;
        
        Debug.Log($"{playerName} otrzymał {finalDamage} obrażeń. HP: {health}");

        if (health <= 0)
        {
            health = 0;
            OnPlayerDeath?.Invoke();
        }
    }

    public void Attack(Enemy enemy)
    {
        // Zadajemy obrażenia zależne od ataku gracza i obrony wroga
        int damage = Mathf.Max(0, attack - enemy.defense);
        enemy.TakeDamage(damage);
    }

    // --- SYSTEM DOŚWIADCZENIA ---

    public void AddExperience(int amount)
    {
        experience += amount;
        Debug.Log($"{playerName} zdobył {amount} PD. Razem: {experience}/{expToNextLevel}");

        // Pętla na wypadek zdobycia ogromnej ilości PD na raz
        while (experience >= expToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {   
        experience -= expToNextLevel;
        level++;

        // Próg na kolejny poziom rośnie o 20%
        expToNextLevel = Mathf.RoundToInt(expToNextLevel * 1.2f);

        // Bonusy statystyk dla Scavengera
        maxHealth += 10;
        health = maxHealth; // Pełne leczenie przy awansie
        attack += 2;
        defense += 1;

        Debug.Log($"<color=green>AWANS! Poziom {level} osiągnięty!</color>");
        Debug.Log($"Statystyki: HP: {maxHealth}, ATK: {attack}, DEF: {defense}");
    }

    // --- EKWIPUNEK ---

    public void AddItem(Item newItem)
    {
        inventory.Add(newItem);
        Debug.Log($"Podniesiono przedmiot: {newItem.itemName}");
    }

    public void UseItem(int index)
    {
        if (index >= 0 && index < inventory.Count)
        {
            Item itemToUse = inventory[index];
            itemToUse.Use(this);

            // Jeśli to eliksir, usuwamy go po użyciu (pochodnie zostają jako dane o czasie)
            if (itemToUse is PotionItem)
            {
                inventory.RemoveAt(index);
            }
        }
    }
}