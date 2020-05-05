using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject BG_Light;
    public Text text;
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Instantiate(BG_Light, Vector3.zero, Quaternion.identity, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetText(string s)
    {
        text.text = s;
    }
    public void Active2()
    {
        gameObject.SetActive(false);
        Invoke("Active", 0.12f);
    }
    public void Active()
    {
        gameObject.SetActive(true);
    }
}
