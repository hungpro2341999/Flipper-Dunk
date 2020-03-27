using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreReflect : MonoBehaviour
{
    public TypeItem item;
    private void Start()
    {
        string a;
        CtrlAudio.Ins.Play("SpawnPower");

    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Ctrl_Spawn.Ins.ListItem.Remove(gameObject);
            Ctrl_Spawn.Ins.Add_Counter_PowerUp(item);
            CtrlGamePlay.Ins.StartIncreReflect();
            GetComponent<DestroySelf>().Destroy();
            Ctrl_Spawn.Ins.SpawnEff(1, transform.position, Ctrl_Spawn.Ins.TransGamePlay);
        }
    }
   
}
