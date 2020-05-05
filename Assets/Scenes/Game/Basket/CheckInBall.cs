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
    public static string Reset_Golbal = "Reset";
    public static string Above_Board = "AboveBoard";
    public static string Above_Board_1 = "AboveBoard_1";
    public static string Box_Above_Board = "BoxAboveBoard";
    public static string Clamp = "Clamp";

    public bool isPerfect = false;
    public bool isCanGolbal = true;
    public bool isGolbal = false;

    public bool isInBoard = false;
    public bool isAbove = true;
    public Basket basket;
    public int clamp;

    public delegate bool Chanlegend();

    public Chanlegend eventchanlegend;

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
        Score.Add(Reset_Golbal, 0);
        Score.Add(Above_Board, 0);
        Score.Add(Above_Board_1, 0);
        Score.Add(Box_Above_Board, 0);
        Score.Add(Clamp, 0);



    }
    private void Update()
    {
        if(text!=null)
        text.text  =  Score[Key_Board] + ":" + Score[Point_1] + ":" + Score[Point_2];
    }
    public void SetKey(string key)
    {
        if (key == Above_Board_1 || key == Above_Board)
        {
            if (isAbove)
            {

                if (key == Above_Board_1)
                {
                    Score[Above_Board_1] = 1;
                    if (Score[Above_Board] == 1)
                    {
                        Score[Above_Board_1] = 0;
                    }
                    else
                    {
                        Score[Above_Board_1] = 1;
                        isAbove = false;
                        return;
                    }

                }



                if (key == Above_Board)
                {
                    if (Score[Above_Board_1] == 0)
                    {
                        Score[Above_Board] = 1;
                    }
                    else
                    {
                        Score[Above_Board] = 0;
                    }
                }
            }
        }
        else
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



        if (key == Clamp)
        {
            clamp++;
        }
           


    }
    public void Restore()
    {
       
        if (!isGolbal)
        {
            clamp = 0;
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
        if(key == Reset_Golbal)
        {
            Score[Point_1] = 0;
            Score[Point_2] = 0;
            isCanGolbal = true;
        }

        if (key == Golbal)
        {
            Restore_1();
        }
        if (key == Box_Above_Board)
        {
            isAbove = true;
            Score[Above_Board] = 0;
            Score[Above_Board_1] = 0;
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
              //  Debug.Log("Dieeeeeeeee");
                basket.Die();
                if(CtrlGamePlay.Ins.typeGame == TypeGamePlay.Chanelegend)
                {
                   
                        if (eventchanlegend())
                        {

                           Ctrl_Spawn.Ins.SpawnScore(EvaluateGolbal());

                           CtrlGamePlay.Ins.CompleteProcess();

                            Debug.Log("Null");
                        }
                        else
                        {
                        Ctrl_Spawn.Ins.SpawnScoreFailed();

                        }
                   
                }
                else
                {
                    Ctrl_Spawn.Ins.SpawnScore(EvaluateGolbal());
                    CtrlGamePlay.Ins.CompleteProcess();
                }
              
               
                isGolbal = true;
                basket.EffGolbal.SetActive(true);
                
                CtrlGamePlay.Ins.AddScore(3);
                

            }

            
        }

        
       


    }


    public string[] EvaluateGolbal()
    {
        List<string> typeGolbal = new List<string>();
        int golbal = Score[Point_1] + Score[Point_2] + Score[Point_3] + Score[Point_4];
        if (golbal == 2)
        {
           
            if(CtrlGamePlay.Ins.typeGame == TypeGamePlay.Infinity)
            {
                Ctrl_Player.DiamondInPlayer += 1;
            }
            else
            {
                Ctrl_Player.DiamondInPlayer += Ctrl_Player.Ins.DiamondPerBasket * 2;
            }
            typeGolbal.Add("Well Done!");
            typeGolbal.Add("Good Job!");
            typeGolbal.Add("Wonderful!");
          
            if (CtrlGamePlay.Ins.typeGame != TypeGamePlay.Level)
            {
                CtrlAudio.Ins.Play("Golbal");
            }
            else
            {
                
                CtrlAudio.Ins.Play("Cheer");
                CtrlAudio.Ins.Play("Ding");
            }
        }
        else if(golbal == 3)
        {
            if (CtrlGamePlay.Ins.typeGame != TypeGamePlay.Level)
            {
                CtrlAudio.Ins.Play("Golbal");
            }
            else
            {
                CtrlAudio.Ins.Play("Golbal");
            }
           
            if (CtrlGamePlay.Ins.typeGame == TypeGamePlay.Infinity)
            {
                Ctrl_Player.DiamondInPlayer += 1;
            }
            else
            {
                Ctrl_Player.DiamondInPlayer += Ctrl_Player.Ins.DiamondPerBasket + 1;
            }
            typeGolbal.Add("Superb!");
            typeGolbal.Add("Great!");
            typeGolbal.Add("Wonderful!");
          
        }
        else
        {
            Ctrl_Player.DiamondInPlayer += Ctrl_Player.Ins.DiamondPerBasket;
            if (CtrlGamePlay.Ins.typeGame == TypeGamePlay.Infinity)
            {
                 Ctrl_Player.DiamondInPlayer += 1;
            }
            else
            {
                Ctrl_Player.DiamondInPlayer += Ctrl_Player.Ins.DiamondPerBasket;
            }

            CtrlAudio.Ins.Play("Golbal");
            
            typeGolbal.Add("Marvelous");
            typeGolbal.Add("Amazing");
            
         
        }
        return typeGolbal.ToArray();
    }

    
    public void SetUpChanllegend(int i)
    {
        eventchanlegend = null;
        switch (i)
        {
            case 0:
                eventchanlegend += Challegen_1;
                Debug.Log("C:1");
                break;
            case 1:
                eventchanlegend += Challegen_2;
                Debug.Log("C:2");
                break;
            case 2:
                eventchanlegend += Challegen_3;
                Debug.Log("C:3");
                break;
            case 3:
                eventchanlegend += Challegen_4;
                Debug.Log("C:4");
                break;
        }
    }

    public bool Challegen_1()
    {
        return true;
    }
    public bool Challegen_2()
    {
        if (Score[Above_Board]==1)
        {
            return true;
        }
        return false;
    }
    public bool Challegen_3()
    {
        return (Ball.Ins.isWall);
    }
    public bool Challegen_4()
    {
        if (clamp>=2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

public enum TypeGolbal_0 { Superb, Great, Well_Done, Amazing, Marvelous, Wonderful }


