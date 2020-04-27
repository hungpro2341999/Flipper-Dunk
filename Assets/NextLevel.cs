using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public Text T_Diamond;
    public Text T_Level_Completel;
    public Transform Diamond;
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
       
        T_Diamond.text = Ctrl_Player.DiamondInPlayer.ToString();
        X3.interactable = true;
        if (Ctrl_Player.DiamondInPlayer != 0)
        {
            T_Level_Completel.text = "LEVEL" + " " + (Ctrl_Player.Ins.GetCurrLevel() - 1).ToString();
            Ctrl_Player.Ins.ProcessAddConin(Diamond.position, transform, 1, Ctrl_Player.DiamondInPlayer);
        }
       
       
    }
    public void X3Diamond()
    {
        ManagerAds.Ins.ShowRewardedVideo((show) =>
        {
            if (show)
            {
                int diamond = Ctrl_Player.DiamondInPlayer;
                diamond = diamond * 3;

              
                Ctrl_Player.Ins.ProcessAddConin(Diamond.transform.position, transform,1, diamond);
                X3.interactable = false;
            }


        });

    }
}
