﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameEvent : MonoBehaviour
{

     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            StartCoroutine(ResetGame());
        }
    }
    public IEnumerator ResetGame()
    {
        yield return new  WaitForSeconds(0);
       StartCoroutine(CtrlGamePlay.Ins.ShadowScreen());

    }
}
