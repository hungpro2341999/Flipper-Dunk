﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_key : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            transform.parent = Ctrl_Spawn.Ins.TransGamePlay;

            GetComponent<BoxCollider2D>().enabled = false;
            gameObject.AddComponent<KeyMoveTo>();

        }
    }

}
