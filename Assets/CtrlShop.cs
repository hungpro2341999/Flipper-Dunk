using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlShop : MonoBehaviour
{

    public const string key_Shop = "Key_Shop";

    public static CtrlShop Ins;

    public static int SelectCurr;
    
    public GameObject Page;
    public GameObject Skin;
    public GameObject Dot;
    public List<Actice_Change_Page> Pages = new List<Actice_Change_Page>();
    public List<SkinBall> ListSkins = new List<SkinBall>();
    public List<Dot> Dots = new List<Dot>();
    public Transform transShop;
    public Transform transDot;
    public Image ShowSKin; 
    public float space;
    public bool isChangePage=false;
    public bool isChaning=false;
    public Vector2 InitPos;
    public int PageCUrr;
    public int direct = 0;
    public float speed;
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
      //  space = Screen.width;
        LoadShop();
    }

    // Update is called once per frame
    void Update()
    {

        if (isChangePage)
        {
            if (!isChaning)
            {
                Vector2 mouse = Input.mousePosition;


                if (Vector2.SqrMagnitude((mouse - InitPos)) > 1)
                {
                    bool next = false;
                    if (Mathf.Sign(InitPos.x - mouse.x) == -1)
                    {
                        next = false;
                    }
                    else
                    {
                        next = true;
                    }


                    RenderPage(next);
                }
                else
                {
                   
                    Debug.Log("Change :::::::::");
                }

            }
            else
            {
                Debug.Log("Change ::::::::::::::::::::::");
            }
        }
      
        
      
    }

    public void Init()
    {
        PlayerPrefs.DeleteKey(key_Shop);
        if (!PlayerPrefs.HasKey(key_Shop))
        {
            List<SaveSkin> Saves = new List<SaveSkin>();
            var a = Ctrl_Player.Ins.DataGame.ball;
            for(int i = 0; i < a.Count; i++)
            {
                SaveSkin skin;
                if (i == 0)
                {
                    skin = new SaveSkin(i,true, true);
                }
                else
                {
                    skin = new SaveSkin(i, false, false);
                }
                Saves.Add(skin);
                DataSave data = new DataSave(Saves);
                string json = JsonUtility.ToJson(data);

                PlayerPrefs.SetString(key_Shop, json);
                PlayerPrefs.Save();
              
            }
        }
       
    }
   

    public void InitPoint(Vector2 point)
    {
        isChangePage = true;
        InitPos = point;
    }
    

    public void LoadShop()
    {
     
        PageCUrr = 0;
        var datasave = LoadData();
        Debug.Log("CO : "+datasave.Count);
        float CountPage = Ctrl_Player.Ins.DataGame.ball.Count/9;
       
        var a2 = Ctrl_Player.Ins.DataGame.ball;

        int total = a2.Count;

        Dictionary<int, List<GameObject>> SkinPerPage = new Dictionary<int, List<GameObject>>();

        for(int i = 0; i < CountPage; i++)
        {
            SkinPerPage.Add(i, new List<GameObject>());
        }

        
        
        for(int i = 0; i <CountPage; i++)
        {
           for(int j = 0; j < 9; j++)
            {
                var a1 = Instantiate(Skin);
                SkinPerPage[i].Add(a1);
            }
                
                
          
        }
      
        
        for(int i = 0; i < CountPage; i++)
        {


            var a = Instantiate(Page,transShop);
            a.transform.localPosition = new Vector2(space * i, 0);
            a.GetComponent<Actice_Change_Page>().id = i;
            Pages.Add(a.GetComponent<Actice_Change_Page>());

            List<GameObject> ListBall = SkinPerPage[i];

            for(int j = 0; j < ListBall.Count; j++)
            {
                ListBall[j].transform.parent = a.transform;
                ListSkins.Add(ListBall[j].GetComponent<SkinBall>());

            }

        }

        for(int i = 0; i < ListSkins.Count; i++)
        {
            Debug.Log(i);
            ListSkins[i].Load(datasave[i].id, datasave[i].buy, datasave[i].use, a2[i].cost, a2[i].Skin);
            if (ListSkins[i].isBuy)
            {
                ListSkins[i].Select();
            }
           
        }


        for(int i = 0; i < Pages.Count; i++)
        {
            var a1 = Instantiate(Dot, transDot);
            Dots.Add(a1.GetComponent<Dot>());
        }
        ActiveDot(PageCUrr);
        
    }

    

    public void RenderPage(bool next)
    {
        int direct = next ? 1 : -1;
        Debug.Log("DDD");
        if ((PageCUrr + direct)>=Pages.Count || (PageCUrr + direct) < 0)
        {
            Debug.Log("Deo Chaning");
        }
        else
        {
            Debug.Log("isChaning");
            StartCoroutine(ChangePage(next));
            PageCUrr += direct;

        }



    }
    public IEnumerator ChangePage(bool next)
    {
        int j = next ? -1 : 1;
    //    float space = 0;
        isChaning = true;
        List<Vector2> Target = new List<Vector2>();

        for(int i = 0; i < Pages.Count; i++)
        {
            
            Vector2 TargetPos = (Vector2)Pages[i].transform.position + (Vector2.right * 720*j);
            Target.Add(TargetPos);
        }

        while(Target[0].x != Pages[0].transform.position.x)
        {
           
            for (int i = 0; i < Pages.Count; i++)
            {


                Pages[i].transform.position = Vector2.MoveTowards((Vector2)Pages[i].transform.position, Target[i],Time.deltaTime*speed);

              
               
            }
          //  Debug.Log(space);
           // space += speed;
            yield return new WaitForSeconds(0);
           
        }
        ActiveDot(PageCUrr);

        isChaning = false;
        
    }
    public void ActiveDot(int page)
    {
        for(int i = 0; i < Dots.Count; i++)
        {
            if (i == page)
            {
                Dots[i].Active();
            }
            else
            {
                Dots[i].UnActive();
            }
        }
    }

    public void ShowInfor(int select)
    {
         
    }

    public void SaveShop() 
    {
        List<SaveSkin> Save = new List<SaveSkin>();


        for(int i = 0; i < ListSkins.Count; i++)
        {
            SaveSkin save = new SaveSkin(ListSkins[i].id, ListSkins[i].isBuy, ListSkins[i].isUse);   
        }

        DataSave saves = new DataSave(Save);
        string s = JsonUtility.ToJson(saves);
        PlayerPrefs.SetString(key_Shop, s);
        PlayerPrefs.Save();
    }

    public List<SaveSkin> LoadData()
    {
        return JsonUtility.FromJson<DataSave>(PlayerPrefs.GetString(key_Shop)).List;
    }



    public void Buy()
    {
        for(int i = 0; i < ListSkins.Count ; i++)
        {
            if(ListSkins[i].id == SelectCurr)
            {
                if(ListSkins[i].cost <= Ctrl_Player.Ins.GetDiamond())
                {
                    Ctrl_Player.Ins.EarnDiamond(ListSkins[i].cost);
                    ListSkins[i].isBuy = true;

                }
                SaveShop();

            }
        }
    }
   
}
[System.Serializable]
public class DataSave
{
    public List<SaveSkin> List = new List<SaveSkin>();
    public DataSave(List<SaveSkin> ListSave)
    {
        this.List = ListSave;
    }

}

[System.Serializable]
public class SaveSkin
{
    public int id;
   
    public bool buy;
    public bool use;
    public SaveSkin(int id, bool buy, bool use)
    {
        this.id = id;
        
        this.buy = buy;
        this.use = use;
    }

}