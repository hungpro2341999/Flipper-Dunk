using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
  
    public string key;
   
    public CheckInBall Check_In_Ball;


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.layer == 8)
        {
            Check_In_Ball.SetKey(key);
            Debug.Log(key);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(key);
        if (collision.gameObject.layer == 8)
            Check_In_Ball.ResetKey(key);
    }





}






