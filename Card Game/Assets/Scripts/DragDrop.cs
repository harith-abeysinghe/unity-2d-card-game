using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{
    public GameObject Canvas;
    private bool isDragging = false;
    private Vector2 startPosition;
    private GameObject currentBoard;
    private GameObject startParent;
    public int value;
    public int location = 0;  //1= player1, 2= board, 3= player2 
    public Image img;
    public bool OnBoard = false;
    public int[] last_temp;

    private Player_Class playerScript;
    public Player_Class player1;
    public Player_Class player2;

    public int player1PileLocation = 4; // Location for player 1's pile
    public int player2PileLocation = 5; // Location for player 2's pile




    private void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }
    void Update()
    {
      
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
            transform.SetParent(Canvas.transform, true);
        }
    }

    public void StartDrag()
    {
        if (OnBoard ==false) 
        {
            startParent = transform.parent.gameObject;
            startPosition = transform.position;
            isDragging = true;
    

        }

        if (OnBoard == true)
        {
            // Set the starting parent and position for the dragged card
            startParent = transform.parent.gameObject;
            startPosition = transform.position;
            isDragging = true;
        }

    }

    public void EndDrag()
    {
        transform.localScale = new Vector3(1, 1, 1);
        isDragging = false;

        if (currentBoard != null)
        {
            if (OnBoard && playerScript != null)
            {
                playerScript.TakeCard(gameObject); // Assuming the TakeCard method is implemented in PlayerClass
            }

            // Check if the card is being dropped onto a player's pile
            if (location == player1PileLocation && currentBoard.CompareTag("Player1Pile"))
            {
                // Call TakeCard on PlayerClass for player 1
                player1.TakeCard(gameObject);
            }
            else if (location == player2PileLocation && currentBoard.CompareTag("Player2Pile"))
            {
                // Call TakeCard on PlayerClass for player 2
                player2.TakeCard(gameObject);
            }

            transform.SetParent(currentBoard.transform, false);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (location == 1|| location == 2|| location == 3)
        {
            if (other.CompareTag("Board1"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[0];
                if (sum + value == 11 || sum==0 ||  sum + value == 22|| sum + value == 24|| sum +value == 26)
                {
                    currentBoard = other.gameObject;

                }

            }
            else if (other.CompareTag("Board2"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[1];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                }

            }
            else if (other.CompareTag("Board3"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[2];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;

                }
           


            }
            else if (other.CompareTag("Board4"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[3];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                }

            }
            else if (other.CompareTag("Board5"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[4];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                }
 
            }
            else if (other.CompareTag("Board6"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[5];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                }
   

            }
            else if (other.CompareTag("Board7"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[6];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                }
    
            }
            else if (other.CompareTag("Board8"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[7];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                }
      
            }
        }
     

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
