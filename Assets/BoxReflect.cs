﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReflect : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Ball.Ins.ReflectDirect();
        }
    }

}
