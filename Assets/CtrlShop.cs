using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeShop { Skin,FLipepr,BG}
public class CtrlShop : MonoBehaviour
{

    public TypeShop type;
    public const string key_Shop_Skin = "Key_Shop_Skin";
    public const string key_Shop_Flipper = "Key_Shop_Flipper";
    public const string Key_Shop_BG = "Key_Shop_BG";
    public static CtrlShop Ins;

    public static int SelectCurr;
    
    public GameObject Page;
   
    public GameObject Skin;
    public GameObject Flipper;
    public GameObject BG;
    public GameObject Dot;
    public List<Actice_Change_Page> Pages = new List<Actice_Change_Page>();
    public List<Actice_Change_Page> Pages_Flipper = new List<Actice_Change_Page>();
    public List<Actice_Change_Page> Pages_BG = new List<Actice_Change_Page>();
    public List<SkinBall> ListSkins = new List<SkinBall>();
    public List<SkinBall> ListFlipper = new List<SkinBall>();
    public List<SkinBall> ListBG = new List<SkinBall>();
    public List<Dot> Dots = new List<Dot>();
    public List<Dot> Dots_Flipper = new List<Dot>();
    public List<Dot> Dot_BG = new List<Dot>();
    public Transform transShop;
   
    public Transform transDot;

    public Transform tranShopFlipper;
    public Transform transDotFlipper;
    public Transform transShopBG;
    public Transform transShopDotBG;
    public Image ShowSKin;
    public Image ShowSKinFlipper;
    public Image ShowSkinBG;
    public float space;
    public bool isChangePage=false;
    public bool isChaning=false;
    public Vector2 InitPos;
    public int PageCUrr;
    public int PageCurr_Flipper;
    public int PageCurr_BG;
    public int direct = 0;
    public float speed;
    public bool isOpenShop = false;

    public Dictionary<int, List<GameObject>> SkinPerPage = new Dictionary<int, List<GameObject>>();
    public Dictionary<int, List<GameObject>> SkinPerPage_Flipper = new Dictionary<int, List<GameObject>>();
    public Dictionary<int, List<GameObject>> SkinPerPage_BG = new Dictionary<int, List<GameObject>>();
    List<Vector2> PosInitPageSkin = new List<Vector2>();
    List<Vector2> PosInitPageFlipper = new List<Vector2>();
    List<Vector2> PosInitPageBG = new List<Vector2>();

    public List<Transform> TypeChose_Skin;
    public List<Transform> TypeChose_Flipper;
    public List<Transform> TypeChose_BG;

    public delegate void Lock_Ball();
    public delegate void Lock_Flipper();
    public delegate void Lock_BG();
    public event Lock_Ball eventlockBall;
    public event Lock_Flipper eventlockFLipper;
    public event Lock_BG eventlockBG;




