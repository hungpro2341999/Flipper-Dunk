using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Basket : PoolItem
{
    public bool isLeft = false;

    public int Score;
    public bool X2_Score;
    public bool X2_Basket;
    public Transform Power_X2_Score;

    public CheckInBall checkInBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Start_Power_Up_Basket(1));
        }

    }
    public void Die()
    {
       // Fuck();
        float x = transform.position.x;   
        transform.DOMoveX(x-0.3f, 0.3f).OnComplete(() =>
        {
            transform.DOMoveX(x + 6, 0.6f).OnComplete(() =>
              {

                  OnDespawn();
              });

        });
    }
    public override void OnSpawn()
    {

        AddBasket(this);
        gameObject.SetActive(true);
        checkInBall.Restore();
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

}
