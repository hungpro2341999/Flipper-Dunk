using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot : MonoBehaviour
{
    public Image ActiveDot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Active()
    {

        ActiveDot.enabled = true;

    }

    public void UnActive()
    {
        ActiveDot.enabled = false;
    }
}
