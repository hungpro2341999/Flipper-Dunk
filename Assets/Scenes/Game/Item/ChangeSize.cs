using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
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
        if (collision.gameObject.layer == 8)
        {
            Ctrl_Spawn.Ins.ListItem.Remove(this.gameObject);
            Ctrl_Spawn.Ins.Add_Counter_PowerUp(item);
            CtrlGamePlay.Ins.ChangeSizeBasket();
            GetComponent<DestroySelf>().Destroy();

        }
    }
    

}
