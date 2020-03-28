using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompelteDailyQuest : MonoBehaviour
{
    public Text T_Diamond;
   
    public Transform Diamond;

    public Button Ads;
    private void OnEnable()
    {
        if (Ctrl_Player.DiamondInPlayer!=0)
        {


            Ads.interactable = true;
            Ctrl_Player.Ins.ProcessAddConin(Diamond.position, transform);
        }
        else
        {
            Ads.interactable = false;
        }
        Ctrl_Player.Ins.AddDiamond(Ctrl_Player.DiamondInPlayer);
        T_Diamond.text = Ctrl_Player.DiamondInPlayer.ToString();
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
                Ctrl_Player.Ins.ProcessAddConin(Diamond.position, transform);

            }
           

        });
      
    }
}
