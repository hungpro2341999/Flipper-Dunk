using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

public class ActiveBall : MonoBehaviour
{
    public int Sort;
    public const float time = 60;
    public string Key;
    public Text CountTime;
    public Button ButtonHandle;
    public Transform Loading;
    public float t;
    

    // Start is called before the first frame update
    void Start()
    {
        
        if (ButtonHandle == null)
            ButtonHandle = GetComponentInParent<Button>();
        if (!PlayerPrefs.HasKey(Key))
        {
            PlayerPrefs.SetFloat(Key,Time.time);
            PlayerPrefs.Save();
            ButtonHandle.interactable = true;
        }
        switch (Sort)
        {
            case 1:
                CtrlShop.Ins.eventlockBall += SeTTimeForNext;
                break;
            case 2:
                CtrlShop.Ins.eventlockFLipper += SeTTimeForNext;
                break;
            case 3:
                CtrlShop.Ins.eventlockBG += SeTTimeForNext;
                break;
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        float timeActive = PlayerPrefs.GetFloat(Key) - (System.DateTime.Now.Second + System.DateTime.Now.Minute * 60 + System.DateTime.Now.Hour * 60*60);
        if (timeActive<=0)
        {
            Debug.Log("Active");
            ButtonHandle.interactable = true;
            CountTime.gameObject.SetActive(false);
            Loading.gameObject.SetActive(false);
        }
        else
        {
            Loading.gameObject.SetActive(true);
            Loading.Rotate(new Vector3(0, 0,-Time.deltaTime*100));
            CountTime.gameObject.SetActive(true);
            CountTime.text =(timeActive).ToString();
            ButtonHandle.interactable = false;
        
            Debug.Log("Not Active");

        }



    }

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey(Key))
        {
            PlayerPrefs.SetFloat(Key, Time.time);
            PlayerPrefs.Save();
            if (ButtonHandle == null)
                ButtonHandle = GetComponentInParent<Button>();
             ButtonHandle.interactable = true;
        }
       
       
    }

    public void SeTTimeForNext()
    {
         
           float timenext = (System.DateTime.Now.Second + System.DateTime.Now.Minute*60 + System.DateTime.Now.Hour*60*60) +time;
            PlayerPrefs.SetFloat(Key,timenext);
            PlayerPrefs.Save();
            ButtonHandle.interactable = false;
        
    }
}
