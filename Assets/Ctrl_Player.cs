using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Player : MonoBehaviour
{


    public static Ctrl_Player Ins;

    public static int ScorePlayer = 0;

    public const string key_level = "Key_Level";

    public const string key_coin = "Key_Coin";
    public int LevelPlayer = 0;
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
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {

       
         

        
       
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
