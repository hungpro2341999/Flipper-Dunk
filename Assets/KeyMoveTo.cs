using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class KeyMoveTo : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
      
        transform.DOMove(Ctrl_Spawn.Ins.GetAppendKey(),0.5f).OnComplete(() =>
        {

            Active();

        }
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Active()
    {
       // Ctrl_Player.Ins.SaveNextKey();
        Ctrl_Spawn.Ins.UnclockKey();
       
          
          
       
        Destroy(gameObject);
    }
}
