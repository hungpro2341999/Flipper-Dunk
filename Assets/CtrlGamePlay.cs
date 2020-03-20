using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CtrlGamePlay : MonoBehaviour
{

   
    public float scaleScreen;

    public int level = 1;

    public GameObject Test;
    public Transform MainCanvas;
    public Text Debug_1;
    public int live;
    public bool CompleteLevel = false;
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
    public bool isResetLevel = false;
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
    public float offsetReflect = 1;
    public float timex2;
    public float timeChangeSize;
    public float timeReflectBall;

    public GameObject Key;

    //level Curr;
    public int TargetLevel = 0;
    
        //

    private float time =0;
    private float Max=0;
    public float angle =0;
    private int count = 0;
    private int farme = 0;
    

    public delegate void EventStartGame();
    public event EventStartGame eventForStartGame;
    public delegate void EventForRerestGame();
    public event EventStartGame eventForRerestGame;
    public delegate void EventForCompleteLevel();
    public event EventForCompleteLevel eventForCompleteLevel;
    public delegate void CompleteOneProcess();
    public event EventForCompleteLevel eventForCompleteProcess;

    public delegate void ClearnObj();
    public event ClearnObj eventClearObj;

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
        float scale0 = Screen.width * Screen.height;
        
     //   scaleScreen = scaleScreen / Screen.dpi;

        float scale00 = 1280 * 720;

        float scale1 = Screen.width * Screen.height;
        scaleScreen = 1-(scale00 / scale1);   
      // transform.localScale = new Vector3(scaleScreen,scaleScreen,1);
    }

    

    // Start is called before the first frame update
    void Start()
    {
        eventClearObj += DestroyAll;
        StartGame();
      
        
    }

    public void StartGame()
    {
        Ctrl_Player.DiamondInPlayer = 0;
        GameMananger.Ins.isGameOver = false;
        GameMananger.Ins.isGamePause = false;
        GameMananger.Ins.CloseAll();
        eventClearObj();
        live = 3;
        Ctrl_Spawn.Ins.SetUpSpawnBasket();
        eventForStartGame();
        CompleteLevel = false;
        eventForRerestGame();
    }



    // Update is called once per frame
    void Update()
    {
        if (GameMananger.Ins.isGameOver || GameMananger.Ins.isGamePause)
            return;
        if (ClickUI.isButtonDown)

            return;

        if (CompleteLevel)
           
            return;

        if (isResetLevel)

            return;
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
        Fliper.transform.eulerAngles = Vector2.zero;
      
        angle = 0;
        Angle = 0;
        ForceThrow = 0;
        isAddForce = false;
        isMax = false;
        isPress = false;
        isPress2 = true;



    }

    //  Power Up



    public IEnumerator ShadowScreen()
    {
        Color color = Shadow.color;

        while(color.a < 1)
        {
            isResetLevel = true;
            color = Shadow.color;
         //   Debug.Log(color.a);
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

        isResetLevel = false;


    }
   

    public void CompleteProcessLevel()
    {
        Ctrl_Spawn.Ins.CompleteProcess(TargetLevel);
        TargetLevel--;
        if (!isCompleteLevel())
        {
            if (basket.Count <= 0)
            {
                Ctrl_Spawn.Ins.SetUpSpawnBasket();
            }
           
        }
        else
        {
            CompleteLevel = true;
            GameMananger.Ins.isGameOver = true;
            Ctrl_Player.Ins.CompleteNextLevel();
            GameMananger.Ins.OpenWindow(TypeWindow.NextLevel);
        
        }
       
    }

    //level
    public bool isCompleteLevel()
    {
        
        if (TargetLevel > 0)
        {
            return false;
        }

        return true;
    }

    public IEnumerator NextLevel()
    {
        // Eff CompleteLevel


        yield return new WaitForSeconds(0);

        StartCoroutine(CtrlGamePlay.Ins.ShadowScreen());

        yield return new WaitForSeconds(0.5f);

        Ctrl_Spawn.Ins.SetUpSpawnBasket();

    }

    

    public bool isOverGame()
    {
        if (live > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void DestroyAll()
    {

        foreach (Basket b in basket)
        {
            b.GetComponent<DestroySelf>().Destroy();
        }

        basket.Clear();
    }

    public void ChangeSizeBasket()
    {
        for(int i = 0; i < basket.Count; i++)
        {
            StartCoroutine(basket[i].Start_Power_Up_Basket(timeChangeSize));
        }
    }

    public void X2_Score()
    {
        for(int i = 0; i < basket.Count; i++)
        {
            StartCoroutine(basket[i].Start_X2_Score(timex2));
        }
    
    }
    public void StartIncreReflect()
    {
        StartCoroutine(StartMoveSupperReflect(timeReflectBall));
    }
    public IEnumerator StartMoveSupperReflect(float time)
    {
        offsetReflect *= 3;
        yield return new WaitForSeconds(time);
        offsetReflect = 1;

    }
    
    


    





}







