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
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        transform.localScale = new Vector3(1, 1, 1);
        isDragging = false;

        if (currentBoard != null)
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
                currentBoard = other.gameObject;
                GameObject.Find("pack").GetComponent<DrawCards>().sum[0] += value;
                GameObject.Find("pack").GetComponent<DrawCards>().last[0] = value;
            }
            else if (other.CompareTag("Board2"))
            {
                currentBoard = other.gameObject;
                GameObject.Find("pack").GetComponent<DrawCards>().sum[1] += value;
                GameObject.Find("pack").GetComponent<DrawCards>().last[1] = value;
            }
            else if (other.CompareTag("Board3"))
            {
                currentBoard = other.gameObject;
                GameObject.Find("pack").GetComponent<DrawCards>().sum[2] += value;
                GameObject.Find("pack").GetComponent<DrawCards>().last[2] = value;
            }
            else if (other.CompareTag("Board4"))
            {
                currentBoard = other.gameObject;
                GameObject.Find("pack").GetComponent<DrawCards>().sum[3] += value;
                GameObject.Find("pack").GetComponent<DrawCards>().last[3] = value;
            }
        }
     

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Board1"))
        {
            currentBoard = null;
            GameObject.Find("pack").GetComponent<DrawCards>().sum[0] -= value;
        }
        else if (other.CompareTag("Board2"))
        {
            currentBoard = null;
            GameObject.Find("pack").GetComponent<DrawCards>().sum[1] -= value;
        }
        else if (other.CompareTag("Board3"))
        {
            currentBoard = null;
            GameObject.Find("pack").GetComponent<DrawCards>().sum[2] -= value;
        }
        else if (other.CompareTag("Board4"))
        {
            currentBoard = null;
            GameObject.Find("pack").GetComponent<DrawCards>().sum[3] -= value;
        }
    }
}
