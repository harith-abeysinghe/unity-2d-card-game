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
      
    }

    public void EndDrag()
    {
        transform.localScale = new Vector3(1, 1, 1);
        isDragging = false;

        if (currentBoard != null )
        {
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
