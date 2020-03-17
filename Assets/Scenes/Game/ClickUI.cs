using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickUI : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public static bool isButtonDown = false;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        isButtonDown = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        isButtonDown = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
