﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreLive : MonoBehaviour
{
    public TypeItem item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            CtrlGamePlay.Ins.live++;
            Ctrl_Spawn.Ins.ListItem.Remove(this.gameObject);
            GetComponent<DestroySelf>().Destroy();
        }
    }
}