    public void Open(int chose,List<Transform> trans)
    {
        for(int i = 0; i < trans.Count; i++)
        {
            if (i == chose)
            {
                trans[i].gameObject.SetActive(true);
            }
            else
            {
                trans[i].gameObject.SetActive(false);
            }
        }
    }
    public void SelectType(int i)
    {
        switch (type) 
        
        {

            case TypeShop.BG:
                switch (i)
                {
                    case 0:
                        Open(0, TypeChose_BG);
                        break;
                        
                    case 1:
                        Open(2, TypeChose_BG);
                        break;
                    case 2:
                        Open(2, TypeChose_BG);
                        break;
                  

                      
                }
                break;
            case TypeShop.FLipepr:
                switch (i)
                {
                    case 0:
                        Open(0, TypeChose_Flipper);
                        break;
                    case 1:
                        Open(0, TypeChose_Flipper);
                        break;
                    case 2:
                        Open(1, TypeChose_Flipper);
                        break;
                    case 3:
                        Open(2, TypeChose_Flipper);
                        break;
                }
                break;
               
            case TypeShop.Skin:
                switch (i)
                {
                    case 0:
                        Open(0, TypeChose_Skin);
                        break;
                    case 1:
                        Open(0, TypeChose_Skin);
                        break;
                    case 2:
                        Open(1, TypeChose_Skin);
                        break;

                     case 3:
                        Open(2, TypeChose_Skin);
                        break;
                }
                break;
         
              
        }
    }


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
        LoadShopSkin();
        LoadShopFLipper();
        LoadShopBG();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpenShop)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            CtrlShop.Ins.InitPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            CtrlShop.Ins.isChangePage = false;
           
        }

        if (isChangePage)
        {
            if (!isChaning)
            {
                Vector2 mouse = Input.mousePosition;

                Debug.Log((Vector2.Distance((mouse), (InitPos))));
                if (Vector2.Distance((mouse), ( InitPos)) > 70)
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

    public void LoadingShop()
    {
        int idSkin = 0;
        int idFlipper = 0;
        int idBG = 0;
        idSkin = Ctrl_Player.Ins.GetSkinBallUse();
        idFlipper = Ctrl_Player.Ins.GetSkinFlipperUse();
        idBG = Ctrl_Player.Ins.GetSkinBGUse();
       
        Debug.Log(idSkin + "  " + idFlipper + "  " + idBG);
        for (int i = 0; i < ListSkins.Count; i++)
        {
            if (ListSkins[i].isBuy)
            {
                ListSkins[i].Select();

            }
            Debug.Log("id : " + ListSkins[i].id);
           
            
          
        }

        for (int i = 0; i < ListSkins.Count; i++)
        {
           // Debug.Log("id : " + ListSkins[i].id);
            if (ListSkins[i].id == idSkin)
            {
                ShowSKin.sprite = ListSkins[i].Skin.sprite;
                ListSkins[i].Use(true);
            }
            else
            {
                ListSkins[i].Use(false);
            }

           
          



        }


        for (int j = 0; j < ListFlipper.Count; j++)
        {
            if (ListFlipper[j].isBuy)
            {
                ListFlipper[j].Select();
            }
          
        }

        for (int i = 0; i < ListFlipper.Count; i++)
        {
         //   Debug.Log("id : " + ListFlipper[i].id);
            if (ListFlipper[i].id == idFlipper)
            {
                ShowSKinFlipper.sprite = ListFlipper[i].Skin.sprite;
                ListFlipper[i].Use(true);
            }
            else
            {
                ListFlipper[i].Use(false);
            }


        }

        for (int j = 0; j < ListBG.Count; j++)
        {
            if (ListBG[j].isBuy)
            {
                ListBG[j].Select();
            }
          
        }

        for (int i = 0; i < ListBG.Count; i++)
        {
            //   Debug.Log("id : " + ListFlipper[i].id);
            if (ListBG[i].id == idBG)
            {
                ShowSkinBG.sprite = ListBG[i].Skin.sprite;
                ListBG[i].Use(true);
            }
            else
            {
                ListBG[i].Use(false);
            }


        }


    }

    public void Init()
    {
        PlayerPrefs.DeleteKey(key_Shop_Skin);
        PlayerPrefs.DeleteKey(key_Shop_Flipper);
         PlayerPrefs.DeleteKey(Key_Shop_BG);
        if (!PlayerPrefs.HasKey(key_Shop_Skin))
        {
            // Load_Skin
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

                PlayerPrefs.SetString(key_Shop_Skin, json);
                PlayerPrefs.Save();
              
            }
        }
        if (!PlayerPrefs.HasKey(key_Shop_Flipper))
        {
            List<SaveSkin> Saves = new List<SaveSkin>();
            var a = Ctrl_Player.Ins.DataGame.flipper;
            for (int i = 0; i < a.Count; i++)
            {
                SaveSkin skin;
                if (i == 0)
                {
                    skin = new SaveSkin(i, true, true);
                }
                else
                {
                    skin = new SaveSkin(i, false, false);
                }
                Saves.Add(skin);
                DataSave data = new DataSave(Saves);
                string json = JsonUtility.ToJson(data);

                PlayerPrefs.SetString(key_Shop_Flipper, json);
                PlayerPrefs.Save();

            }
        }

        // BG

        if (!PlayerPrefs.HasKey(Key_Shop_BG))
        {
            List<SaveSkin> Saves = new List<SaveSkin>();
            var a = Ctrl_Player.Ins.DataGame.BG;
            for(int i = 0; i < a.Count; i++)
            {
                SaveSkin skin;
                if (i == 0)
                {
                    skin = new SaveSkin(i, true, true);
                }
                else
                {
                    skin = new SaveSkin(i, false, false);
                }
                Saves.Add(skin);
                DataSave data = new DataSave(Saves);
                string json = JsonUtility.ToJson(data);
                PlayerPrefs.SetString(Key_Shop_BG, json);
                PlayerPrefs.Save();
            }
        }
       
    }
   

    public void InitPoint(Vector2 point)
    {
        isChangePage = true;
        InitPos = point;
    }
    

    public void LoadShopFLipper()
    {
      
        PageCurr_Flipper = 0;
        var datasave = LoadDataFlipper();
        Debug.Log("Flipper : " + datasave.Count);
        Debug.Log("CO : " + datasave.Count);
        float CountPage = Ctrl_Player.Ins.DataGame.flipper.Count / 9;

        var a2 = Ctrl_Player.Ins.DataGame.flipper;

        int total = a2.Count;

        SkinPerPage_Flipper = new Dictionary<int, List<GameObject>>();

        for (int i = 0; i < CountPage; i++)
        {
            SkinPerPage_Flipper.Add(i, new List<GameObject>());
        }



        for (int i = 0; i < CountPage; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var a1 = Instantiate(Flipper);
                a1.transform.localScale = Vector3.one;
                SkinPerPage_Flipper[i].Add(a1);
            }



        }


        for (int i = 0; i < CountPage; i++)
        {


            var a = Instantiate(Page, tranShopFlipper);
            a.transform.localPosition = new Vector2(space * i, 0);
            PosInitPageFlipper.Add(a.transform.localPosition);
          

            a.GetComponent<Actice_Change_Page>().id = i;
            Pages_Flipper.Add(a.GetComponent<Actice_Change_Page>());

            List<GameObject> ListBall = SkinPerPage_Flipper[i];

            for (int j = 0; j < ListBall.Count; j++)
            {
                ListBall[j].transform.parent = a.transform;
                ListFlipper.Add(ListBall[j].GetComponent<SkinBall>());

            }

        }

        for (int i = 0; i < ListFlipper.Count; i++)
        {
          //  Debug.Log(i);
           ListFlipper[i].Load(datasave[i].id, datasave[i].buy, datasave[i].use, a2[i].cost, a2[i].Skin);
            if (ListFlipper[i].isBuy)
            {
                ListFlipper[i].Select();
            }

        }


        for (int i = 0; i < Pages_Flipper.Count; i++)
        {
            var a1 = Instantiate(Dot, transDotFlipper);
            Dots_Flipper.Add(a1.GetComponent<Dot>());
        }
        Active_Dot_Flipper(PageCurr_Flipper);


    }
    public void LoadShopSkin()
    {
                         ///Skin
        PageCUrr = 0;
        var datasave = LoadDataSkin();
        Debug.Log("CO : "+datasave.Count);
        float CountPage = Ctrl_Player.Ins.DataGame.ball.Count/9;
       
        var a2 = Ctrl_Player.Ins.DataGame.ball;

        int total = a2.Count;

        SkinPerPage = new Dictionary<int, List<GameObject>>();

        for(int i = 0; i < CountPage; i++)
        {
            SkinPerPage.Add(i, new List<GameObject>());
        }
        
        for(int i = 0; i <CountPage; i++)
        {
           for(int j = 0; j < 9; j++)
            {
                var a1 = Instantiate(Skin);
                a1.transform.localScale = Vector3.one;
                SkinPerPage[i].Add(a1);
            }
                
        }
      
        for(int i = 0; i < CountPage; i++)
        {
            var a = Instantiate(Page,transShop);
            a.transform.localPosition = new Vector2(space * i, 0);
            PosInitPageSkin.Add(a.transform.localPosition);
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
           // Debug.Log(i);
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
        //Flipper

    }

    public void LoadShopBG()
    {
        PageCurr_BG = 0;
        var datasave = LoadDataBG();
        Debug.Log("CO : " + datasave.Count);
        float CountPage = Ctrl_Player.Ins.DataGame.BG.Count / 9;

        var a2 = Ctrl_Player.Ins.DataGame.BG;

        int total = a2.Count;

        SkinPerPage_BG = new Dictionary<int, List<GameObject>>();

        for (int i = 0; i < CountPage; i++)
        {
            SkinPerPage_BG.Add(i, new List<GameObject>());
        }

        for (int i = 0; i < CountPage; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var a1 = Instantiate(BG);
                a1.transform.localScale = Vector3.one;
                SkinPerPage_BG[i].Add(a1);
            }

        }
        Debug.Log("PAGE  : " + CountPage);
        for (int i = 0; i < CountPage; i++)
        {
            var a = Instantiate(Page, transShopBG);
            a.transform.localPosition = new Vector2(space * i, 0);
            PosInitPageSkin.Add(a.transform.localPosition);
            a.GetComponent<Actice_Change_Page>().id = i;
            Pages_BG.Add(a.GetComponent<Actice_Change_Page>());

            List<GameObject> ListBall = SkinPerPage_BG[i];

            for (int j = 0; j < ListBall.Count; j++)
            {
                ListBall[j].transform.parent = a.transform;
                ListBG.Add(ListBall[j].GetComponent<SkinBall>());

            }
        }

        for (int i = 0; i < ListBG.Count; i++)
        {
            // Debug.Log(i);
            ListBG[i].Load(datasave[i].id, datasave[i].buy, datasave[i].use, a2[i].cost , a2[i].Skin);
            if (ListBG[i].isBuy)
            {
                ListBG[i].Select();
            }

        }
        for (int i = 0; i < Pages_BG.Count; i++)
        {
            var a1 = Instantiate(Dot, transShopDotBG);
            Dot_BG.Add(a1.GetComponent<Dot>());
        }
        ActiveDot_BG(PageCurr_BG);
        //Flipper
    }

    public void RenderPage(bool next)
    {
        switch (type)
        {
            case TypeShop.Skin:
                int direct = next ? 1 : -1;
                Debug.Log("DDD");
                if ((PageCUrr + direct) >= Pages.Count || (PageCUrr + direct) < 0)
                {
                    Debug.Log("Deo Chaning");
                }
                else
                {
                    Debug.Log("isChaning");
                    StartCoroutine(ChangePage(next));
                    PageCUrr += direct;

                }
                break;
            case TypeShop.FLipepr:
                int direct_flipper = next ? 1 : -1;
                Debug.Log("DDD");
                if ((PageCurr_Flipper + direct_flipper) >= Pages_Flipper.Count || (PageCurr_Flipper + direct_flipper) < 0)
                {
                    Debug.Log("Deo Chaning");
                }
                else
                {
                    Debug.Log("isChaning");
                    StartCoroutine(ChangePage(next));
                    PageCurr_Flipper += direct_flipper;

                }
                break;

            case TypeShop.BG:
                int direct_BG = next ? 1 : -1;
                Debug.Log("DDD");
                if ((PageCurr_BG + direct_BG) >= Pages_BG.Count || (PageCurr_BG + direct_BG) < 0)
                {
                    Debug.Log("Deo Chaning");
                }
                else
                {
                    Debug.Log("isChaning");
                    StartCoroutine(ChangePage(next));
                    PageCurr_BG += direct_BG;

                }
                break;

        }
      



    }
    public IEnumerator ChangePage(bool next)
    {
        int j = next ? -1 : 1;
    //    float space = 0;
        isChaning = true;
        List<Vector2> Target = new List<Vector2>();

        switch (type) 
        
        {
            case TypeShop.FLipepr:

                for (int i = 0; i < Pages_Flipper.Count; i++)
                {

                    Vector2 TargetPos = (Vector2)Pages_Flipper[i].transform.localPosition + (Vector2.right * space * j);
                    Target.Add(TargetPos);
                    Debug.Log(Pages[i].transform.position.x + " :: " + Pages[i].transform.position.y);
                }

                while (Target[0].x != Pages_Flipper[0].transform.localPosition.x)
                {

                    for (int i = 0; i < Pages_Flipper.Count; i++)
                    {


                        Pages_Flipper[i].transform.localPosition = Vector2.MoveTowards((Vector2)Pages_Flipper[i].transform.localPosition, (Vector2)Target[i], Time.deltaTime * speed);



                    }
                    //  Debug.Log(space);
                    // space += speed;
                    yield return new WaitForSeconds(0);

                }
                Active_Dot_Flipper(PageCurr_Flipper);
                SelectType(PageCurr_Flipper);
                isChaning = false;

                break;
            case TypeShop.Skin:
                for (int i = 0; i < Pages.Count; i++)
                {

                    Vector2 TargetPos = (Vector2)Pages[i].transform.localPosition + (Vector2.right * space * j);
                    Target.Add(TargetPos);
                    Debug.Log(Pages[i].transform.position.x + " :: " + Pages[i].transform.position.y);
                }

                while (Target[0].x != Pages[0].transform.localPosition.x)
                {

                    for (int i = 0; i < Pages.Count; i++)
                    {


                        Pages[i].transform.localPosition = Vector2.MoveTowards((Vector2)Pages[i].transform.localPosition, (Vector2)Target[i], Time.deltaTime * speed);



                    }
                    //  Debug.Log(space);
                    // space += speed;
                    yield return new WaitForSeconds(0);

                }
                SelectType(PageCUrr);
                ActiveDot(PageCUrr);
              
                isChaning = false;
                break;

            case TypeShop.BG:
                for (int i = 0; i < Pages_BG.Count; i++)
                {

                    Vector2 TargetPos = (Vector2)Pages_BG[i].transform.localPosition + (Vector2.right * space * j);
                    Target.Add(TargetPos);
                  //  Debug.Log(Pages[i].transform.position.x + " :: " + Pages[i].transform.position.y);
                }

                while (Target[0].x != Pages_BG[0].transform.localPosition.x)
                {

                    for (int i = 0; i < Pages_BG.Count; i++)
                    {


                        Pages_BG[i].transform.localPosition = Vector2.MoveTowards((Vector2)Pages_BG[i].transform.localPosition, (Vector2)Target[i], Time.deltaTime * speed);



                    }
                    //  Debug.Log(space);
                    // space += speed;
                    yield return new WaitForSeconds(0);

                }
                ActiveDot_BG(PageCurr_BG);
                SelectType(PageCurr_BG);
                isChaning = false;
                break;
          
        }
        
       
        
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
    public void ActiveDot_BG(int page)
    {
        for (int i = 0; i < Dot_BG.Count; i++)
        {
            if (i == page)
            {
                Dot_BG[i].Active();
            }
            else
            {
                Dot_BG[i].UnActive();
            }
        }
    }

    public void Active_Dot_Flipper(int page)
    {
        for (int i = 0; i < Dots_Flipper.Count; i++)
        {
            if (i == page)
            {
                Dots_Flipper[i].Active();
            }
            else
            {
                Dots_Flipper[i].UnActive();

            }
        }
    }

    public void ShowInfor(int select)
    {
        switch (type)
        {
            case TypeShop.FLipepr:
                if (ListFlipper[select].isBuy)
                {
                    for (int i = 0; i < ListFlipper.Count; i++)
                    {
                        if (ListSkins[i].id == select)
                        {
                            ShowSKinFlipper.sprite = ListFlipper[i].Skin.sprite;
                            Ctrl_Player.Ins.SetSkinFlipper(select);
                            ListFlipper[i].Use(true);


                        }
                        else
                        {
                            ListFlipper[i].Use(false);
                        }
                    }
                }
                
                break;
            case TypeShop.Skin:
                if (ListSkins[select].isBuy)
                {
                    for (int i = 0; i < ListSkins.Count; i++)
                    {
                        if (ListSkins[i].id == select)
                        {
                           
                            ListSkins[i].Use(true);
                            Ctrl_Player.Ins.SetSkinBall(select);
                            ShowSKin.sprite = ListSkins[i].Skin.sprite;

                        }
                        else
                        {
                            ListSkins[i].Use(false);
                        }
                    }
                }
                    
                break;
            case TypeShop.BG:
                if (ListBG[select].isBuy)
                {
                   for(int i = 0; i < ListBG.Count; i++)
                    {
                        if(ListBG[i].id == select)
                        {
                            ListBG[i].Use(true);
                            Ctrl_Player.Ins.SetSkinBG(select);
                            ShowSkinBG.sprite = ListBG[i].Skin.sprite;

                        }
                        else
                        {
                            ListBG[i].Use(false);
                        }
                        
                       
                    }


                }

                    break;
        }
       
    }

    

    public void SaveShop() 
    {
        List<SaveSkin> Save = new List<SaveSkin>();


        for(int i = 0; i < ListSkins.Count; i++)
        {
            SaveSkin save = new SaveSkin(ListSkins[i].id, ListSkins[i].isBuy, ListSkins[i].isUse);
            Save.Add(save);
        }

        DataSave saves = new DataSave(Save);
        string s = JsonUtility.ToJson(saves);
        PlayerPrefs.SetString(key_Shop_Skin, s);
        PlayerPrefs.Save();
    }
    public void SaveFliper()
    {
        List<SaveSkin> Save = new List<SaveSkin>();


        for (int i = 0; i < ListFlipper.Count; i++)
        {
            SaveSkin save = new SaveSkin(ListFlipper[i].id, ListFlipper[i].isBuy, ListFlipper[i].isUse);
            Save.Add(save);
        }

        DataSave saves = new DataSave(Save);
        string s = JsonUtility.ToJson(saves);
        PlayerPrefs.SetString(key_Shop_Flipper, s);
        PlayerPrefs.Save();
    }
    public void SaveBG()
    {
        List<SaveSkin> Save = new List<SaveSkin>();


        for (int i = 0; i < ListBG.Count; i++)
        {
            SaveSkin save = new SaveSkin(ListBG[i].id, ListBG[i].isBuy, ListBG[i].isUse);
            Save.Add(save);
        }

        DataSave saves = new DataSave(Save);
        string s = JsonUtility.ToJson(saves);
        PlayerPrefs.SetString(Key_Shop_BG, s);
        PlayerPrefs.Save();
    }


    public List<SaveSkin> LoadDataBG()
    {
        return JsonUtility.FromJson<DataSave>(PlayerPrefs.GetString(Key_Shop_BG)).List;
    }
    public List<SaveSkin> LoadDataSkin()
    {
        return JsonUtility.FromJson<DataSave>(PlayerPrefs.GetString(key_Shop_Skin)).List;
    }
    public List<SaveSkin> LoadDataFlipper()
    {
        return JsonUtility.FromJson<DataSave>(PlayerPrefs.GetString(key_Shop_Flipper)).List;
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

    public void UnclockRandom(int diamond)
    {
        for (int i = 0; i < ListSkins.Count; i++)
        {
            if (ListSkins[i].id == SelectCurr)
            {
                if (ListSkins[i].cost <= Ctrl_Player.Ins.GetDiamond())
                {
                    Ctrl_Player.Ins.EarnDiamond(ListSkins[i].cost);
                    ListSkins[i].isBuy = true;

                }
                SaveShop();

            }
        }
       
    }
    public void ResetShop()
    {
        for(int i = 0; i < Pages.Count; i++)
        {
            Pages[i].transform.localPosition = PosInitPageSkin[i];
        }
      
        for (int i = 0; i < Pages_Flipper.Count; i++)
        {
            Pages_Flipper[i].transform.localPosition = PosInitPageFlipper[i];
        }
        ActiveDot(0);
        Active_Dot_Flipper(0);
        PageCUrr = 0;
        PageCurr_Flipper = 0;

    }

    public void BuyRandomAds(int diamond)
    {
        switch (type)
        {
            case TypeShop.Skin:

                if (Ctrl_Player.Ins.GetDiamond() >= diamond)
                {
                    Ctrl_Player.Ins.EarnDiamond(diamond);
                    List<int> Random_Item = new List<int>();

                    for (int i = 0; i < 9; i++)
                    {
                        var a = SkinPerPage[PageCUrr][i].GetComponent<SkinBall>();
                        if (!a.isBuy)
                        {
                            Random_Item.Add(i);
                        }



                    }
                    if (Random_Item.Count != 0)
                    {
                        int r = Random.Range(0, Random_Item.Count);

                        SkinPerPage[PageCUrr][Random_Item[r]].GetComponent<SkinBall>().isBuy = true;
                        SkinPerPage[PageCUrr][Random_Item[r]].GetComponent<SkinBall>().Select();
                        SkinPerPage[PageCUrr][Random_Item[r]].GetComponent<SkinBall>().StartEFF();
                        Debug.Log("UNCLOCK : " + r);
                        SaveShop();
                        CtrlAudio.Ins.Play("UnClock");
                        GameMananger.Ins.ShowDiamond();
                        if (eventlockBall != null)
                        {
                            eventlockBall();
                        }

                    }
                    else
                    {
                        Debug.Log("Out Of Random");
                    }

                }
                else
                {
                    Debug.Log("Out of Diamond");
                }

                break;
            case TypeShop.FLipepr:
                if (Ctrl_Player.Ins.GetDiamond() >= diamond)
                {
                    Ctrl_Player.Ins.EarnDiamond(diamond);
                    List<int> Random_Item = new List<int>();

                    for (int i = 0; i < 9; i++)
                    {
                        var a = SkinPerPage_Flipper[PageCurr_Flipper][i].GetComponent<SkinBall>();
                        if (!a.isBuy)
                        {
                            Random_Item.Add(i);
                        }



                    }
                    if (Random_Item.Count != 0)
                    {
                        int r = Random.Range(0, Random_Item.Count);

                        SkinPerPage_Flipper[PageCurr_Flipper][Random_Item[r]].GetComponent<SkinBall>().isBuy = true;
                        SkinPerPage_Flipper[PageCurr_Flipper][Random_Item[r]].GetComponent<SkinBall>().Select();
                        SkinPerPage_Flipper[PageCurr_Flipper][Random_Item[r]].GetComponent<SkinBall>().StartEFF();
                        Debug.Log("UNCLOCK : " + r);
                        SaveFliper();
                        CtrlAudio.Ins.Play("UnClock");
                        GameMananger.Ins.ShowDiamond();
                        if (eventlockFLipper != null)
                        {
                            eventlockFLipper();
                        }
                    }
                    else
                    {
                        Debug.Log("Out Of Random");
                    }

                }
                else
                {
                    Debug.Log("Out of Diamond");
                }

                break;
            case TypeShop.BG:
                if (Ctrl_Player.Ins.GetDiamond() >= diamond)
                {
                    Ctrl_Player.Ins.EarnDiamond(diamond);
                    List<int> Random_Item = new List<int>();

                    for (int i = 0; i < 9; i++)
                    {
                        var a = SkinPerPage_BG[PageCurr_BG][i].GetComponent<SkinBall>();
                        if (!a.isBuy)
                        {
                            Random_Item.Add(i);
                        }



                    }
                    if (Random_Item.Count != 0)
                    {
                        int r = Random.Range(0, Random_Item.Count);

                        SkinPerPage_BG[PageCurr_BG][Random_Item[r]].GetComponent<SkinBall>().isBuy = true;
                        SkinPerPage_BG[PageCurr_BG][Random_Item[r]].GetComponent<SkinBall>().Select();
                        SkinPerPage_BG[PageCurr_BG][Random_Item[r]].GetComponent<SkinBall>().StartEFF();
                        Debug.Log("UNCLOCK : " + r);
                        SaveBG();
                        CtrlAudio.Ins.Play("UnClock");
                        GameMananger.Ins.ShowDiamond();

                        if (eventlockBG != null)
                        {
                            eventlockBG();
                        }
                    }
                    else
                    {
                        Debug.Log("Out Of Random");
                    }

                }
                else
                {
                    Debug.Log("Out of Diamond");
                }
                break;

        }

    }
    public void BuyRandom100Diamond(int diamond)
    {


        switch (type)
        {
            case TypeShop.Skin:
                
                if (Ctrl_Player.Ins.GetDiamond() >= diamond)
                {
                    Ctrl_Player.Ins.EarnDiamond(diamond);
                    List<int> Random_Item = new List<int>();

                for (int i = 0; i < 9; i++)
                {
                        var a = SkinPerPage[PageCUrr][i].GetComponent<SkinBall>();
                        if (!a.isBuy)
                        {
                            Random_Item.Add(i);
                        }

                       

                }
                    if (Random_Item.Count != 0)
                    {
                        int r = Random.Range(0, Random_Item.Count);

                        SkinPerPage[PageCUrr][Random_Item[r]].GetComponent<SkinBall>().isBuy = true;
                        SkinPerPage[PageCUrr][Random_Item[r]].GetComponent<SkinBall>().Select();
                        SkinPerPage[PageCUrr][Random_Item[r]].GetComponent<SkinBall>().StartEFF();
                        Debug.Log("UNCLOCK : " + r);
                        SaveShop();
                        CtrlAudio.Ins.Play("UnClock");
                        GameMananger.Ins.ShowDiamond();
                      

                    }
                    else
                    {
                        Debug.Log("Out Of Random");
                    }

                }
                else
                {
                    Debug.Log("Out of Diamond");
                }

                break;
            case TypeShop.FLipepr:
                if (Ctrl_Player.Ins.GetDiamond() >= diamond)
                {
                    Ctrl_Player.Ins.EarnDiamond(diamond);
                    List<int> Random_Item = new List<int>();

                    for (int i = 0; i < 9; i++)
                    {
                        var a = SkinPerPage_Flipper[PageCurr_Flipper][i].GetComponent<SkinBall>();
                        if (!a.isBuy)
                        {
                            Random_Item.Add(i);
                        }



                    }
                    if (Random_Item.Count != 0)
                    {
                        int r = Random.Range(0, Random_Item.Count);

                        SkinPerPage_Flipper[PageCurr_Flipper][Random_Item[r]].GetComponent<SkinBall>().isBuy = true;
                        SkinPerPage_Flipper[PageCurr_Flipper][Random_Item[r]].GetComponent<SkinBall>().Select();
                        SkinPerPage_Flipper[PageCurr_Flipper][Random_Item[r]].GetComponent<SkinBall>().StartEFF();
                        Debug.Log("UNCLOCK : " + r);
                        SaveFliper();
                        CtrlAudio.Ins.Play("UnClock");
                        GameMananger.Ins.ShowDiamond();
                     
                    }
                    else
                    {
                        Debug.Log("Out Of Random");
                    }

                }
                else
                {
                    Debug.Log("Out of Diamond");
                }

                break;
            case TypeShop.BG:
                if (Ctrl_Player.Ins.GetDiamond() >= diamond)
                {
                    Ctrl_Player.Ins.EarnDiamond(diamond);
                    List<int> Random_Item = new List<int>();

                    for (int i = 0; i < 9; i++)
                    {
                        var a = SkinPerPage_BG[PageCurr_BG][i].GetComponent<SkinBall>();
                        if (!a.isBuy)
                        {
                            Random_Item.Add(i);
                        }



                    }
                    if (Random_Item.Count != 0)
                    {
                        int r = Random.Range(0, Random_Item.Count);

                        SkinPerPage_BG[PageCurr_BG][Random_Item[r]].GetComponent<SkinBall>().isBuy = true;
                        SkinPerPage_BG[PageCurr_BG][Random_Item[r]].GetComponent<SkinBall>().Select();
                        SkinPerPage_BG[PageCurr_BG][Random_Item[r]].GetComponent<SkinBall>().StartEFF();
                        Debug.Log("UNCLOCK : " + r);
                        SaveBG();
                        CtrlAudio.Ins.Play("UnClock");
                        GameMananger.Ins.ShowDiamond();

                      
                    }
                    else
                    {
                        Debug.Log("Out Of Random");
                    }

                }
                else
                {
                    Debug.Log("Out of Diamond");
                }
                break;
               
        }
       


    }

    public void BuyRandomSkinAds(int diamond)
    {

        ManagerAds.Ins.ShowRewardedVideo((open) =>
        {
            if (open)
            {
                BuyRandom100Diamond(diamond);
            }
         

        });

    }

    public void AddDiamond(int diamond)
    {
        ManagerAds.Ins.ShowRewardedVideo((active) =>
        {
            if (active)
            {
                Ctrl_Player.Ins.AddDiamond(diamond);
                GameMananger.Ins.ShowDiamond();
            }
           

        });
      
    }

    public void UnclockBall(int id)
    {
        CtrlAudio.Ins.Play("UnClock");
        ListSkins[id].isBuy = true;
        SaveShop();
    }

   
    public void UnlockFlipper(int id)
    {
        CtrlAudio.Ins.Play("UnClock");
        ListFlipper[id].isBuy = true;
        SaveFliper();
    }
    public Sprite UnclockBallRandom()
    {
        List<SkinBall> ListSkinBall = new List<SkinBall>();
        for (int i = 0; i < ListSkins.Count; i++)
        {
            if (!ListSkins[i].isBuy)
            {
                ListSkinBall.Add(ListSkins[i]);
            }

        }
        if (ListSkinBall.Count != 0)
        {
            int r = Random.Range(0, ListSkinBall.Count);
            UnclockBall(ListSkinBall[r].id);
            return ListSkinBall[r].Skin.sprite;

        }
        else
        {
            return null;
        }
        return null;
    }

    public Sprite GetUnclockBallRandom(out int id)
    {
        List<SkinBall> ListSkinBall = new List<SkinBall>();
        for (int i = 0; i < ListSkins.Count; i++)
        {
            if (!ListSkins[i].isBuy)
            {
                
                ListSkinBall.Add(ListSkins[i]);
            }

        }
        if (ListSkinBall.Count != 0)
        {
            int r = Random.Range(0, ListSkinBall.Count);
            id = ListSkins[ListSkinBall[r].id].id;
           
            return ListSkins[id].Skin.sprite;

        }
        else
        {
            id = -1;
            return null;
        }
        id = -1;
        return null;
    }
   

   


    public Sprite UnclocFlipperRandom()
    {
        List<SkinBall> ListFlipperBall = new List<SkinBall>();
        for (int i = 0; i < ListFlipper.Count; i++)
        {
            if (!ListFlipper[i].isBuy)
            {
                ListFlipperBall.Add(ListFlipper[i]);
            }

        }
        if (ListFlipperBall.Count != 0)
        {
            int r = Random.Range(0, ListFlipperBall.Count);
           UnlockFlipper(ListFlipperBall[r].id);
            return ListFlipperBall[r].Skin.sprite;

        }
        else
        {
            return null;
        }
        return null;
    }
    public Sprite GetUnclocFlipperRandom(out int id)
    {
        List<SkinBall> ListFlipperBall = new List<SkinBall>();
        for (int i = 0; i < ListFlipper.Count; i++)
        {
            if (!ListFlipper[i].isBuy)
            {
                ListFlipperBall.Add(ListFlipper[i]);
            }

        }
        if (ListFlipperBall.Count != 0)
        {
            int r = Random.Range(0, ListFlipperBall.Count);
            id = ListFlipper[ListFlipper[r].id].id;
            return ListFlipper[id].Skin.sprite;

        }
        else
        {
            id = -1;
            return null;
        }
        id = -1;
        return null;
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