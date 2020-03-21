﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectFlipper : MonoBehaviour
{
    public static Vector3 Direct;

    public Transform Pos1;
    public Transform Pos2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ball.Ins.ForceInit)
        {
            Vector3 Surface = (Pos1.position - Pos2.position).normalized;
            //    Surface = new Vector3(Mathf.Abs(Surface.x), Surface.y);
            Direct = new Vector2(-Surface.y, Surface.x);
            Direct = Surface.normalized;
        }
        else
        {
            Vector3 Surface = (Pos2.position - Pos1.position).normalized;
            Direct = Surface;

        }
      
       
        //Direct = (Pos1.position - Pos2.position).normalized;
     //   Debug.Log(Direct.x + "  " + Direct.y);
    }

    private void OnDrawGizmos()
    {
        Vector3 Surface = (Pos1.position - Pos2.position).normalized;
        //Direct = new Vector2(-Surface.y, Surface.x);
        // Vector3 Surface = (Pos1.position - Pos2.position).normalized;
        Direct = Surface;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Direct * 10);
    }
}
