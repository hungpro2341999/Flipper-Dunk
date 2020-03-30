using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Anim_Pop_pup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       var a =   transform.DOScale(Vector3.one * 1.2f, 0.25f).OnComplete(() =>
        {

            transform.DOScale(Vector3.one, 0.25f).SetLoops(-1);
        });
        
    }

   
}
