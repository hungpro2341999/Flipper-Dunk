using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public string audioName="";
    public float time;
    public bool isWait = false;
    public GameObject EFF;
    // Start is called before the first frame update
    void Start()
    {
        if(!isWait)
        StartCoroutine(WaitDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitDestroy()
    {
      
        yield return new WaitForSeconds(time);
        Destroy();
    }
    public void Destroy()
    {
        if (audioName != "")
        {
            CtrlAudio.Ins.Play(audioName);
        }

        if (EFF != null)
        {
            EFF.gameObject.SetActive(true);
            EFF.gameObject.transform.parent = null;
        }
        Ctrl_Spawn.Ins.ListItem.Remove(this.gameObject);
        Destroy(gameObject);
       
    }
    public void DestroyNormal()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
