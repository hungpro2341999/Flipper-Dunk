using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/File")]
public class InforSkinBall : ScriptableObject
{
    [SerializeField]
   public  List<Ball_Infor> ball = new List<Ball_Infor>();
    [SerializeField]
   public List<Sprite> BG = new List<Sprite>();

   
}

[System.Serializable]
public class Ball_Infor
{
    
    public int id;
    public Sprite Skin;
    public int cost;
    public bool isBuy = false;
    public bool isUse = false;
}

