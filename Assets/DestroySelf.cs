using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy();
    }
    public void Destroy()
    {

        Destroy(gameObject);
    }
}
