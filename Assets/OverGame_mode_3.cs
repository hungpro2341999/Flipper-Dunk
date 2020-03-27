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
        Ctrl_Player.Ins.AddDiamond(Ctrl_Player.DiamondInPlayer);
        CtrlGamePlay.Ins.OverMode_3();
        Ctrl_Player.Ins.ProcessAddConin(ImgDiamond.transform.position, transform);
        if (CtrlGamePlay.CountPlayer % 2 == 0)
        {
            Continue.interactable = false;
        }
        else
        {
            Continue.interactable = true;
        }
    }
}
