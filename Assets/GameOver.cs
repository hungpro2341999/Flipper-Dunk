using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Image LoadBar;
    public float timeLoad;
    public float v;
    public float time;
    public bool isComplete = false;
    public float TimeLoad = 5;
    public Button Continue;
    // Start is called before the first frame update
    void Start()
    {
        v = Time.deltaTime / timeLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isComplete)
        {
            time += Time.deltaTime;
            if (time > timeLoad)
            {

                isComplete = true;
                ManagerAds.Ins.ShowInterstitial();
            }
            else
            {
                LoadBar.fillAmount += v;

            }
        }
      
      
    }
    private void OnDisable()
    {
        isComplete = false;
        LoadBar.fillAmount = 0;
       time = 0;
    }
    private void OnEnable()
    {
        if (CtrlGamePlay.CountPlayer % 2 == 0)
        {
            Continue.interactable = false;
        }
        else
        {
            Continue.interactable = true;
        }
        isComplete = false;
        LoadBar.fillAmount = 0;
        time = 0;
    }
}
