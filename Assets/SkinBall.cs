using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinBall : MonoBehaviour,IPointerDownHandler
{
    public TypeShop typeShop;
    public int id;
    public bool isBuy;
    public bool isUse;
    public Image ImgUse;
    public Image Skin;
    public int cost;
    public GameObject Eff;
    public Image ImgSelect;
   
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.one;
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
        Debug.Log("BallSelect : " + id);
        CtrlShop.Ins.ShowInfor(id);
    }
    public void StartEFF()
    {

        Ctrl_Spawn.Ins.SpawnUIEff(4, Skin.transform.position, transform);
       
    }
    public void Use(bool active)
    {
        isUse = active;
        ImgSelect.enabled = active;
    }
}
