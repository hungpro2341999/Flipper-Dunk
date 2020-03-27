using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PauseGame()
    {
        GameMananger.Ins.isGamePause = true;
    }

    public void StartGame()
    {
        GameMananger.Ins.isGamePause = false;
    }
}
