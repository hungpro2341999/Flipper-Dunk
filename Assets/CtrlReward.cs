using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlReward : MonoBehaviour
{
    public static CtrlReward Ins;
    public Transform trans;
    public GameObject StoreItem;

    public Transform transKey;
    public GameObject KeyObj;

    public List<Store_Item> List_Item = new List<Store_Item>();
    public List<GameObject> Keys = new List<GameObject>();
    public Image ShowReward;

    public static bool isClickAds = false;
    public int key;
    public Button btn_Add_key;
    public Transform UnclockSkin;
    public Transform UnClockFlipper;

    public Transform ActiveAds;

    public TypeWindow windownBackToGame;

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
      //  Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartOpenStore(TypeWindow.NextLevel);
        }
    }
    public void UnClockRandom()
    {
        int i = Random.Range(0, 2);
        if (i == 0)
        {
          
            UnclockSkin.GetComponent<Image>().sprite = CtrlShop.Ins.UnclockBallRandom();
            UnClockFlipper.gameObject.SetActive(false);
            UnclockSkin.gameObject.SetActive(true);

        }
        else
        {
            UnClockFlipper.GetComponent<Image>().sprite = CtrlShop.Ins.UnclocFlipperRandom();
            UnClockFlipper.gameObject.SetActive(true);
            UnclockSkin.gameObject.SetActive(false);
        }

    }
    public void Init()
    {
        
        for (int i = 0; i < 9; i++)
        {
            var a = Instantiate(StoreItem, trans);
            List_Item.Add(a.GetComponent<Store_Item>());

        }

       for(int i = 0; i < key; i++)
        {
            var a = Instantiate(KeyObj, transKey);
            Keys.Add(a);
        }
        ActiveAllKey();
    }
    public void ResetStore()
    {

    }
    public void ActiveAllKey()
    {
        for(int i = 0; i < Keys.Count; i++)
        {
            Keys[i].GetComponent<Key>().Active_key();
        }
    }
    public void Open_Store_Item()
    {
        if (key > 0)
        {
            key--;
            for (int i = Keys.Count - 1; i >= 0; i--)
            {
                if (Keys[i].GetComponent<Key>().isActive)
                {
                    Keys[i].GetComponent<Key>().UnActive();
                    return;
                }
            }
        }
       
            
           
        
       
        
    }

    public void BackToGame()
    {
        GameMananger.Ins.Close_SigleWindow(TypeWindow.Reward);
        GameMananger.Ins.Open(windownBackToGame);

    }

    public IEnumerator OpenOverGame(float waittime)
    {

        yield return new WaitForSeconds(waittime);
        if (key<=0)
        {
            //GameMananger.Ins.Close_SigleWindow(TypeWindow.Reward);
            //GameMananger.Ins.Open(TypeWindow.NextLevel);
        }
    }

    public bool isHasKey()
    {
        return key > 0;
    }
    public void StartOpenStore(TypeWindow windowBackTo)
    {
        GameMananger.Ins.Open(TypeWindow.Reward);
        Debug.Log("as");
        key = 3;
        btn_Add_key.interactable = true;
        ActiveAds.gameObject.SetActive(false);
        windownBackToGame = windowBackTo;
       
       
        for (int i = 0; i < Keys.Count; i++)
        {
            if(Keys[i]!=null)
            Keys[i].GetComponent<DestroySelf>().DestroyNormal();
        }
        Keys.Clear();
        Keys = new List<GameObject>();
        Ctrl_Player.Ins.ResetKey();
       
        for(int i = 0; i < key; i++)
        {
            var a = Instantiate(KeyObj, transKey);
            Keys.Add(a);
            a.GetComponent<Key>().Active_key();
        }

        ActiveAllKey();
        for(int i = 0;i< List_Item.Count; i++)
        {
            
            List_Item[i].GetComponent<DestroySelf>().Destroy();
        }
       
        List_Item = new List<Store_Item>();
        for (int i = 0; i < 9; i++)
        {
            var a = Instantiate(StoreItem, trans);
            List_Item.Add(a.GetComponent<Store_Item>());

        }
        UnClockRandom();
    }
    private void OnEnable()
    {
       

    }
    public void AddKey(int key)
    {
        ManagerAds.Ins.ShowRewardedVideo((show) =>
        {
            if (show)
            {
                isClickAds = true;
                btn_Add_key.interactable = false;
                this.key += key;
                int key_rest = 0;
                for (int i = 0; i < Keys.Count; i++)
                {
                    if (!Keys[i].GetComponent<Key>().isActive)
                    {
                        key_rest++;
                    }
                }
                for (int i = 0; i < Keys.Count; i++)
                {
                    Keys[i].GetComponent<DestroySelf>().DestroyNormal();
                }
                for (int i = 0; i < 3; i++)
                {
                    var a = Instantiate(KeyObj, transKey);
                    Keys.Add(a);
                    a.GetComponent<Key>().Active_key();
                }
                //for (int i = 0; i < key_rest; i++)
                //{
                //    Keys[Keys.Count - 1 - i].GetComponent<Key>().UnActive();
                //}
            } 
        

        });
       
    }
    public void RandomReward()
    {
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            var a = Ctrl_Player.Ins.DataGame.ball;

            List<Ball_Infor> Skins = new List<Ball_Infor>();

            for(int k = 0;k < a.Count; k++)
            {
                if (!a[k].isBuy)
                {
                    Skins.Add(a[k]);
                }
            }
            int x = Random.Range(0, Skins.Count);
            if (Skins.Count != 0)
            {


            }
            else
            {


            }
            

        }
        else
        {


        }
    }

}
