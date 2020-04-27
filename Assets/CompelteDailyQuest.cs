using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompelteDailyQuest : MonoBehaviour
{
    public Text T_Diamond;
   
    public Transform Diamond;

    public Button Ads;

    public Button X3;
    private void OnEnable()
    {

        if (Ctrl_Player.DiamondInPlayer!=0)
        {


            Ads.interactable = true;
           
        }
        else
        {
            Ads.interactable = false;
        }
        if (Ctrl_Player.DiamondInPlayer != 0)
        {
            Ctrl_Player.DiamondInPlayer = 100;
            Ctrl_Player.Ins.ProcessAddConin(Diamond.position, transform, 1, Ctrl_Player.DiamondInPlayer);
            T_Diamond.text = Ctrl_Player.DiamondInPlayer.ToString();
        }
        X3.interactable = true;
    }
      
    public void X3Diamond()
    {
        ManagerAds.Ins.ShowRewardedVideo((show) =>
        {
            if (show)
            {
                int diamond = Ctrl_Player.DiamondInPlayer;
                diamond = diamond * 3;

                Ctrl_Player.Ins.AddDiamond(diamond);
                Ctrl_Player.Ins.ProcessAddConin(Diamond.position, transform,0,diamond);
                X3.interactable = false;
            }
           

        });
      
    }
}
