using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompelteDailyQuest : MonoBehaviour
{
    public Text T_Diamond;
   
    public Transform Diamond;

    private void OnEnable()
    {
        Ctrl_Player.Ins.AddDiamond(Ctrl_Player.DiamondInPlayer);
        T_Diamond.text = Ctrl_Player.DiamondInPlayer.ToString();


        Ctrl_Player.Ins.ProcessAddConin(Diamond.position, transform);
    }
}
