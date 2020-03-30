using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeWindow {NextLevel,GameOver,Reward,Shop_Skin,Shop_Flipper,Home,Play,Mode_1,Mode_2,Mode_3,Over_Game_3,CompleteDailyQuest,Shop_BG,Unlock,NotCompleteDailyQuest}
public class GameMananger : MonoBehaviour
{
    public static GameMananger Ins;
    public List<Windown> windowns;
    public bool isGamePause = false;
    public bool isGameOver = false;
    public Transform ShowDiamondGame;
    public Transform SettingGame;
    public Text Diamond;
    public static Vector3 PosDiamond;

    public TypeWindow CurrWindown;

    public bool open = false;
    public Animator AnimLabe;
    public Text textLabel;

    private void Awake()
    {
        if (Ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Ins = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PosDiamond = ShowDiamondGame.transform.position;
     
  
        ShowDiamond();

        //isGameOver = true;
        //isGamePause = true;
             OpenWindow(TypeWindow.Home);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame(Windown mode)
    {
        OpenWindow(mode.type);
        //  CtrlGamePlay.Ins.StartGame();
    }
    public void ResetGame()
    {

    }

    public void OverGame()
    {

    }

    public void OpenWindow(Windown w)
    {
        OpenWindow(w.type);
    }
    public void OpenWindow(TypeWindow w)
    {
        foreach (Windown s in windowns)
        {
         //   Debug.Log("Load-Open");
            if (s == null)
            {
                continue;
            }
            if (s.type == w)
            {
                CurrWindown = s.type;
                switch (w)
                {

                    case TypeWindow.Shop_Flipper:
                        s.Open();
                        CtrlShop.Ins.type = TypeShop.FLipepr;
                        Debug.Log("Open");
                        break;
                    case TypeWindow.Shop_Skin:
                        s.Open();
                        CtrlShop.Ins.type = TypeShop.Skin;
                        break;
                    case TypeWindow.Shop_BG:
                        s.Open();
                        CtrlShop.Ins.type = TypeShop.BG;
                            break;
                    case TypeWindow.Play:
                        s.Open();
                        CtrlGamePlay.Ins.StartGame(CtrlGamePlay.Ins.typeGame);
                        UnSetting();
                        break;
                    case TypeWindow.Home:
                        s.Open();
                        isGameOver = true;
                        isGamePause = true;
                        break;
                    default:
                        s.Open();
                        break;
                }

            }
            else
            {
                switch (w)
                {
                    case TypeWindow.Play:
                        s.Close();
                       

                        break;
                    case TypeWindow.Shop_Flipper:
                        s.Close();
                        CtrlShop.Ins.ResetShop();
                        break;
                    case TypeWindow.Shop_Skin:
                        s.Close();
                        CtrlShop.Ins.ResetShop();
                        break;
                    default:
                        s.Close();
                        break;
                   
                       
                        
                      
                        break;
                }
            }
        }
        ShowDiamond(CurrWindown);
        ShowSetting(CurrWindown);
        

        if(w == TypeWindow.Home)
        {
            GameMananger.Ins.ShowSetting();
        }
    }
    public void CloseAll()
    {
        foreach (Windown w in windowns)
        {
            w.Close();
        }
    }

    public void ShowDiamond(TypeWindow type)
    {
        if (type != TypeWindow.Play)
        {
            ShowDiamondGame.gameObject.SetActive(true);
        }
        else
        {
            ShowDiamondGame.gameObject.SetActive(false);
        }
    }
    public void ShowSetting(TypeWindow type)
    {
        if(type == TypeWindow.Play)
        {
            SettingGame.gameObject.SetActive(false);
        }
        else
        {
            SettingGame.gameObject.SetActive(true);
            
        }
    }
    public void UnSetting()
    {
        SettingGame.gameObject.SetActive(false);
        ShowDiamondGame.gameObject.SetActive(false);
    }
    public void ShowSetting()
    {
        SettingGame.gameObject.SetActive(true);
        ShowDiamondGame.gameObject.SetActive(true);
    }


    public void UnShowDiamond(TypeWindow type)
    {
        if(type == TypeWindow.Over_Game_3 || type == TypeWindow.NextLevel || type == TypeWindow.GameOver)
        {
            ShowDiamondGame.gameObject.SetActive(false);
        }
    }
    public void ActiveDiamond(bool active)
    {
        ShowDiamondGame.gameObject.SetActive(active);
    }
    public void StartMode_1()
    {
        CtrlGamePlay.Ins.typeGame = TypeGamePlay.Level;
    }
    public void StartMode_2()
    {

        CtrlGamePlay.Ins.typeGame = TypeGamePlay.Chanelegend;
    }
    public void StartMode_3()
    {
        CtrlGamePlay.Ins.typeGame = TypeGamePlay.Infinity;
    }
    public void Open(TypeWindow type)
    {
      for(int i = 0; i < windowns.Count; i++)
        {
            if (windowns[i] == null)
                continue;
            if (windowns[i].type == type)
            {
                windowns[i].Open();
                
                if(windowns[i].type == TypeWindow.Over_Game_3 || windowns[i].type == TypeWindow.GameOver)
                {
                    ActiveDiamond(true);
                }
               if(windowns[i].type == TypeWindow.Shop_Skin)
                {
                    CtrlShop.Ins.type = TypeShop.Skin;
                }

               if(windowns[i].type == TypeWindow.Shop_Flipper)
                {
                    CtrlShop.Ins.type = TypeShop.FLipepr;
                }

                if (windowns[i].type == TypeWindow.Shop_BG)
                {
                    CtrlShop.Ins.type = TypeShop.BG;
                }

            }
        }
        CurrWindown = type;
        ShowDiamond(CurrWindown);
        ShowSetting(CurrWindown);
    }
    public void ShowDiamond()
    {
        Diamond.text = Ctrl_Player.Ins.GetDiamond().ToString();
      
    }
    public void Open(Windown windown)
    {
        
        Open(windown.type);
    }
    public void Close(Windown windown)
    {
        Close(windown.type);
        
    }

    public void Close_SigleWindow(TypeWindow w)
    {
        for(int i = 0; i < windowns.Count; i++)
        {
            if(windowns[i].type == w)
            {
                windowns[i].Close();
                break;
            }
        }
    }
    public void Close(TypeWindow type)
    {
        for (int i = 0; i < windowns.Count; i++)
        {
            if (windowns[i] == null)
                continue;
            if (windowns[i].type == type)
            {
                windowns[i].Close();
                if (windowns[i].type == TypeWindow.Over_Game_3 || windowns[i].type == TypeWindow.GameOver)
                {
                    ActiveDiamond(false);
                }
            }
        }
        if(type == TypeWindow.Shop_Flipper)
        {
           SettingGame.gameObject.SetActive(true);
        }
        if (type == TypeWindow.Shop_BG)
        {
            SettingGame.gameObject.SetActive(true);
        }

        if (type == TypeWindow.Shop_Skin)
        {
           SettingGame.gameObject.SetActive(true);
        }
        UnShowDiamond(type);
    }
    public void SetLable(string s)
    {
        textLabel.text = s;
    }
    public void StartLabel()
    {
        isGamePause = true;

        open = !open;
        AnimLabe.SetBool("Open", open);
        
    }
    
}
