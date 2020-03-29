using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Skin;
    public Image Fliper;
    public int idUnlock = 0;
    public int r;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Random_Open_Item()
    {
         r = Random.Range(0, 2);
        if (r == 0)
        {
            int id = -1;
            Skin.enabled = true;
            Fliper.enabled = false;
            Skin.sprite = CtrlShop.Ins.GetUnclockBallRandom(out id);
            idUnlock = id;

        }
        else
        {
            int id = -1;
            Skin.enabled = false;
            Fliper.enabled = true;
            Fliper.sprite = CtrlShop.Ins.GetUnclocFlipperRandom(out id);
            idUnlock = id;
        }
    }

    public void Unlock_Item()
    {
        ManagerAds.Ins.ShowRewardedVideo((show) =>
        {
            if (show)
            {
                if (r == 0)
                {
                    CtrlShop.Ins.UnclockBall(idUnlock);
                }
                else
                {
                    CtrlShop.Ins.UnlockFlipper(idUnlock);
                }
                GameMananger.Ins.Close(TypeWindow.Unlock);
            }


       
        });
      
    }
   
    private void OnEnable()
    {
        Random_Open_Item();
    }
}
