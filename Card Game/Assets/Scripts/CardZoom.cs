using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    private GameObject zoomCard;

    public void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    public void OnHoverEnter()
    {
        Vector2 zoomPosition = new Vector2(150, 230);
        
        zoomCard = Instantiate(gameObject, zoomPosition, Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);

        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(75, 105);
    }

    public void OnHoverExit()
    { 
        Destroy(zoomCard);
    }
}
