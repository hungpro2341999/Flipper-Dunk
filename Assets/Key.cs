using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform Active;
    public bool  isActive = false;
    // Start is called before the first frame update
   public void Active_key()
    {
        Active.gameObject.SetActive(true);
    }

}
