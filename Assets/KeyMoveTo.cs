using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class KeyMoveTo : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(Ctrl_Spawn.Ins.GetAppendKey(),1).OnComplete(() =>
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
        Ctrl_Spawn.Ins.isUnclockReward();
        Ctrl_Player.Ins.SaveNextKey();
        Destroy(gameObject);
    }
}
