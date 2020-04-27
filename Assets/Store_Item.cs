using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Store_Item : MonoBehaviour,IPointerClickHandler
{
    public bool open;
    public List<Image> Item = new List<Image>();
    public Image Image_Store;
    public ParticleSystem[] Eff;
   
    // Start is called before the first frame update
   
   


    public void Open_Item()     
    {
        if (!open)
        {
            open = true;
            if (CtrlReward.Ins.isHasKey())
            {
                CtrlReward.Ins.Open_Store_Item();
                Image_Store.enabled = false;
                int r = Random.Range(0, 20);
                if (r >= 0 && r <= 17)
                {
                    CtrlAudio.Ins.Play("CoinCollect");
                    int diamond = Random.Range(1, 20);

                    Item[2].transform.Find("Text").GetComponent<Text>().text = diamond.ToString();
                    Item[2].gameObject.SetActive(true);
                    Ctrl_Player.Ins.ProcessAddConin(transform.position, CtrlReward.Ins.transform, 0,diamond);
                  
                    StartEff();
                }

                else if (r > 15 && r <= 17)
                {
                    CtrlAudio.Ins.Play("UnClock");
                    Item[1].gameObject.SetActive(true);
                    Item[0].gameObject.SetActive(false);
                    Item[1].sprite = CtrlShop.Ins.UnclockBallRandom();
                    StartEff();

                }
                else
                {
                    CtrlAudio.Ins.Play("UnClock");
                    Item[1].gameObject.SetActive(false);
                    Item[0].gameObject.SetActive(true);
                    Item[0].sprite = CtrlShop.Ins.UnclocFlipperRandom();
                    StartEff();
                }


                Debug.Log("Out Off Key");
            }
            else
            {
                Debug.Log("Out Off Key");
            }
        }


    }
    public void Reset()
    {
        for(int i = 0; i < Item.Count; i++)
        {
            Item[i].transform.gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Open_Item();
        if (CtrlReward.Ins.key <= 0)
        {
            StartCoroutine(CtrlReward.Ins.OpenOverGame(4));
        }
    }
    public void StartEff()
    {
        Ctrl_Spawn.Ins.SpawnUIEff(4, Image_Store.transform.position, transform);
        
    }
}
