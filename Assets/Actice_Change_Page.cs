using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Actice_Change_Page : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public int id;

    public void OnPointerDown(PointerEventData eventData)
    {
       
     //   CtrlShop.Ins.InitPoint(eventData.position);
         
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      //  CtrlShop.Ins.isChangePage = false;
    }
}
