using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public enum TypeItem { ChangeZie, x2_Score, Incre_Reflect,life};

public class Ctrl_Spawn : MonoBehaviour
{
    public static Ctrl_Spawn Ins;


    /// <summary>
    ///  ListObj
    /// </summary>

    public List<GameObject> PrebObjGame;
    public List<Process> ListProcessGame;
    public List<GameObject> ListItem;
    public List<Counter> ListCounterItem;
    public List<GameObject> Item;

    public List<Transform> Right;
    public List<Transform> Left;

    public float offsetX;

    public List<Sprite> Img_Counter;
    public Transform EffItem;
    public Transform TransGamePlay;
    public Transform TransRenderProcess;
    public Text TextLevelCurrr;


    float distanceLeft;
    float distanceRight;
    Vector2 PosRight;
    Vector2 PosLeft;

    /// <summary>
    /// Per Spawn
    /// </summary>
    public int PerBasketNone;
    public int PerBasketMove;
    public int PerBasketChangeZize;
    public int PerBasketChangeZizevsMove;
    public int PerBasketX2;
    public int PerBasketX3;

    public float distanceMove;
    public float offset;

    /// <summary>
    ///  Spawn Item
    /// </summary>

    public float timeSpawnItem;
    public bool isSpawnItem;
    public int PrecSpawnItem;


