using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreLive : MonoBehaviour
{
    public TypeItem item;
    // Start is called before the first frame update
    void Start()
    {
        CtrlAudio.Ins.Play("SpawnPower");
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
         
            Ctrl_Spawn.Ins.SpawnEff(1, transform.position, Ctrl_Spawn.Ins.TransGamePlay);
            CtrlAudio.Ins.Play("Pum");
            Destroy(gameObject);
        }
    }
}
