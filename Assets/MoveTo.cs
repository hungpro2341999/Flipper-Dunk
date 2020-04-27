using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Transform Trans;
    public Active_key Active;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!Active.active)
        {
            //Vector3 pos = transform.position;
            //transform.position = Trans.transform.position;


            //transform.position = pos; 
        }
           
    }
}
