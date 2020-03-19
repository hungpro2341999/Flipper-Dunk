using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject BG_Light;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
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
}
