using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Eff_Pup_Pop : MonoBehaviour
{
    public float Target_pop_pup;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(Vector3.one*1.2f,1).OnComplete(()=>
            
            
        {
            transform.DOScale(Vector3.one, 1);
        }
        
        ).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
