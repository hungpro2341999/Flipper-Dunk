using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlGamePlay : MonoBehaviour
{

    public GameObject Fliper;



    public float AngleTo;
    public float speed;
    public bool isPress = false;
    public float timePlushAngleTo;
    public float PLushPerSecond;
    public float MaxAngle;
    public float MinAngle;
    private float time =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

            isPress = false;

        }

        if (Input.GetMouseButtonDown(0))
        {

            isPress = true;

        }
        if (isPress)
        {
            if (time <= 0)
            {
                time = timePlushAngleTo;
                Vector3 Angle = Fliper.transform.eulerAngles;
                 Angle.z -= PLushPerSecond;
           //     Angle.z = Mathf.Clamp(Angle.z, MinAngle, MaxAngle);
                Fliper.transform.eulerAngles = Angle;
                
            }
            else
            {
                time -= Time.deltaTime;
            }
        }
        else
        {
            Vector3 Angle = Fliper.transform.eulerAngles;
            Angle.z -= PLushPerSecond;
            
           
        }
    }

   
    
    

    
}
