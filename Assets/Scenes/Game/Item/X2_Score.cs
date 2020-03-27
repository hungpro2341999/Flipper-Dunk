using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X2_Score : MonoBehaviour
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
        if (collision.gameObject.layer == 8)
        {
            Ctrl_Spawn.Ins.ListItem.Remove(this.gameObject);
            Ctrl_Spawn.Ins.Add_Counter_PowerUp(item);
            CtrlGamePlay.Ins.X2_Score();
            GetComponent<DestroySelf>().Destroy();
            Ctrl_Spawn.Ins.SpawnEff(1, transform.position, Ctrl_Spawn.Ins.TransGamePlay);
        }
    }
}
