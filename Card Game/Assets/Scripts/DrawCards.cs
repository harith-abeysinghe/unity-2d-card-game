using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrawCards : MonoBehaviour
{
    public GameObject[] card4tpes;
    public GameObject[] PlayerArea, OpponentArea, Board;
    public Sprite[] clubs, diamonds, hearts, spades;
    float cardSpawnDelay = 1.0f;

    public int[] sum ;
    public int[] last;
    //public GameObject[] slot1, slot2, slot3, slot4;
    public List<int> _clubs, _diamonds, _hearts, _spades;  // all shared cards
    List <GameObject> cards = new List <GameObject> ();
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
       
        foreach(GameObject x in card4tpes)
        {
            cards.Add(x);
        }

    }

    private void Update()
    {
      
    }
    public void MergeSprites(int _num, GameObject card)
    {
        int y = Random.RandomRange(0, 13);

        if(_num == 0)
        {
            if (_clubs.Contains(y) == true)
            {
                MergeSprites(_num, card);
            }
            else
            {
                _clubs.Add(y);
                card.GetComponent<Image>().sprite = clubs[y];
                card.GetComponent<DragDrop>().value = y+1;
            }
        }

        else if (_num == 1)
        {
            if (_diamonds.Contains(y) == true)
            {
                MergeSprites(_num, card);
            }
            else
            {
                _diamonds.Add(y);
                card.GetComponent<Image>().sprite = diamonds[y];
                card.GetComponent<DragDrop>().value = y + 1;
            }
        }
        else if (_num == 2)
        {
            if (_hearts.Contains(y) == true)
            {
                MergeSprites(_num, card);
            }
            else
            {
                _hearts.Add(y);
                card.GetComponent<Image>().sprite = hearts[y];
                card.GetComponent<DragDrop>().value = y + 1;
            }
        }
        else if (_num == 3)
        {
            if (_spades.Contains(y) == true)
            {
                MergeSprites(_num, card);
            }
            else
            {
                _spades.Add(y);
                card.GetComponent<Image>().sprite = spades[y];
                card.GetComponent<DragDrop>().value = y + 1;
            }
        }

    }
    public void OnClick()
    {
        StartCoroutine(SpawnCardsWithDelay());
    }
    private int RandomGenerator()
    {
        int x = Random.Range(0, 4);
        return x;
    }
    private IEnumerator SpawnCardsWithDelay()
    {
        for (int i = 0; i < 4; i++)
        {
            int num = RandomGenerator();
            GameObject playerCard = Instantiate(cards[num], new Vector3(0, 0, 0), Quaternion.identity);
    
            
            playerCard.GetComponent<DragDrop>().location = 1;
            playerCard.transform.SetParent(PlayerArea[i].transform, false);
            MergeSprites(num, playerCard);
        }
        yield return new WaitForSeconds(cardSpawnDelay);

        for (int i = 0; i < 4; i++)
        {
            int num = RandomGenerator();
            GameObject boardCard = Instantiate(cards[num], gameObject.transform.position, Quaternion.identity);
            boardCard.GetComponent<DragDrop>().location = 2;
            boardCard.transform.SetParent(Board[i].transform, false);
            //boardCard.transform.position = Vector3.MoveTowards(transform.position, Board[i].transform.position, speed * Time.deltaTime);
            
            MergeSprites(num, boardCard);
            //last[i] = boardCard.GetComponent<DragDrop>().value;
            //sum[i] = boardCard.GetComponent<DragDrop>().value;

        }   
        yield return new WaitForSeconds(cardSpawnDelay);
        for (int i = 0; i < 4; i++){
            int num = RandomGenerator();
            GameObject opponentCard = Instantiate(cards[num], new Vector3(0, 0, 0), Quaternion.identity);
            opponentCard.GetComponent<DragDrop>().location = 3;
            opponentCard.transform.SetParent(OpponentArea[i].transform, false);

            MergeSprites(num, opponentCard);

        }
        yield return new WaitForSeconds(cardSpawnDelay);

    }

}
