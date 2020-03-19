using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Image CounterTime;
    public float time;
    private float v;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        v =  (Time.deltaTime)/time;
        CounterTime.fillAmount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (t<time)
        {
            t += Time.deltaTime;
            CounterTime.fillAmount += v;
            if (t >= time)
            {
                Ctrl_Spawn.Ins.ListCounterItem.Remove(this);
                GetComponent<DestroySelf>().Destroy();
            }
        }
      
     
    }
}
