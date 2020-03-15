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

    public List<Basket> basket;



    public static float ForceThrow;
    
    public static Vector3 ForceFlipperThrow;
    public static bool isAddForce = false;
    public static float Angle = 0;
    

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
    public float SpeedShadow;
    public float MaxAngleFlipper = 0;
    public float angleFlipper = 0;

    private float time =0;
    private float Max=0;
    public float angle =0;
    private int count = 0;
    private int farme = 0;
   

    public delegate void EventStartGame();
    public event EventStartGame eventForStartGame;
    public delegate void EventForRerestGame();
    public event EventStartGame eventForRerestGame;

    public Image Shadow;
    public Transform ClickToStart;
    private void Awake()
    {
        speedPlushThrow = (PLushPerSecond * MaxForceThrow) / Mathf.Abs(MinAngle);
        angleFlipper = (PLushPerSecond * MaxAngleFlipper) / Mathf.Abs(MinAngle);
        if (Ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Ins = this;
        }
        eventForRerestGame += Reset;
      
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
                ClickToStart.gameObject.SetActive(false);
                isStart = true;
                Ball.Ins.ActiveBall();

            }
          
          
      

        if (!isStart)
        {
            return;
        }








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

            farme++;

                if (!isMax)
                {

                    time = timePlushAngleTo;

                    angle -= PLushPerSecond;


                    angle = Mathf.Clamp(angle, MinAngle, 0);

                    Fliper.transform.eulerAngles = Vector3.forward * angle;

                Angle += angleFlipper;
                Angle = Mathf.Clamp(Angle, 0, MaxAngleFlipper);
             
                    ForceThrow += speedPlushThrow;
                    if (ForceThrow >= MaxForceThrow)
                    {
                        if (!isAddForce)
                        {
                            Ball.Ins.ThrowBall();
                            isAddForce = true;
                        }
                    }
                
                   
                     
                    if(angle == MinAngle ||angle<=MinAngle )
                    {
                        isMax = true;

                    if (!isAddForce)
                    {
                        Ball.Ins.ThrowBall();
                        isAddForce = true;
                    }


                }

                //if (angle <= MinAngle * 0.9)
                //    {

                //        if (!isAddForce)
                //        {
                //            Ball.Ins.ThrowBall();
                //            isAddForce = true;
                //        }

                       



                //}
                    else
                    {

                    }


               
                


            }
            
        }
        else if (!isPress)
        {
         //   ForceThrow = 0;
            if (isPress2)
            {

                Angle -= angleFlipper;
                Angle = Mathf.Clamp(Angle, 0, MaxAngleFlipper);
                angle = Mathf.MoveTowards(angle, 0, Time.deltaTime * speedFlipper);

            //    angle = Mathf.Clamp(angle, MinAngle, 0);

                Fliper.transform.eulerAngles = new Vector3(0, 0, angle);

              
                if (angle == 0)
                {
                  //  ForceThrow = 0;
                   isPress2 = false;
                    Angle = 0;
                    ForceThrow = 0;
                }
              

            }
           
        }

      
           
             
        }


    public void ThrowBall()
    {
       
        ForceThrow = Mathf.Clamp(ForceThrow,0, MaxForceThrow);
        if (ForceThrow != 0)
        {
            ForceFlipperThrow = Vector3.Reflect(Vector3.up, DirectFlipper.Direct) * ForceThrow;

          
        }
      //  Debug.Log(ForceThrow);
      
      //  ForceFlipperThrow = new Vector3(-DirectFlipper.Direct.y,DirectFlipper.Direct.x) * ForceThrow;

    //    Debug.Log(new Vector3(-DirectFlipper.Direct.y, DirectFlipper.Direct.x) + "  " + ForceThrow + "  " + ForceFlipperThrow);
    }

    
    public void Reset_Normal()
    {
        eventForRerestGame();
    }
    public void Reset()
    {
        ClickToStart.gameObject.SetActive(true);
        isStart = false;
    }

    //  Power Up

    #region EFF_Basket

    public void x2_Score(Basket basket)
    {
       
    }
    public void Power_Up_Hoot(Basket basket)
    {

    }

    public void Power_Up_Ball()
    {

    }

    public IEnumerator ShadowScreen()
    {
        Color color = Shadow.color;

        while(color.a < 1)
        {
            color = Shadow.color;
            Debug.Log(color.a);
            color.a = Mathf.MoveTowards(color.a, 1, Time.deltaTime * SpeedShadow);
            Shadow.color = color;
       
            yield return new WaitForSeconds(0);
        }
        yield return new WaitForSeconds(0.3f);
        CtrlGamePlay.Ins.Reset_Normal();

        while (color.a > 0)
        {
            color = Shadow.color;
            color.a = Mathf.MoveTowards(color.a, 0, Time.deltaTime * SpeedShadow);
            Shadow.color = color;
            yield return new WaitForSeconds(0);
        }




    }
    #endregion

}







