using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public enum TypeBasket { None, Move, X2, x3, Change_Size, Change_Size_vs_Move };

public class Basket : PoolItem
{
    public TypeBasket type;
    public bool isLeft = false;

    public int Score;
    public bool X2_Score;
    public bool X2_Basket;
    public Transform Power_X2_Score;

    public CheckInBall checkInBall;
    public Text text;
    public Cloth ClothBasket;

    public bool isMove;
    public bool isChangeSize;
    public bool isMovevsChangeSize;

    public float RangeX;
    public float RangeY;
    public GameObject Key;

    Tweener AnimMove;
    Tweener AnimChangeSize;

    public GameObject EffGolbal;

    // Start is called before the first frame update
    void Start()
    {
        ClothSphereColliderPair[] collier = new ClothSphereColliderPair[1];
        collier[0].first = Ball.Ins.Box3D;

        collier[0].second = Ball.Ins.Box3D;
        ClothBasket.sphereColliders = collier;
        if (collier[0].first != null)
        {
            Debug.Log("Co");
        }
        else
        {
            Debug.Log("Ko Co");
        }

        OnSpawn();


        if (CtrlGamePlay.Ins.typeGame == TypeGamePlay.Level)
        {
            Ctrl_Spawn.Ins.SetUpRandomEff();
            
            if (!Ctrl_Player.Ins.isInGameisFullKey())
            {
              

                if (Ctrl_Spawn.Ins.isActiveKey())
                {
                    if(type == TypeBasket.Change_Size || type == TypeBasket.Change_Size_vs_Move)
                    {
                        Key.gameObject.SetActive(false);
                    }
                    else
                    {
                  //      Key.transform.parent = null;
                        Key.gameObject.SetActive(true);
                    }

                    
                   
                }
                else
                {
                    Key.gameObject.SetActive(false);
                }
            }
            else
            {
                Key.gameObject.SetActive(false);
            }

        }
        else
        {
            Key.gameObject.SetActive(false);
        }


    }


   


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            StopAll();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SetUpChangeSize();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            float x0 = transform.position.y;
            float x1 = transform.position.y - 4;
            SetUpMove(x0, x1);
        }


    }




    public void Die()
    {
        StopAll();

        float x = transform.position.x;
        if (isLeft)
        {
            Debug.Log("Destroy Left");
            transform.DOMoveX((x + 0.3f), 0.3f).OnComplete(() =>
            {
                transform.DOMoveX((x - 6), 0.6f).OnComplete(() =>
                {
                    Destroy();
                    CtrlGamePlay.Ins.CompleteProcessLevel();
                    //   OnDespawn();
                });

            });

        }
        else
        {
            if (isLeft)
            {
                Debug.Log("Destroy Right");
                transform.DOMoveX((x - 0.5f * CtrlGamePlay.scaleScreen), 0.5f).OnComplete(() =>
                {
                    transform.DOMoveX((x + 6) * CtrlGamePlay.scaleScreen, 0.6f).OnComplete(() =>
                    {
                        Destroy();
                        CtrlGamePlay.Ins.CompleteProcessLevel();
                        //   OnDespawn();
                    });

                });

            }
            else
            {
//Debug.Log("Right");
                transform.DOMoveX((x - 0.5f) * CtrlGamePlay.scaleScreen, 0.5f).OnComplete(() =>
                {
                    transform.DOMoveX((x + 6) * CtrlGamePlay.scaleScreen, 0.6f).OnComplete(() =>
                    {
                        Destroy();
                        CtrlGamePlay.Ins.CompleteProcessLevel();
                        //   OnDespawn();
                    });

                });


            }


        }

        CtrlGamePlay.Ins.basket.Remove(this);

    }
    public override void OnSpawn()
    {
        if (ClothBasket.sphereColliders == null)
        {


        }
        if (checkInBall == null)
        {
            checkInBall = GetComponent<CheckInBall>();
        }

       
        gameObject.SetActive(true);

    }
    public override void OnDespawn()
    {

        RemoveBasket();
        gameObject.SetActive(false);
        checkInBall.Restore();
    }

    public void Fuck()
    {

    }
    public void RemoveBasket()
    {
        CtrlGamePlay.Ins.basket.Remove(this);
    }

    public void AddBasket(Basket basket)
    {
        CtrlGamePlay.Ins.basket.Add(this);
    }

    public IEnumerator Start_X2_Score(float time)
    {
        CtrlAudio.Ins.Play("DoubleScore");
        X2_Score = true;
        try
        {
            CtrlGamePlay.Ins.isX2Score = true;
            Power_X2_Score.gameObject.SetActive(true);
        }
        catch (System.Exception e)
        {
            CtrlGamePlay.Ins.isX2Score = false;
        }

        yield return new WaitForSeconds(time);
        try
        {
            CtrlGamePlay.Ins.isX2Score = false;
            Power_X2_Score.gameObject.SetActive(false);
        }
        catch (System.Exception e)
        {
            CtrlGamePlay.Ins.isX2Score = false;
        }
        X2_Score = false;

        yield return new WaitForSeconds(0);

    }

    public IEnumerator Start_Power_Up_Basket(float time)
    {

        try
        {
            transform.DOScaleX(1.95f, 0.5f);
        }
        catch (System.Exception e)
        {

        }

       

        yield return new WaitForSeconds(time);
        try
        {
            transform.DOScaleX(1.5f, 0.5f);
        }
        catch (System.Exception e)
        {

        }

       
    }
    public int Left()
    {
        return isLeft ? -1 : 1;
    }
    public void Start_Move_Spawn(float x)
    {
        transform.DOMoveX(x, 0.5f * CtrlGamePlay.scaleScreen);
    }

    public void SetUpMove(float x0, float x1)
    {
        RangeX = x0;
        RangeY = x1;
        AnimMove = transform.DOMoveY(x0, 1).OnComplete(() =>
        {
            transform.DOScaleX(x1, 1);


        }).SetLoops(-1, LoopType.Yoyo);

    }


    public void SetUpChangeSize()
    {
        AnimChangeSize = transform.DOScaleX(2, 1).OnComplete(() =>
        {
            transform.DOScaleX(1.5f, 1);


        }).SetLoops(-1, LoopType.Yoyo);
    }

    public void StopAll()
    {
        StopAllCoroutines();
        if (AnimChangeSize != null)
        {
            AnimChangeSize.timeScale = 0;
        }
        if (AnimMove != null)
        {
            AnimMove.timeScale = 0;
        }


    }

    public void Destroy()
    {
        CtrlGamePlay.Ins.basket.Remove(this);
        Destroy(gameObject);
    }

    

}
