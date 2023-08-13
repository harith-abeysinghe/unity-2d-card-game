using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public GameObject player1Pile; // Assign the player 1's pile GameObject in the Inspector
    public GameObject player2Pile; // Assign the player 2's pile GameObject in the Inspector




    private void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }
    private void Start()
    {
        player1 = GameObject.Find("Player1Pile").GetComponent<Player_Class>();
        player2 = GameObject.Find("Player2Pile").GetComponent<Player_Class>();
        player1Pile = GameObject.Find("Player1Pile");
        player2Pile = GameObject.Find("Player2Pile");
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
        /*
        for (int i = 0; i < 8; i++)
        {
            int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[i];
            if (sum == 11)
            {
                if (location == 1)
                {
                    player1.TakeCard(gameObject);
                }
                else if (location == 3)
                {
                    player2.TakeCard(gameObject);
                }
            }
        }
        */
    }

    public void StartDrag()
    {
        if (OnBoard ==false) 
        {
            startParent = transform.parent.gameObject;
            startPosition = transform.position;
            isDragging = true;
    

        }
        /*
        if (OnBoard == true)
        {
            // Set the starting parent and position for the dragged card
            startParent = transform.parent.gameObject;
            startPosition = transform.position;
            isDragging = true;
        }
        */

    }

    public void EndDrag()
    {
        transform.localScale = new Vector3(1, 1, 1);
        isDragging = false;

        if (currentBoard != null)
        {
            if (OnBoard && playerScript != null)
            {
                playerScript.TakeCard(gameObject);
            }

            if (location == 2) // Board location
            {
                if (currentBoard.CompareTag("Player1Pile") && player1 != null)
                {
                    player1.TakeCard(gameObject);
                }
                else if (currentBoard.CompareTag("Player2Pile") && player2 != null)
                {
                    player2.TakeCard(gameObject);
                }
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
                    Debug.Log("Sum for Board1: " + sum);

                }

            }
            else if (other.CompareTag("Board2"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[1];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                    Debug.Log("Sum for Board2: " + sum);
                }

            }
            else if (other.CompareTag("Board3"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[2];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                    Debug.Log("Sum for Board3: " + sum);

                }
           


            }
            else if (other.CompareTag("Board4"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[3];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                    Debug.Log("Sum for Board4: " + sum);
                }

            }
            else if (other.CompareTag("Board5"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[4];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                    Debug.Log("Sum for Board5: " + sum);
                }
 
            }
            else if (other.CompareTag("Board6"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[5];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                    Debug.Log("Sum for Board6: " + sum);
                }
   

            }
            else if (other.CompareTag("Board7"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[6];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                    Debug.Log("Sum for Board7: " + sum);
                }
    
            }
            else if (other.CompareTag("Board8"))
            {
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[7];
                if (sum + value == 11 || sum == 0 || sum + value == 22 || sum + value == 24 || sum + value == 26)
                {
                    currentBoard = other.gameObject;
                    Debug.Log("Sum for Board8: " + sum);
                }
            }



            
        }
        
        


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }

   
}
