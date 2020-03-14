using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_level : MonoBehaviour
{
    public static Ctrl_level Ins;
   
    private void Awake()
    {
        if (Ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Ins = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel()
    {


    }
}
