using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/File")]
public class InforSkinBall : ScriptableObject
{
    [SerializeField]
   public  List<Ball_Infor> ball = new List<Ball_Infor>();
    [SerializeField]
   public List<Ball_Infor> BG = new List<Ball_Infor>();
    [SerializeField]
    public List<Ball_Infor> flipper = new List<Ball_Infor>();

}

[System.Serializable]
public class Ball_Infor
{
    public Sprite[] Icon;
    public int id;
    public Sprite Skin;
    public int cost;
    public bool isBuy = false;
    public bool isUse = false;
}


