using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HomeWindown : MonoBehaviour
{
    bool Open = false;
    public Animator AnimSetting;
    public Text T_Level;
    public Text T_Score;
    public Image BestScore;
    // Start is called before the first frame update
    void Start()
    {
        T_Level.text = "Level " + Ctrl_Player.Ins.GetCurrLevel().ToString();
        CtrlGamePlay.Ins.eventForLoadGame += Load;

        Load(Ctrl_Player.Ins.GetHighScore(), Ctrl_Player.Ins.GetCurrLevel());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveSetting()
    {
        Open = !Open;
        AnimSetting.SetBool("Open",Open);
       
    }
    public void Load(int Score,int level)
    {
        T_Level.text = "Level "+level.ToString();
        if (Score<=0)
        {
            BestScore.gameObject.SetActive(false);

        }
        else
        {
            BestScore.gameObject.SetActive(true);
            T_Score.text = Score.ToString();
        }

    }
   

   
}
