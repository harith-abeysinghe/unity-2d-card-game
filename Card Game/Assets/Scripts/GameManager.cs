using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class GameManager : MonoBehaviour
{
    private Player currentPlayer; // Reference to the currently active player

    private void Start()
    {
        // Initialize the currentPlayer to the starting player (e.g., Player1)
        currentPlayer = GameObject.Find("Player1").GetComponent<Player>();
    }

    public void SwitchPlayer()
    {
        // Switch the active player
        if (currentPlayer == GameObject.Find("Player1").GetComponent<Player>())
        {
            currentPlayer = GameObject.Find("Player2").GetComponent<Player>();
        }
        else
        {
            currentPlayer = GameObject.Find("Player1").GetComponent<Player>();
        }
    }

    public void TakeCard(GameObject card)
{
    DragDrop dragDrop = card.GetComponent<DragDrop>();
    if (dragDrop != null && dragDrop.location == 2) // Only allow taking cards from the board
    {
        // Get the current player's component
        Player currentPlayer = GameObject.Find("Player" + player1_turn).GetComponent<Player>();

        // Remove the card from the board
        card.transform.SetParent(null);

        // Add the card to the player's taken cards pile
        currentPlayer.TakeCard(card);

        // Switch to the next player
        SwitchPlayer();
    }
}

}
*/