using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Class : MonoBehaviour
{
    public List<GameObject> takenCards = new List<GameObject>();
    public GameObject player1CardPile;
    public GameObject player2CardPile;


    private void Start()
    {
        player1CardPile = GameObject.Find("Player1Pile");
        player2CardPile = GameObject.Find("Player2Pile");
    }
    public void TakeCard(GameObject cardPrefab, int location)
    {
        GameObject newCard;
        if (location == 1)
        {
            newCard = Instantiate(cardPrefab, player2CardPile.transform);
        }
        else if (location == 3)
        {
            newCard = Instantiate(cardPrefab, player1CardPile.transform);
        }
        else
        {
            return; // Invalid location
        }

        // Any additional setup for the new card, such as positioning or scaling, can be done here
        takenCards.Add(newCard);
    }
}
