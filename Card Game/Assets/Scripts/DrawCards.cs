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
    private int drawCount = 0;

    public int player1_turn = 0;
    public GameObject[] backs;
    public bool clicked = false;
    public int all_cards;

    public  int[] cardCount =new int[4];  // count of the both players cards 
    public  int[] cardCount2 = new int[4];
    public  bool isDrawing = false;

    public GameObject img;

    public GameObject winSlot1;
    public GameObject winSlot2;

    public GameObject[] turns;
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
        for (int y = 0; y < 4; y++)  // for hide and show the cardDraw button
        {

            cardCount[y] = PlayerArea[y].transform.childCount;
            cardCount2[y] = OpponentArea[y].transform.childCount;
         
        }
        for(int y = 0; y < 8; y++)
        {
            if (Board[y].transform.childCount == 2 && sum[y] == 22)
            {
              
             
                for (int z = 0; z < 8; z++)
                {

                    if (player1_turn == 1)
                    {

                        if (Board[z].transform.childCount == 1)
                        {
                  
                            Board[z].transform.GetChild(0).transform.SetParent(winSlot1.transform, false);
                        }
                        else if(player1_turn == 2)
                        {
                            Board[z].transform.GetChild(1).transform.SetParent(winSlot1.transform, false);
                            Board[z].transform.GetChild(0).transform.SetParent(winSlot1.transform, false);
                        }
                        
                    }
                    else if (player1_turn == 2)
                    {
                        if (Board[z].transform.childCount == 1)
                        {

                            Board[z].transform.GetChild(0).transform.SetParent(winSlot2.transform, false);
                        }
                        else if (player1_turn == 2)
                        {
                            Board[z].transform.GetChild(1).transform.SetParent(winSlot2.transform, false);
                            Board[z].transform.GetChild(0).transform.SetParent(winSlot2.transform, false);
                        }
                     
                    }
                }
                if (player1_turn == 1)
                {
                    Board[y].transform.GetChild(1).transform.SetParent(winSlot1.transform, false);
                    Board[y].transform.GetChild(0).transform.SetParent(winSlot1.transform, false);
                }
                else if (player1_turn == 2)
                {
                    Board[y].transform.GetChild(1).transform.SetParent(winSlot2.transform, false);
                    Board[y].transform.GetChild(0).transform.SetParent(winSlot2.transform, false);
                }

            }
            else if (Board[y].transform.childCount == 2 && sum[y] == 11 )
            {
                if(Board[y].transform.GetChild(0).GetComponent<DragDrop>().value != Board[y].transform.GetChild(1).GetComponent<DragDrop>().value)
                {
                    print("11111");
                    if (player1_turn == 1)
                    {
                        Board[y].transform.GetChild(1).transform.SetParent(winSlot1.transform, false);
                        Board[y].transform.GetChild(0).transform.SetParent(winSlot1.transform, false);
                    }
                    else if (player1_turn == 2)
                    {
                        Board[y].transform.GetChild(1).transform.SetParent(winSlot2.transform, false);
                        Board[y].transform.GetChild(0).transform.SetParent(winSlot2.transform, false);
                    }
                }
                //StartCoroutine("delay");
               

            }
            else if(sum[y] == 11 && Board[y].transform.childCount == 3)
            {
                if (player1_turn == 1)
                {
                    Board[y].transform.GetChild(2).transform.SetParent(winSlot1.transform, false);
                    Board[y].transform.GetChild(1).transform.SetParent(winSlot1.transform, false);
                    Board[y].transform.GetChild(0).transform.SetParent(winSlot1.transform, false);
                }
                else if (player1_turn == 2)
                {
                    Board[y].transform.GetChild(2).transform.SetParent(winSlot2.transform, false);
                    Board[y].transform.GetChild(1).transform.SetParent(winSlot2.transform, false);
                    Board[y].transform.GetChild(0).transform.SetParent(winSlot2.transform, false);
                }

        
            }
           
            else if(Board[y].transform.childCount == 2 && sum[y] == 24)
            {
                if (player1_turn == 1)
                {
                    Board[y].transform.GetChild(1).transform.SetParent(winSlot1.transform, false);
                    Board[y].transform.GetChild(0).transform.SetParent(winSlot1.transform, false);
                }
                else if (player1_turn == 2)
                {
                    Board[y].transform.GetChild(1).transform.SetParent(winSlot2.transform, false);
                    Board[y].transform.GetChild(0).transform.SetParent(winSlot2.transform, false);
                }
        

            }
            else if(Board[y].transform.childCount == 2 && sum[y] == 26)
            {
                if (player1_turn == 1)
                {
                    Board[y].transform.GetChild(1).transform.SetParent(winSlot1.transform, false);
                    Board[y].transform.GetChild(0).transform.SetParent(winSlot1.transform, false);

                }
                else if (player1_turn == 2)
                {
                    Board[y].transform.GetChild(1).transform.SetParent(winSlot2.transform, false);
                    Board[y].transform.GetChild(0).transform.SetParent(winSlot2.transform, false);
                }
              
            }
          
        }

        if (isDrawing)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if ((cardCount2[0]== 0 && cardCount2[1] == 0 && cardCount2[2] == 0 && cardCount2[3] == 0 )|| (cardCount[0] == 0 && cardCount[1] == 0 && cardCount[2] == 0 && cardCount[3] == 0))
        {

            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
      

        for (int x=0; x < 8; x++)
        {
            if(Board[x].transform.childCount!=0)
            {
                if(Board[x].transform.childCount == 1)
                {
                    sum[x] = Board[x].transform.GetChild(0).GetComponent<DragDrop>().value;
                }

                else if (Board[x].transform.childCount == 2)
                {
                    sum[x] = Board[x].transform.GetChild(0).GetComponent<DragDrop>().value+ Board[x].transform.GetChild(1).GetComponent<DragDrop>().value;
                }
                else if (Board[x].transform.childCount == 3)
                {
                    sum[x] = Board[x].transform.GetChild(0).GetComponent<DragDrop>().value + Board[x].transform.GetChild(1).GetComponent<DragDrop>().value + Board[x].transform.GetChild(2).GetComponent<DragDrop>().value;
                }
            }
            else
            {
                sum[x] = 0;
            }
            //transform.SetParent(currentBoard.transform, false);
        }

    

        if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
            int current = OpponentArea[0].transform.childCount + OpponentArea[1].transform.childCount + OpponentArea[2].transform.childCount + OpponentArea[3].transform.childCount+ PlayerArea[0].transform.childCount + PlayerArea[1].transform.childCount + PlayerArea[2].transform.childCount + PlayerArea[3].transform.childCount;
            if (current < all_cards)
            {
                if (player1_turn == 1|| player1_turn == 0)
                {
                    player1_turn = 2;
                    GameObject.Find("Main Camera").GetComponent<Timer>().resetTime();
                    turns[1].SetActive(true);
                    turns[0].SetActive(false);
                }
                else if(player1_turn == 2|| player1_turn == 0)
                {
                    player1_turn = 1;
                    GameObject.Find("Main Camera").GetComponent<Timer>().resetTime();
                    turns[0].SetActive(true);
                    turns[1].SetActive(false);
                }
              
            }
           
            all_cards = current;
            //GameObject.Find("pack").GetComponent<DrawCards>().last[0] = value;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            all_cards = OpponentArea[0].transform.childCount + OpponentArea[1].transform.childCount + OpponentArea[2].transform.childCount + OpponentArea[3].transform.childCount + PlayerArea[0].transform.childCount + PlayerArea[1].transform.childCount + PlayerArea[2].transform.childCount + PlayerArea[3].transform.childCount; ;
           
            clicked = true;
        }
        if (player1_turn == 1)
        {
            backs[0].SetActive(false);
            backs[1].SetActive(true);
            
        }
        else if(player1_turn == 2)
        {
            backs[1].SetActive(false);
            backs[0].SetActive(true);
            //GameObject.Find("Main Camera").GetComponent<Timer>().resetTime();
        }
        else
        {
            backs[1].SetActive(false);
            backs[0].SetActive(false);
        }


       
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
        isDrawing = true;
        //gameObject.GetComponent<Button>().interactable = false;
        if (drawCount == 0)
        {
            StartCoroutine(SpawnCardsWithDelay());
        }
        else if (drawCount > 0)
        {
            StartCoroutine(SpawnCardsWithDelayType2());
        }
        drawCount++;
        
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
        player1_turn = 2;
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
            sum[i] = boardCard.GetComponent<DragDrop>().value;

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
        isDrawing = false;
        GameObject.Find("Main Camera").GetComponent<Timer>().resetTime();
        GameObject.Find("Main Camera").GetComponent<Timer>().start = true;
        turns[1].SetActive(true);
    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
    }
    private IEnumerator SpawnCardsWithDelayType2()  // only draw to players area
    {
        for (int i = 0; i < 4; i++)
        {
            int num = RandomGenerator();
            GameObject playerCard = Instantiate(cards[num], new Vector3(0, 0, 0), Quaternion.identity);


            playerCard.GetComponent<DragDrop>().location = 1;
            playerCard.transform.SetParent(PlayerArea[i].transform, false);
            MergeSprites(num, playerCard);
        }
        player1_turn = 2;
        yield return new WaitForSeconds(cardSpawnDelay);

   

        for (int i = 0; i < 4; i++)
        {
            int num = RandomGenerator();
            GameObject opponentCard = Instantiate(cards[num], new Vector3(0, 0, 0), Quaternion.identity);
            opponentCard.GetComponent<DragDrop>().location = 3;
            opponentCard.transform.SetParent(OpponentArea[i].transform, false);

            MergeSprites(num, opponentCard);

        }
        yield return new WaitForSeconds(cardSpawnDelay);
        isDrawing = false;
     
    }

}
