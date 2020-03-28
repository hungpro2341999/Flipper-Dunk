using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public Text T_Diamond;
    public Text T_Level_Completel;
    public Transform Diamond;
  
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
        Ctrl_Player.Ins.AddDiamond(Ctrl_Player.DiamondInPlayer);
        T_Diamond.text = Ctrl_Player.DiamondInPlayer.ToString();
        T_Level_Completel.text = "LEVEL" + " " + (Ctrl_Player.Ins.GetCurrLevel() - 1).ToString();
        Ctrl_Player.Ins.ProcessAddConin(Diamond.position, transform);
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
                Ctrl_Player.Ins.ProcessAddConin(Diamond.transform.position, transform);

            }


        });

    }
}
