using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public void ExecuteTurn(Player player, Enemy enemy)
    {
        if (player.health > 0 && enemy.health > 0)
        {
            // Tura gracza
            player.Attack(enemy);
            
            // Sprawdzenie czy wróg żyje (naprawia błąd zawieszania się z QA)
            if (enemy.health > 0)
            {
                // Tura wroga
                int enemyDamage = Mathf.Max(0, enemy.attack - player.defense);
                player.health -= enemyDamage;
                Debug.Log($"{enemy.enemyName} zadaje {enemyDamage} obrażeń graczowi.");
            }
        }
    }
}
