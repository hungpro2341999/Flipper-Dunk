using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Diamond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(GameMananger.PosDiamond, 0.6f).OnComplete(()=>{

            GetComponent<DestroySelf>().Destroy();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
