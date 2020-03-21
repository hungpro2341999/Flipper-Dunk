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
        Ctrl_Player.Ins.SaveNextKey();
        Ctrl_Spawn.Ins.UnclockKey();
        if (Ctrl_Player.Ins.GetCurrKey()!=0 && Ctrl_Player.Ins.GetCurrKey() % 3 == 0)
        {
            Ctrl_Player.Ins.ResetKey();
            GameMananger.Ins.OpenWindow(TypeWindow.Reward);
        }
        else
        {

           
        }
        Destroy(gameObject);
    }
}
