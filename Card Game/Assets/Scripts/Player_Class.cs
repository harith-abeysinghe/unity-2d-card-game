using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Class : MonoBehaviour
{
    public List<GameObject> takenCards = new List<GameObject>();

    public void TakeCard(GameObject card)
    {
        takenCards.Add(card);
    }
}