    private float time;

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
        CtrlGamePlay.Ins.eventForStartGame += SetUpLevel;
        CtrlGamePlay.Ins.eventForStartGame += InitRenderLive;
        CtrlGamePlay.Ins.eventClearObj += DestroyAll;
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        PosRight = Right[0].transform.position;
        PosLeft = Left[0].transform.position;
        distanceLeft = Vector2.Distance(Left[0].transform.position, Left[1].transform.position);
        distanceRight = Vector2.Distance(Right[0].transform.position, Right[1].transform.position);
       
      
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetUpMove(true,true,false,3);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RandomEff();
        }

        if (isSpawnItem)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                RandomEff();
                isSpawnItem = false;
            }
           
        }
    }

     

    public void SpawnBasket(bool isLeft,bool isChangeSize)
    {
        int i = isLeft ? -1 : 1;

        if (isLeft)
        {
            Vector2 pos = (Vector2)Left[0].transform.position - Vector2.up * Random.Range(0, distanceLeft) + Vector2.right*offsetX*i;


            var a =    Instantiate(PrebObjGame[0],pos,Quaternion.identity,TransGamePlay);
            
            a.GetComponent<Basket>().Start_Move_Spawn(pos.x - (offsetX * i));
            if (isChangeSize)
            {
                a.GetComponent<Basket>().SetUpChangeSize();
            }
          

        }
        else
        {
            Vector2 pos = (Vector2)Right[0].transform.position - Vector2.up * Random.Range(0, distanceRight) + Vector2.right*offsetX*i;

          var a =   Instantiate(PrebObjGame[1],pos,Quaternion.identity,TransGamePlay);
            a.GetComponent<Basket>().Start_Move_Spawn(pos.x - (offsetX * i));
            if (isChangeSize)
            {
                a.GetComponent<Basket>().SetUpChangeSize();
            }


        }
    }

   



    public void SetUpPerBasket(int PerBasketNone,int PerBasketMove,int PerBasketChangeZie,int PerBasketChangeZizevsMove, int PerBasketX2,int PerBasketX3,int target)
    {

        this.PerBasketNone = PerBasketNone;
        this.PerBasketMove = PerBasketMove;
        this.PerBasketChangeZize = PerBasketChangeZie;
        this.PerBasketChangeZizevsMove = PerBasketChangeZizevsMove;
        this.PerBasketX2 = PerBasketX2;
        this.PerBasketX3 = PerBasketX3;
        CtrlGamePlay.Ins.TargetLevel = target;
    }

    public void SetUpMove(bool isLeft,bool isChangeSize,bool isMove,int countBasket)
    {
        int i = isLeft ? -1 : 1;
        Vector2 pos = Vector2.zero;
        bool isFind = false;

        if (isMove)
        {


            while (!isFind)
            {

                if (isLeft)
                {

                    pos = (Vector2)Left[0].transform.position - Vector2.up * Random.Range(0, distanceLeft) + Vector2.right * offsetX * i;
                    if ((pos.y - (distanceMove * countBasket)) <= Left[1].transform.position.y)
                    {
                        isFind = false;
                    }
                    else
                    {
                        isFind = true;
                    }
                }
                else
                {
                    pos = (Vector2)Right[0].transform.position - Vector2.up * Random.Range(0, distanceRight) + Vector2.right * offsetX * i;
                    if ((pos.y - (distanceMove * countBasket)) <= Right[1].transform.position.y)
                    {
                        isFind = false;
                    }
                    else
                    {
                        isFind = true;
                    }
                }


            }

        }
        else
        {
            if (countBasket > 1)
            {
                while (!isFind)
                {

                    if (isLeft)
                    {

                        pos = (Vector2)Left[0].transform.position - Vector2.up * Random.Range(0, distanceLeft) + Vector2.right * offsetX * i;
                        if ((pos.y - (distanceMove * countBasket)) <= Left[1].transform.position.y)
                        {
                            isFind = false;
                        }
                        else
                        {
                            isFind = true;
                        }
                    }
                    else
                    {
                        pos = (Vector2)Right[0].transform.position - Vector2.up * Random.Range(0, distanceRight) + Vector2.right * offsetX * i;
                        if ((pos.y - (distanceMove * countBasket)) <= Right[1].transform.position.y)
                        {
                            isFind = false;
                        }
                        else
                        {
                            isFind = true;
                        }
                    }


                }
            }
            else
            {

                if (isLeft)
                {
                     pos = (Vector2)Left[0].transform.position - Vector2.up * Random.Range(0, distanceLeft) + Vector2.right * offsetX * i;
                     

                }
                else
                {
                     pos = (Vector2)Right[0].transform.position - Vector2.up * Random.Range(0, distanceRight) + Vector2.right * offsetX * i;

                 

                }
            }

        }
        if (countBasket>1)
        {
            for (int z = 1; z <= countBasket; z++)
            {


                if (isLeft)
                {
                    float x0 = (pos.y * z);
                   
                    pos.y = x0;
                    var a = Instantiate(PrebObjGame[0], pos, Quaternion.identity, TransGamePlay);
                    a.GetComponent<Basket>().Start_Move_Spawn(pos.x - (offsetX * i));
                  
                    if (isMove)
                    {
                        float x1 = x0 - (z * distanceMove);
                        a.GetComponent<Basket>().SetUpMove(x1, x0);
                        if (isChangeSize)
                        {
                            a.GetComponent<Basket>().SetUpChangeSize();
                        }
                    }
                    if (isChangeSize)
                    {
                        a.GetComponent<Basket>().SetUpChangeSize();
                    }
                }
                else
                {
                    float x0 = (pos.y * z);
                    
                    pos.y = x0;
                    var a = Instantiate(PrebObjGame[1], pos, Quaternion.identity, TransGamePlay);
                    a.GetComponent<Basket>().Start_Move_Spawn(pos.x - (offsetX * i));
                    if (isMove)
                    {
                        float x1 = x0 - (z * distanceMove);
                        a.GetComponent<Basket>().SetUpMove(x1, x0);
                        if (isChangeSize)
                        {
                            a.GetComponent<Basket>().SetUpChangeSize();
                        }
                    }
                  
                }
            }



        }
        else
        {
            if (isLeft)
            {
              


                var a = Instantiate(PrebObjGame[0], pos, Quaternion.identity, TransGamePlay);

                a.GetComponent<Basket>().Start_Move_Spawn(pos.x - (offsetX * i));
                if (isChangeSize)
                {
                    a.GetComponent<Basket>().SetUpChangeSize();
                }


            }
            else
            {
             

                var a = Instantiate(PrebObjGame[1], pos, Quaternion.identity, TransGamePlay);
                a.GetComponent<Basket>().Start_Move_Spawn(pos.x - (offsetX * i));
                if (isChangeSize)
                {
                    a.GetComponent<Basket>().SetUpChangeSize();
                }


            }

        }
      





    }



    


    public void SetUpSpawnBasket()
    {
        int r = Random.Range(0,6);

        if (r == 0)
        {
            isSpawnItem = true;
            time = timeSpawnItem;


        }
        else
        {
            isSpawnItem = false;
        }


        bool isLeft = (0 == Random.Range(0, 2)) ? true : false;
       
        TypeBasket typeBasket = RandomBasket();
        switch (typeBasket)
        {
            case TypeBasket.None:
                SpawnBasket(isLeft, false);
                break;
            case TypeBasket.Change_Size:
                SpawnBasket(isLeft, true);
                break;
            case TypeBasket.Move:
                SetUpMove(isLeft, false,false,1);
                break;
            case TypeBasket.Change_Size_vs_Move:
                SetUpMove(isLeft, true, true, 1);

                break;
            case TypeBasket.X2:
                SetUpMove(isLeft, true, false, 2);
                break;
            case TypeBasket.x3:
                SpawnBasket(isLeft, false);
                break;
        }


    }

   

    public TypeBasket RandomBasket()
    {
        int r = Random.Range(0, 101);
      
       if(r>=0 && r <= PerBasketNone && PerBasketNone !=0)
        {
             return TypeBasket.None;
        }
        
        else if (r > PerBasketNone && r <= PerBasketMove &&PerBasketMove!=0)
        {
            return TypeBasket.Move;
         
        }else if(r > PerBasketMove && r<=PerBasketChangeZize && PerBasketChangeZize != 0)
        {
            return TypeBasket.Change_Size;
        }else if(r>PerBasketChangeZize && r <= PerBasketChangeZizevsMove)
        {
            return TypeBasket.Change_Size_vs_Move;
        }else if(r>PerBasketChangeZizevsMove && r <= PerBasketX2)
        {
            return TypeBasket.X2;
        }
        else
        {
            return TypeBasket.x3;

        }

    }

    

    public void SetUpLevel()
    {
        int level = Ctrl_Player.Ins.GetCurrLevel();

        Debug.Log("Level Curr : " + level);
        
        if (level > 19 && level<=40)
        {
            level = 40;
        }
        else if(level>40 && level<=60)
        {
            level = 60;
        }
        else if(level>=60)
        {
            level = 61;
        }

       
        switch (level)
        {
            case 1:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,3);
                break;
            case 2:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,3);
                break;
            case 3:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,3);
                break;
            case 4:
                SetUpPerBasket(0,100, 0, 0, 0, 0,3);
                break;
            case 5:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,3);
                break;
            case 6:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,3);
                break;
            case 7:
                SetUpPerBasket(0, 0, 100, 0, 0, 0,3);
                break;
            case 8:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,3);
                break;
            case 9:
                SetUpPerBasket(0, 0, 0, 0, 100, 0,3);
                break;
            case 10:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,3);
                break;
            case 11:
                SetUpPerBasket(0, 100, 0, 0, 0, 0,3);
                break;
            case 12:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,6);
                break;
            case 13:
                SetUpPerBasket(0, 0, 100, 0, 0, 0,6);
                break;
            case 14:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,6);
                break;
            case 15:
                SetUpPerBasket(0, 0, 0, 0, 0, 100,6);
                break;
            case 16:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,6);
                break;
            case 17:
                SetUpPerBasket(0, 100, 0, 0, 0, 0,6);
                break;
            case 18:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,6);
                break;
            case 19:
                SetUpPerBasket(0, 0, 0, 100, 0, 0,6);
                break;
            case 40:
                SetUpPerBasket(25,22,16,5,18,14,6);
                break;
            case 60:
                SetUpPerBasket(20, 22, 16, 8, 16, 18,6);
                break;
            case 61:
                SetUpPerBasket(15, 18, 17, 14, 18, 18,6);
                break;
            default:
                SetUpPerBasket(100, 0, 0, 0, 0, 0,6);
                break;

        }

        TextLevelCurrr.text = "LEVEL " + level;
       
    }

    public void InitRenderLive()
    {
        int live = CtrlGamePlay.Ins.TargetLevel;
        for(int i = live; i >0; i--)
        {
            var a = Instantiate(PrebObjGame[2], TransRenderProcess);
            Process p = a.GetComponent<Process>();
            p.idProcess = i;
            ListProcessGame.Add(p);


        }
    }
    public void CompleteProcess(int live)
    {
        for(int i = 0; i < ListProcessGame.Count; i++)
        {
            if (ListProcessGame[i].idProcess == live)
            {
                ListProcessGame[i].Complete();
            }
        }


    }

    public void RandomEff()
    {

        int index = Random.Range(0, Item.Count);

        Vector2 a = Random.insideUnitCircle*5;
        bool isFound = false;
        int count = 0;
        while (!isFound)
        {
            
            RaycastHit2D[] ray = Physics2D.BoxCastAll(a, Vector2.one*0.5f,0,Vector2.zero,0);

            bool isInBox = false;
            bool fail = false;
            for(int i = 0; i < ray.Length; i++)
            {

                if(ray[i].collider.gameObject.layer == 12)
                {
                    isInBox = true;
                }
                if (ray[i].collider.gameObject.layer != 12)
                {
                    fail = true;
                }
            }
            if(fail || !isInBox)
            {
                isFound = false;
                a = Random.insideUnitCircle * 5;
            }
            else
            {
                isFound = true;
            }


            Debug.Log(a.x + "  " + a.y);
        }


        var b = Instantiate(Item[index], a,Quaternion.identity,null);
        ListItem.Add(b);

    }
   

    

    public void Add_Counter_PowerUp(TypeItem item)
    {
        switch (item)
        {
            case TypeItem.ChangeZie:
                var a = Instantiate(PrebObjGame[3], EffItem);
                a.GetComponent<Image>().sprite = Img_Counter[1];
                a.GetComponent<Counter>().time = 10;
                ListCounterItem.Add(a.GetComponent<Counter>());
                break;
            case TypeItem.Incre_Reflect:
                var a2 = Instantiate(PrebObjGame[3], EffItem);
                a2.GetComponent<Image>().sprite = Img_Counter[2];
                a2.GetComponent<Counter>().time = 10;
                ListCounterItem.Add(a2.GetComponent<Counter>());
                break;
            case TypeItem.x2_Score:
                var a1 = Instantiate(PrebObjGame[3], EffItem);
               
                a1.GetComponent<Image>().sprite = Img_Counter[0];

                a1.GetComponent<Counter>().time = 10;
                ListCounterItem.Add(a1.GetComponent<Counter>());
                break;
                
        }
    }

    public void DestroyAll()
    {
        for(int i = 0; i < ListProcessGame.Count; i++)
        {
            ListProcessGame[i].GetComponent<DestroySelf>().Destroy();

        }
        for(int i = 0; i < ListCounterItem.Count; i++)
        {
            ListCounterItem[i].GetComponent<DestroySelf>().Destroy();
        }
        for(int i = 0; i < ListItem.Count; i++)
        {
            ListItem[i].GetComponent<DestroySelf>().Destroy();
        }
        ListProcessGame.Clear();
        ListCounterItem.Clear();
        ListItem.Clear();
      
    }
   
}
