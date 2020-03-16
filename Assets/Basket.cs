using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum TypeBasket {None,Move,X2,x3,Change_Size,Change_Size_vs_Move};
public class Basket : PoolItem
{
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

    // Start is called before the first frame update
    void Start()
    {
       
        OnSpawn();
    }

    public void SetUpTypeBasket(TypeBasket type)
    {
        switch (type)
        {
            case TypeBasket.None:

                break;

            case TypeBasket.Move:
                break;

            case TypeBasket.X2:
                break;
            case TypeBasket.x3:
                break;
            case TypeBasket.Change_Size:
                break;
            case TypeBasket.Change_Size_vs_Move:
                break;


        }
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Start_Power_Up_Basket(1));
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SetUpChangeSize();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            float x0 =  transform.position.y;
            float x1 = transform.position.y-4;
            SetUpMove(x0,x1);
        }


    }

   


    public void Die()
    {
       // Fuck();
        float x = transform.position.x;
        if (isLeft)
        {
            transform.DOMoveX((x + 0.3f), 0.3f).OnComplete(() =>
            {
                transform.DOMoveX(x - 6, 0.6f).OnComplete(() =>
                {
                    Destroy(gameObject);

                 //   OnDespawn();
                });

            });

        }
        else
        {
            transform.DOMoveX((x - 0.3f), 0.3f).OnComplete(() =>
            {
                transform.DOMoveX(x + 6, 0.6f).OnComplete(() =>
                {
                    Destroy(gameObject);
                    //   OnDespawn();
                });

            });

        }

    }
    public override void OnSpawn()
    {
        if (ClothBasket.sphereColliders == null)
        {

            ClothSphereColliderPair[] collier = new ClothSphereColliderPair[1];
            collier[0].first = Ball.Ins.transform.Find("Ball/Box3D").GetComponent<SphereCollider>();
            collier[0].second = Ball.Ins.transform.Find("Ball/Box3D").GetComponent<SphereCollider>();
            ClothBasket.sphereColliders = collier;
        }
        if (checkInBall == null)
        {
            checkInBall = GetComponent<CheckInBall>();
        }
        
        AddBasket(this);
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

    IEnumerator Start_X2_Score(float time)
    {
        X2_Score = true;
        Power_X2_Score.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        Power_X2_Score.gameObject.SetActive(false);
        X2_Score = false;
    }

    IEnumerator Start_Power_Up_Basket(float time)
    {
        if (!X2_Basket)
        {
            transform.DOScaleX(2.5f, 0.5f);
            X2_Basket = true;
        }
        yield return new WaitForSeconds(time);
        transform.DOScaleX(1.5f, 0.5f);
        X2_Basket = false;
    }
    public int Left()
    {
        return isLeft ? -1 : 1;
    }
    public void Start_Move_Spawn(float x)
    {
        transform.DOMoveX(x, 0.5f);
    }

    public void SetUpMove(float x0,float x1)
    {
        RangeX = x0;
        RangeY = x1;
        transform.DOMoveY(x0, 1).OnComplete(() =>
        {
            transform.DOScaleX(x1, 1);


        }).SetLoops(-1, LoopType.Yoyo);

    }


    public void SetUpChangeSize()
    {
        transform.DOScaleX(2, 1).OnComplete(()=>
        {
            transform.DOScaleX(1.5f, 1);


        })  .SetLoops(-1,LoopType.Yoyo);
    }
   
    
   

}
