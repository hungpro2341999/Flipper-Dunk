using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInBall : MonoBehaviour
{
    
    public Dictionary<string, int> Score;

    public bool isLeft = false;

    public  static string Key_Board = "BOARD";
    public static  string Point_1 = "POINT_1";
    public static string Point_2 = "POINT_2";
    public static string Point_3 = "POINT_3";
    public static string Point_4 = "POINT_4";
    public static string Golbal = "Golbal";


    public bool isPerfect = false;
    public bool isCanGolbal = true;
    public bool isGolbal = false;

    public bool isInBoard = false;

    public Basket basket;

    public Text text;
    private void Start()
    {
        basket = GetComponent<Basket>();
        init();
    }
    // Start is called before the first frame update

    public void init()
    {

        Score = new Dictionary<string, int>();

        Score.Add(Key_Board, 0);
        Score.Add(Point_1, 0);
        Score.Add(Point_2, 0);
        Score.Add(Point_3, 0);
        Score.Add(Point_4, 0);
        Score.Add(Golbal, 0);




    }
    private void Update()
    {
        if(text!=null)
        text.text  =  Score[Key_Board] + ":" + Score[Point_1] + ":" + Score[Point_2];
    }
    public void SetKey(string key)
    {


        if (!isGolbal)
        {
            if (isCanGolbal)
            {
                Score[key] = 1;

                if (Score[Key_Board] == 0)
                {
                    Score[key] = 0;
                }
                else
                {
                    Score[key] = 1;
                    CheckGolbal();
                }
            }
           
        }
       

    }
    public void Restore()
    {
       
        if (!isGolbal)
        {
            
            Score[Point_1] = 0;
            Score[Point_2] = 0;
            Score[Key_Board] = 0;
            isCanGolbal = true;
        }
       
    }

    public void Restore_1()
    {

      
            Score[Point_3] = 0;
            Score[Point_4] = 0;
            Score[Golbal] = 0;
          
      

    }
    public void ResetKey(string key)
    {
        if(key== Key_Board)
        {
            Restore();
        }
        if (key == Golbal)
        {
            Restore_1();
        }
      
    }
    public void Reset()
    {
        isInBoard = false;
        isGolbal = false;
        isPerfect = false;
        isCanGolbal = true;
    }
    public void CheckGolbal()
    {

        if (isCanGolbal)
        {
            if (Score[Point_2] == 1 && Score[Point_1] == 0)
            {
                isCanGolbal = false;

            }
        }
        if (isCanGolbal)
        {
            if (Score[Point_2] == 1 && Score[Point_1] == 1)
            {
                Debug.Log("Dieeeeeeeee");
                basket.Die();
                CtrlGamePlay.Ins.CompleteProcess();
                Ctrl_Spawn.Ins.SpawnScore(EvaluateGolbal());
                isGolbal = true;
                basket.EffGolbal.SetActive(true);
                

            }

            
        }

        
       


    }


    public string[] EvaluateGolbal()
    {
        List<string> typeGolbal = new List<string>();
        int golbal = Score[Point_1] + Score[Point_2] + Score[Point_3] + Score[Point_4];
        if (golbal == 2)
        {
            Ctrl_Player.DiamondInPlayer += Ctrl_Player.Ins.DiamondPerBasket * 2;
            typeGolbal.Add("Well Done!");
            typeGolbal.Add("Good Job!");
            typeGolbal.Add("Wonderful!");
        }
        else if(golbal == 3)
        {
            Ctrl_Player.DiamondInPlayer += Ctrl_Player.Ins.DiamondPerBasket+1;
            typeGolbal.Add("Superb!");
            typeGolbal.Add("Great!");
            typeGolbal.Add("Wonderful!");
        }
        else
        {
            Ctrl_Player.DiamondInPlayer += Ctrl_Player.Ins.DiamondPerBasket;
            typeGolbal.Add("Marvelous");
            typeGolbal.Add("Amazing");
        }
        return typeGolbal.ToArray();
    }




}

public enum TypeGolbal_0 { Superb, Great, Well_Done, Amazing, Marvelous, Wonderful }


