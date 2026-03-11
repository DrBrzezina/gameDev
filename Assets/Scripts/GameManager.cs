using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Menu, Exploration, Combat, GameOver }
    public GameState currentState;
    public Player player;

    void Start()
    {
        ChangeState(GameState.Menu);
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        Debug.Log($"Stan gry zmieniony na: {newState}");
    }

    void Update()
    {
        // Główna pętla Unity (odpowiednik while running w Pygame)
    }
}