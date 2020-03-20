using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int LevelPlayer = 0;

    public int GetCurrKey1 = 0;

    public int Diamond;
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
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrKey1 = GetCurrKey();
        Debug.Log(GetCurrKey1);
    }
    public void Init()
    {



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

        CtrlShop.Ins.Init();
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
    public void SaveNextKey()
    {
        int key = PlayerPrefs.GetInt(key_key);
        key++;

        PlayerPrefs.SetInt(key_key, key);

        if (key >= Ctrl_Spawn.Ins.Count_Key)
        {
            key = 0;
            PlayerPrefs.SetInt(key_key, key);
        }
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
        int level = PlayerPrefs.GetInt(key_level);
        level++;
        PlayerPrefs.SetInt(key_level, level);
        PlayerPrefs.Save();
    }
    public void SetCompeteLevel(int level)
    {
        // None
    }

}

