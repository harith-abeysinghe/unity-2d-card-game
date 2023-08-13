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

    public GameObject player1Pile; // Assign the player 1's pile GameObject in the Inspector
    public GameObject player2Pile; // Assign the player 2's pile GameObject in the Inspector




    private void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }
    private void Start()
    {
        player1 = GameObject.Find("player1 (2)").GetComponent<Player_Class>();
        player2 = GameObject.Find("player1").GetComponent<Player_Class>();
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
            print(currentBoard.tag + " " +currentBoard.transform.childCount);
            

            // Check if the sum is valid and move the cards to player pile if needed
            int boardIndex = GetBoardIndexFromTag(currentBoard.tag);
            int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[boardIndex];
            if (IsValidSum(sum))
            {
                print(boardIndex);
                Transform[] childTransforms = currentBoard.GetComponentsInChildren<Transform>();
                foreach (Transform childTransform in childTransforms)
                {
                    DragDrop childDragDrop = childTransform.GetComponent<DragDrop>();
                    if (childDragDrop != null)
                    {
                        if (location == 1)
                        {
                            player1.TakeCard(childDragDrop.gameObject);
                        }
                        else if (location == 3)
                        {
                            player2.TakeCard(childDragDrop.gameObject);
                        }
                    }
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
        print("In Trigger Method");
       
        if (location == 1|| location == 2|| location == 3)
        {
            if (other.CompareTag("Board1"))
            {
                currentBoard = other.gameObject;
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[GetBoardIndexFromTag(currentBoard.tag)];
                if (IsValidSum(sum))
                {
                    
                    print("Sum for Board1: " + sum);
                }
            }
            else if (other.CompareTag("Board2"))
            {
                currentBoard = other.gameObject;
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[GetBoardIndexFromTag(currentBoard.tag)];
                if (IsValidSum(sum))
                {
                    
                    print("Sum for Board2: " + sum);
                }
            }
            else if (other.CompareTag("Board3"))
            {
                currentBoard = other.gameObject;
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[GetBoardIndexFromTag(currentBoard.tag)];
                if (IsValidSum(sum))
                {
                    
                    print("Sum for Board3: " + sum);
                }
            }
            else if (other.CompareTag("Board4"))
            {
                    currentBoard = other.gameObject;
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[GetBoardIndexFromTag(currentBoard.tag)];
                if (IsValidSum(sum))
                {
                    print("Sum for Board4: " + sum);
                }

            }
            else if (other.CompareTag("Board5"))
            {
                currentBoard = other.gameObject;
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[GetBoardIndexFromTag(currentBoard.tag)];
                if (IsValidSum(sum))
                {
                    
                    print("Sum for Board5: " + sum);
                }
 
            }
            else if (other.CompareTag("Board6"))
            {
                currentBoard = other.gameObject;
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[GetBoardIndexFromTag(currentBoard.tag)];
                if (IsValidSum(sum))
                {
                    
                    print("Sum for Board6: " + sum);
                }
   

            }
            else if (other.CompareTag("Board7"))
            {
                currentBoard = other.gameObject;
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[GetBoardIndexFromTag(currentBoard.tag)];
                if (IsValidSum(sum))
                {
                    
                    print("Sum for Board7: " + sum);
                }
    
            }
            else if (other.CompareTag("Board8"))
            {
                currentBoard = other.gameObject;
                int sum = GameObject.Find("pack").GetComponent<DrawCards>().sum[GetBoardIndexFromTag(currentBoard.tag)];
                if (IsValidSum(sum))
                {
                    
                    print("Sum for Board8: " + sum);
                }
            }



            
        }
        
        


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }

    private bool IsValidSum(int sum)
    {
        int childCount = currentBoard.transform.childCount;

        if (sum == 11 && childCount > 1)
        {
            return true;
        }
        else if ((sum == 22 || sum == 24 || sum == 26) && value == (sum/2))
        {
            return childCount == 2;
        }

        return false;
    }



    private int GetBoardIndexFromTag(string tag)
    {
        if (tag == "Board1") return 0;
        if (tag == "Board2") return 1;
        if (tag == "Board3") return 2;
        if (tag == "Board4") return 3;
        if (tag == "Board5") return 4;
        if (tag == "Board6") return 5;
        if (tag == "Board7") return 6;
        if (tag == "Board8") return 7;

        return -1; // Invalid tag
    }

}
