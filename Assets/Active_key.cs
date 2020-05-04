using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_key : MonoBehaviour
{
    public bool active = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            active = true;
          //  CtrlGamePlay.Ins.key_in_Game+=1;
            Ctrl_Player.Ins.AddKey(1);
            CtrlAudio.Ins.Play("KeyCollect");
          
            transform.parent = Ctrl_Spawn.Ins.TransGamePlay;

            GetComponent<BoxCollider2D>().enabled = false;
            gameObject.AddComponent<KeyMoveTo>();

        }
    }

}
