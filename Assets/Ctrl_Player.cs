using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ctrl_Player : MonoBehaviour
{

    public InforSkinBall DataGame;

    public int DiamondPerBasket = 3;

    public static Ctrl_Player Ins;

    public static int DiamondInPlayer = 0;

    public static int ScorePlayer = 0;

    public const string key_level = "Key_Level";

    public const string key_coin = "Key_Coin";

    public const string key_key = "Key_Key";

    public const string Key_Diamond = "Key_Diamond";

    public const string Key_Score = "Key_Score";

    public const string Key_Skin = "Key_SKin";

    public const string Key_Flipper = "Key_Flipper";

    public const string Key_BG = "Key_BG";

    public const string Key_Sound = "Key_Sound";

    public const string Key_Variable = "Key_Variable";

    public int LevelPlayer = 0;

    public int GetCurrKey1 = 0;

    public int Diamond;

    public int Score;

    public GameObject ObjDimaond;

  
    // Start is called before the first frame update
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
        Init();
    }


    void Start()
    {
        LevelPlayer = GetCurrLevel();
        ShowDiamond();
        
    }

    
    

    public void ShowDiamond()
    {
        GameMananger.Ins.ShowDiamondGame.Find("Diamond/Text").GetComponent<Text>().text = GetDiamond().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrKey1 = GetCurrKey();
     //   Debug.Log(GetCurrKey1);
    }
    public void Init()
    {


       // PlayerPrefs.DeleteKey(key_key);
        if (!PlayerPrefs.HasKey(key_key))
        {
            PlayerPrefs.SetInt(key_key, 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey(Key_Diamond))
        {
            PlayerPrefs.SetInt(Key_Diamond, 0);
            PlayerPrefs.Save();
        }


        if (!PlayerPrefs.HasKey(Key_Score))
        {
            PlayerPrefs.SetInt(Key_Score, 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey(Key_Skin))
        {
            PlayerPrefs.SetInt(Key_Skin, 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey(Key_Flipper))
        {
            PlayerPrefs.SetInt(Key_Flipper, 0);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey(Key_Sound))
        {
            PlayerPrefs.SetInt(Key_Sound, 1);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey(Key_BG))
        {
            PlayerPrefs.SetInt(Key_BG, 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey(Key_Variable))
        {
            PlayerPrefs.SetInt(Key_Variable, 1);
            PlayerPrefs.Save();
        }

          CtrlShop.Ins.Init();
    }

    public bool isSound()
    {
        if (PlayerPrefs.GetInt(Key_Sound) == 1)
        {
            return true;
        }
        return false;
    }

    public bool isVariable()
    {

        if(PlayerPrefs.GetInt(Key_Variable) == 1)
        {
            return true;
        }

        return false;
    }

    public void SetSound(bool active)
    {
        if(active)
        {
            PlayerPrefs.SetInt(Key_Sound, 1);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt(Key_Sound, 0);
            PlayerPrefs.Save();
        }
    }

    public void SetVariable(bool active)
    {
        if (active)
        {
            PlayerPrefs.SetInt(Key_Variable, 1);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt(Key_Variable, 0);
            PlayerPrefs.Save();
        }
    }
    public void SetSkinBall(int id)
    {
        PlayerPrefs.SetInt(Key_Skin, id);
        PlayerPrefs.Save();
    }
    public void SetSkinFlipper(int id)
    {
        PlayerPrefs.SetInt(Key_Flipper, id);
        PlayerPrefs.Save();
    }

    public void  SetSkinBG(int id)
    {
        PlayerPrefs.SetInt(Key_BG, id);
        PlayerPrefs.Save();
    }

    public int GetSkinBGUse()
    {
        return PlayerPrefs.GetInt(Key_BG);
    }


    public int GetSkinBallUse()
    {
        return PlayerPrefs.GetInt(Key_Skin);
    }
    public int GetSkinFlipperUse()
    {
        return PlayerPrefs.GetInt(Key_Flipper);
    }

    public Sprite GetSkinBall()
    {
        int id = GetSkinBallUse();
        var a = Ctrl_Player.Ins.DataGame.ball;
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i].id == id)
            {
                return a[i].Skin;
            }
        }
        return null;
    }


    public Sprite GetSkinFlipper()
    {
        int id = GetSkinFlipperUse();
        var a = Ctrl_Player.Ins.DataGame.flipper;
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i].id == id)
            {
                return a[i].Skin;
            }
        }
        return null;
    }

    public Sprite GetSkinBG()
    {
        int id = GetSkinBGUse();
        Debug.Log("Get BG : " + id);
       var a = Ctrl_Player.Ins.DataGame.BG;
        for(int i = 0; i < a.Count; i++)
        {
           
            if (a[i].id == id)
            {
                return  a[i].Icon[Random.Range(0,a[i].Icon.Length)];
            }
        }
        return null;
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(Key_Score);
    }
    public void SetHighScore(int Score)
    {
        int s = GetHighScore();
        if (s < Score)
        {
            PlayerPrefs.SetInt(Key_Score, Score);
            PlayerPrefs.Save();
        }
    }

   
   
    

    public int GetDiamond()
    {
        return PlayerPrefs.GetInt(Key_Diamond);
    }

    public void AddDiamond(int diamond)
    {
       int d = PlayerPrefs.GetInt(Key_Diamond);
        d += diamond;
        PlayerPrefs.SetInt(Key_Diamond,d);
        PlayerPrefs.Save();
    }

    public void EarnDiamond(int diamond)
    {
        int d = PlayerPrefs.GetInt(Key_Diamond);
        d -= diamond;
        PlayerPrefs.SetInt(Key_Diamond, d);
        PlayerPrefs.Save();

    }


    public int GetCurrKey()
    {
        return PlayerPrefs.GetInt(key_key);
    }
   
    public void ResetKey()
    {
        PlayerPrefs.SetInt(key_key,0);
        PlayerPrefs.Save();
    }

    public void RestoreKey(int key)
    {
        int k = GetCurrKey();
        k -= key;
        k = Mathf.Clamp(k, 0, 3);
        PlayerPrefs.SetInt(key_key, k);
        PlayerPrefs.Save();
    }

    public bool isInGameisFullKey()
    {
        if (CtrlGamePlay.Ins.key_in_Game +GetCurrKey() >= 3)
        {
            return true;
        }
        return false;
    }

    public void AddKey(int key)
    {
        int k = CtrlGamePlay.Ins.key_in_Game + GetCurrKey();
        PlayerPrefs.SetInt(key_key, k);
        PlayerPrefs.Save();
    }

   
   
    

    public int GetCurrLevel()
    {
     //   PlayerPrefs.DeleteKey(key_level);

        if (PlayerPrefs.HasKey(key_level))
        {
            return PlayerPrefs.GetInt(key_level);
        }
        else
        {
            PlayerPrefs.SetInt(key_level, 1);
            PlayerPrefs.Save();
        }
      
        return PlayerPrefs.GetInt(key_level);
    }

    public void CompleteNextLevel()
    {
       // Ctrl_Player.Ins.SaveNextKey();
        int level = PlayerPrefs.GetInt(key_level);
        level++;
        PlayerPrefs.SetInt(key_level, level);
        PlayerPrefs.Save();
    }
    public void ProcessAddConin(Vector3 pos,Transform trans,float time) 
    {
        StartCoroutine(AddCoin(pos, trans,time));
     
        // None
    }
    public IEnumerator AddCoin(Vector3 pos,Transform trans,float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(ObjDimaond, pos, Quaternion.identity, trans);
      
        yield return new WaitForSeconds(0.2f);

        Instantiate(ObjDimaond, pos, Quaternion.identity, trans);

        yield return new WaitForSeconds(0.2f);


        Instantiate(ObjDimaond, pos, Quaternion.identity, trans);
        yield return new WaitForSeconds(0.8f);

        ShowDiamond();

    }

    public void ChangeSound()
    {

        SetSound(!isSound());
        Setting.Ins.SetUpSound();
       
    }

    public void ChangeVariable()
    {
        SetVariable(!isVariable());
        Setting.Ins.SetUpVariable();
    }

   
}

