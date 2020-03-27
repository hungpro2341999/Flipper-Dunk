using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public static Setting Ins;
    public Image OffSound;
    public Image OffVariabe;
    public bool isOpen = false;
    public Animator AnimSetting;
    // Start is called before the first frame update
    void Start()
    {
        if (Ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Ins = this;
        }
        SetUpSound();
        SetUpVariable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpSound()
    {
      bool active =  Ctrl_Player.Ins.isSound();

        if (active)
        {
            OffSound.enabled = false;

        }
        else
        {
            OffSound.enabled = true;

        }
    }
    public void SetUpVariable()
    {
        bool active = Ctrl_Player.Ins.isVariable();
        if (active)
        {
            OffVariabe.enabled = false;

        }
        else
        {
            OffVariabe.enabled = true;

        }
    }
    public void OpenSetting()
    {
        isOpen = !isOpen;
        AnimSetting.SetBool("Open", isOpen);

    }
}
