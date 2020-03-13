using System.Collections;
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
        //Vector3 Surface = (Pos1.position - Pos2.position).normalized;
        //Direct = new Vector2(-Surface.y, Surface.x);
        Direct = (Pos1.position - Pos2.position).normalized;
    }

    private void OnDrawGizmos()
    {
        //Vector3 Surface = (Pos1.position - Pos2.position).normalized;
        //Direct = new Vector2(-Surface.y, Surface.x);
        Vector3 Surface = (Pos1.position - Pos2.position).normalized;
        Direct = Surface;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Direct * 10);
    }
}
