using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Player : MonoBehaviour
{


    public static Ctrl_Player Ins;

    public static int ScorePlayer = 0;

    public int Live = 0;
    // Start is called before the first frame update
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
