using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject Card1;
    public GameObject PlayerArea, OpponentArea, Board;
    float cardSpawnDelay = 1.0f;

    List <GameObject> cards = new List <GameObject> ();
    
    // Start is called before the first frame update
    void Start()
    {
        cards.Add(Card1);
        
    }

    public void OnClick()
    {
        StartCoroutine(SpawnCardsWithDelay());
    }

    private IEnumerator SpawnCardsWithDelay()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject playerCard = Instantiate(cards[0], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerArea.transform, false);

            
        }   
            yield return new WaitForSeconds(cardSpawnDelay);

        for (int i = 0; i < 2; i++)
        {
            GameObject boardCard = Instantiate(cards[0], new Vector3(0, 0, 0), Quaternion.identity);
            boardCard.transform.SetParent(Board.transform, false);

            
        }   
            yield return new WaitForSeconds(cardSpawnDelay);
        for (int i = 0; i < 2; i++){
            GameObject opponentCard = Instantiate(cards[0], new Vector3(0, 0, 0), Quaternion.identity);
            opponentCard.transform.SetParent(OpponentArea.transform, false);
            
            
        }
            yield return new WaitForSeconds(cardSpawnDelay);

    }

}
