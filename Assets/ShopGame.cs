using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        CtrlShop.Ins.LoadingShop();
        CtrlShop.Ins.isOpenShop = true;
    }
    private void OnDisable()
    {
        CtrlShop.Ins.isOpenShop = false;
    }
}
