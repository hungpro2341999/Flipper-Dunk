using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Process : MonoBehaviour
{
    public Transform completeProcess;
    public int idProcess;
   
    public void Complete()
    {
        completeProcess.gameObject.SetActive(true);
    }
}
