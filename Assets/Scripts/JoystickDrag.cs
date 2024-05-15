using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public bool isDragging = false;
    public PlayerControl PlayerCtrl;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }
    

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging == true)
        {
            transform.position = eventData.position;
            //SetLimit();
        }
    }

    
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
        isDragging = false;
    }

    private void Update()
    {
        //SetLimit();
        Control();
    }

    void SetLimit()
    {
        float distance = Mathf.Sqrt(Mathf.Pow(transform.localPosition.x, 2) + Mathf.Pow(transform.localPosition.y, 2));
        if (distance >= 8)
        {
            isDragging = false;
        }
    }

    void Control()
    {
        if (transform.localPosition.y == 0)
        {
            PlayerCtrl.Move = 0;
        }
        else if(transform.localPosition.y > 0 && transform.localPosition.y <= 6)
        {
            PlayerCtrl.Move = 1;
            PlayerCtrl.CanAccelerate = false;
        }
        else if (transform.localPosition.y > 6)
        {
            PlayerCtrl.Move = 1;
            PlayerCtrl.CanAccelerate = true;
        }
        else if (transform.localPosition.y < 0 && transform.localPosition.y >= -6)
        {
            PlayerCtrl.Move = -0.25f;
        }
        else if (transform.localPosition.y < -6)
        {
            PlayerCtrl.Move = -1;
        }

        PlayerCtrl.Rotate = (transform.localPosition.x / 8f);
        if (transform.localPosition.x >= 8)
        {
            PlayerCtrl.Rotate = 1;
        }
        else if (transform.localPosition.x <= -8)
        {
            PlayerCtrl.Rotate = -1;
        }
        else if (Mathf.Abs(transform.localPosition.x) <= 4)
        {
            PlayerCtrl.rotateSpeed = 90;
        }
        else if (Mathf.Abs(transform.localPosition.x) > 4)
        {
            PlayerCtrl.rotateSpeed = 120;
        }

    }

    
}
