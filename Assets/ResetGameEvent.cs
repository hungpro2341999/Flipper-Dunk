using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameEvent : MonoBehaviour
{

     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            int live =  CtrlGamePlay.Ins.live--;
            if (CtrlGamePlay.Ins.CompleteLevel)
                return;
            if (live > 0)
            {
                Debug.Log("1");
                StartCoroutine(ResetGame());
            }
            else
            {
                Debug.Log("2");
                GameMananger.Ins.OpenWindow(TypeWindow.GameOver);
            }
          
        }
    }
  
    public IEnumerator ResetGame()
    {
      
            yield return new WaitForSeconds(0);
            StartCoroutine(CtrlGamePlay.Ins.ShadowScreen());
        

        yield return new WaitForSeconds(0);


    }
}
