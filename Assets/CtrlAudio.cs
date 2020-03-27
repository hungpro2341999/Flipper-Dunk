using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlAudio : MonoBehaviour
{
    public AudioSource[] Audio;
    public static CtrlAudio Ins;
    // Start is called before the first frame update
    void Start()
    {
        if (Ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Ins = this;
        }
        Audio = transform.GetComponentsInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string name)
    {

        if (Ctrl_Player.Ins.isSound())
        {
            for (int i = 0; i < Audio.Length; i++)
            {
                if (Audio[i].name == name)
                {
                    Audio[i].Play();
                    return;
                }
            }
        }

       
    }
}
