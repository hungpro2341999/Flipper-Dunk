﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float time;
    public bool isWait = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!isWait)
        StartCoroutine(WaitDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitDestroy()
    {
      
        yield return new WaitForSeconds(time);
        Destroy();
    }
    public void Destroy()
    {
        Ctrl_Spawn.Ins.ListItem.Remove(this.gameObject);
        Destroy(gameObject);
    }
}
