using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Spawn : MonoBehaviour
{
    public static Ctrl_Spawn Ins;
   
    public List<GameObject> PrebObjGame;
    public List<Process> ListProcessGame;


    public List<Transform> Right;
    public List<Transform> Left;
    public float offsetX;


    public Transform TransGamePlay;
    public Transform TransRenderProcess;



    float distanceLeft;
    float distanceRight;
    Vector2 PosRight;
    Vector2 PosLeft;

    public int PerBasketNone;
    public int PerBasketMove;
    public int PerBasketChangeZize;
    public int PerBasketChangeZizevsMove;
    public int PerBasketX2;
    public int PerBasketX3;

    public float distanceMove;
    public float offset;



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

   



    public void SetUpPerBasket(int PerBasketNone,int PerBasketMove,int PerBasketChangeZie,int PerBasketChangeZizevsMove, int PerBasketX2,int PerBasketX3)
    {

        this.PerBasketNone = PerBasketNone;
        this.PerBasketMove = PerBasketMove;
        this.PerBasketChangeZize = PerBasketChangeZie;
        this.PerBasketChangeZizevsMove = PerBasketChangeZizevsMove;
        this.PerBasketX2 = PerBasketX2;
        this.PerBasketX3 = PerBasketX3;
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


    public void SetUpLevel(int level)
    {
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
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;
            case 2:
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;
            case 3:
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;
            case 4:
                SetUpPerBasket(0,100, 0, 0, 0, 0);
                break;
            case 5:
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;
            case 6:
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;
            case 7:
                SetUpPerBasket(0, 0, 100, 0, 0, 0);
                break;
            case 8:
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;
            case 9:
                SetUpPerBasket(0, 0, 0, 0, 100, 0);
                break;
            case 10:
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;
            case 11:
                SetUpPerBasket(0, 100, 0, 0, 0, 0);
                break;
            case 12:
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;
            case 13:
                SetUpPerBasket(0, 0, 100, 0, 0, 0);
                break;
            case 14:
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;
            case 15:
                SetUpPerBasket(0, 0, 0, 0, 0, 100);
                break;
            case 16:
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;
            case 17:
                SetUpPerBasket(0, 100, 0, 0, 0, 0);
                break;
            case 18:
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;
            case 19:
                SetUpPerBasket(0, 0, 0, 100, 0, 0);
                break;
            case 40:
                SetUpPerBasket(25,22,16,5,18,14);
                break;
            case 60:
                SetUpPerBasket(20, 22, 16, 8, 16, 18);
                break;
            case 61:
                SetUpPerBasket(15, 18, 17, 14, 18, 18);
                break;
            default:
                SetUpPerBasket(100, 0, 0, 0, 0, 0);
                break;

        }
       
    }

    public void InitRenderLive(int live)
    {
        for(int i = live; i >0; i--)
        {
            var a = Instantiate(PrebObjGame[3], TransRenderProcess);
            Process p = a.GetComponent<Process>();
            p.idProcess = i;
            ListProcessGame.Add(p);

        }
    }
}
