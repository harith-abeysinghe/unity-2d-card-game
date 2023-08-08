using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    bool isDragging = false;
    Vector2 startPosition;

    // Update is called once per frame
    void Update()
    {
        if(isDragging){
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void StartDrag(){
        startPosition = transform.position;
        isDragging = true;
    }

    public void StopDrag(){
        isDragging = false;

    }
}
