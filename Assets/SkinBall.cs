using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinBall : MonoBehaviour,IPointerDownHandler
{
    public int id;
    public bool isBuy;
    public bool isUse;
    public Image ImgUse;
    public Image Skin;
    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load(int id,bool isBuy,bool isUse,int cost,Sprite Skin)
    {
        this.Skin.sprite = Skin;
        this.cost = cost;
        this.id = id;
        this.isBuy = isBuy;
        this.isUse = isUse;
        CheckInfor();

    }

    public void Select()
    {
        ImgUse.enabled = true;
    }
    public void UnSelect()
    {
        ImgUse.enabled = false;

    }
    public void CheckInfor()
    {
        if (isUse)
        {
            Select();
        }
        else
        {
            UnSelect();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
