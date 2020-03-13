using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CtrlGamePlay : MonoBehaviour
{

    public GameObject Test;
    public Transform MainCanvas;
    public Text Debug_1;


    public static CtrlGamePlay Ins;


    public GameObject Fliper;


    public static float ForceThrow;
    
    public static Vector3 ForceFlipperThrow;
    public static bool isAddForce = false;



    public float AngleTo;
    public float speed;
    public bool isPress = false;
    public bool isPress2 = false;
    public bool isMax = false;
    public bool isStart = false;
    public float timePlushAngleTo;
    public float PLushPerSecond;
    public float MaxAngle;
    public float MinAngle;
    public float MaxForceThrow;
    public float speedFlipper;
    public float speedPlushThrow;


    private float time =0;
    private float Max=0;
    private float angle =0;
    private int count = 0;


    public delegate void EventStartGame();
    public event EventStartGame eventForStartGame;
    public delegate void EventForRerestGame();
    public event EventStartGame eventForRerestGame;

    private void Awake()
    {
        speedPlushThrow = (PLushPerSecond * MaxForceThrow) / Mathf.Abs(MinAngle);
        if (Ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Ins = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Debug_1.text = ForceThrow.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            isStart = true;
            Ball.Ins.body.isKinematic = false;
        }



            if (!isStart)
            return;
        

        ThrowBall();

        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
          
        }
     
       // Debug.Log(angle);
        if (Input.GetMouseButtonUp(0))
        {

            if (!isAddForce)
            {
                Ball.Ins.ThrowBall();
            }

            isAddForce = false;

            ForceThrow = 0;
            count = 0;
            isMax = false;
            isPress = false;
            isPress2 = true;
        }

        if (Input.GetMouseButtonDown(0))
        {

            isPress = true;

        }
        if (isPress)
        {
            
          
                if (!isMax)
                {

                    time = timePlushAngleTo;

                    angle -= PLushPerSecond;


                    angle = Mathf.Clamp(angle, MinAngle, 0);

                
                      
                    ForceThrow += speedPlushThrow;
                     
                     
                    if(angle == MinAngle ||angle<=MinAngle )
                    {
                        isMax = true;

                    if (!isAddForce)
                    {
                        Ball.Ins.ThrowBall();
                        isAddForce = true;
                    }


                }

                if (angle <= MinAngle * 0.9)
                    {

                        if (!isAddForce)
                        {
                            Ball.Ins.ThrowBall();
                            isAddForce = true;
                        }

                       



                }
                    else
                    {

                    }


                    Fliper.transform.eulerAngles = Vector3.forward * angle;
                


            }
            
        }
        else if (!isPress)
        {
         //   ForceThrow = 0;
            if (isPress2)
            {
               

                angle = Mathf.MoveTowards(angle, 0, Time.deltaTime * speedFlipper);

            //    angle = Mathf.Clamp(angle, MinAngle, 0);

                Fliper.transform.eulerAngles = new Vector3(0, 0, angle);

              
                if (angle == 0)
                {
                  //  ForceThrow = 0;
                   isPress2 = false;
                }
              

            }
           
        }

      
           
             
        }


    public void ThrowBall()
    {
      
        ForceThrow = Mathf.Clamp(ForceThrow,0, MaxForceThrow);
       ForceFlipperThrow = Vector3.Reflect(-Vector3.up,DirectFlipper.Direct) * ForceThrow;
    }

    
    public void Reset_Normal()
    {
        eventForRerestGame();
    }    

    }

   
    
    

    

