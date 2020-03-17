using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeWindow {NextLevel,GameOver}
public class GameMananger : MonoBehaviour
{
    public static GameMananger Ins;
    public List<Windown> windowns;
    public bool isGamePause = false;
    public bool isGameOver = false;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {

    }
    public void ResetGame()
    {

    }

    public void OverGame()
    {

    }

    public void OpenWindow(Windown w)
    {
        foreach(Windown s in windowns)
        {
            if(w.type == s.type)
            {
                w.Open();
            }
            else
            {
                w.Close();
            }
        }
    }
    public void OpenWindow(TypeWindow w)
    {
        foreach (Windown s in windowns)
        {
            if (s.type == w)
            {
                s.Open();
            }
            else
            {
                s.Close();
            }
        }
    }
    public void CloseAll()
    {
        foreach(Windown w in windowns)
        {
            w.Close();
        }
    }


}
