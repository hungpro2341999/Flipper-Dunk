using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/File")]
public class InforSkinBall : ScriptableObject
{
    [SerializeField]
    List<Ball_Infor> ball = new List<Ball_Infor>();


   
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

