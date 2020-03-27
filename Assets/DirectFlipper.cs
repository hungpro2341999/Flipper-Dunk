using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectFlipper : MonoBehaviour
{
    public static Vector3 Direct;

    public Transform Pos1;
    public Transform Pos2;
    public Transform Pos3;

    public static float Angle;
    public float PosInit;


    public Vector3 InitAngle;
    // Start is called before the first frame update
    void Start()
    {
        InitAngle = (Pos3.position - Pos1.position).normalized;
        PosInit = Pos3.position.y;

    }

    // Update is called once per frame
    void Update()
    {
       
            Vector3 Surface = (Pos2.position - Pos1.position).normalized;
            //    Surface = new Vector3(Mathf.Abs(Surface.x), Surface.y);
            Direct = new Vector2(-Surface.y, Surface.x);
            Direct = Surface.normalized;
       
       
       

        int i = 0;

        if (PosInit < Pos3.transform.position.y)
        {
            i = 1;
        }
        else
        {
            i = -1;
        }

        Angle = Vector3.Angle(InitAngle, (Pos3.position - Pos1.position).normalized) * i;



        //Direct = (Pos1.position - Pos2.position).normalized;
        //   Debug.Log(Direct.x + "  " + Direct.y);
    }

    private void OnDrawGizmos()
    {
        Vector3 Surface = (Pos2.position - Pos1.position).normalized;
        Direct = new Vector2(-Surface.y, Surface.x);
        // Vector3 Surface = (Pos1.position - Pos2.position).normalized;
        Direct = Surface;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Direct * 10);
    }
}
