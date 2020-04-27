using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverGame_mode_3 : MonoBehaviour
{
    public Text BestScore;
    public Text Score;
    public Text Dimond;
    public Image ImgDiamond;
    public Button Continue;
    public Button X3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {


        Ctrl_Player.Ins.SetHighScore(CtrlGamePlay.Ins.ScorePlayer);
        Score.text = CtrlGamePlay.Ins.ScorePlayer.ToString();
        BestScore.text = "BEST :" + Ctrl_Player.Ins.GetHighScore().ToString();
        Dimond.text = Ctrl_Player.DiamondInPlayer.ToString();
        
        CtrlGamePlay.Ins.OverMode_3();
        if (Ctrl_Player.DiamondInPlayer != 0)
        {
            // Ctrl_Player.Ins.ProcessAddConin(ImgDiamond.transform.position, transform, 1, Ctrl_Player.DiamondInPlayer);
            Ctrl_Player.DiamondInPlayer = 0;
        }

     
        if (CtrlGamePlay.CountPlayer % 2 == 0)
        {
            Continue.interactable = false;
        }
        else
        {
            Continue.interactable = true;
        }
        X3.interactable = true;

        Setting.Ins.OpenSetting(false);
    }

    public void X3Diamond()
    {
        ManagerAds.Ins.ShowRewardedVideo((show) =>
        {
            if (show)
            {
                int diamond = Ctrl_Player.DiamondInPlayer;
                diamond = diamond * 3;

               
                Ctrl_Player.Ins.ProcessAddConin(ImgDiamond.transform.position, transform,0,diamond);
                X3.interactable = false;
            }


        });

    }
}
