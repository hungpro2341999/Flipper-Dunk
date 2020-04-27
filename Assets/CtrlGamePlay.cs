using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum TypeGamePlay { Level, Chanelegend, Infinity };

public class CtrlGamePlay : MonoBehaviour
{
    public Transform CubeBlock;
    public SpriteRenderer BG;
    public TypeGamePlay typeGame = TypeGamePlay.Infinity;

    public List<Transform> ModePlay;

    public bool isReflect = false;

    public static float scaleScreen;

    public int level = 1;

    public GameObject Test;
    public Transform MainCanvas;


    public Text Debug_1;
    public int live;
    public bool CompleteLevel = false;
    public static CtrlGamePlay Ins;

    public Transform PosInit;



    public GameObject Fliper;

    public List<Basket> basket;

    public SpriteRenderer Img_Flipper;

    public static float ForceThrow;

    public static Vector3 ForceFlipperThrow;
    public bool isAddForce = false;
    public static float Angle = 0;
    public static int CountTotalPlayer = 0;
    public static int CountPlayer = 0;
    public static int CountGlobal = 0;
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
    public float SpeedRotation;
    public float SpeedToque;

    public float AnglePlush;
    public float SpeedThrowBall;

    public float SpeedShadow;
    public float MaxAngleFlipper = 0;
    public float angleFlipper = 0;
    public float offsetReflect = 1;
    public float timex2;
    public float timeChangeSize;
    public float timeReflectBall;
    public int idexChanlegend = 0;

    public GameObject Key;

    //level Curr;
    public int TargetLevel = 0;

    //

    private float time = 0;
    private float Max = 0;
    public float angle = 0;
    private int count = 0;
    private int farme = 0;

    public bool isX2Score = false;

    public delegate void EventStartGame();
    public event EventStartGame eventForStartGame;
    public delegate void EventForRerestGame();
    public event EventStartGame eventForRerestGame;
    public delegate void EventForCompleteLevel();
    public event EventForCompleteLevel eventForCompleteLevel;
    public delegate void CompleteOneProcess();
    public event EventForCompleteLevel eventForCompleteProcess;
    public delegate void Event_Load_Game(int Score, int level);
    public event Event_Load_Game eventForLoadGame;

    public delegate void ClearnObj();
    public event ClearnObj eventClearObj;

    public Image Shadow;
    public Transform ClickToStart;

    public int key_in_Game = 0;
    public bool firstPull;

    // Mode 2:

    public Image Bar;
    public float t;
    public float limitTime;
    public float timeBar;
    public Transform TransProcess;
    public bool isCompleteGame = false;
    public Text LabelDailyQuest;
    public Animator LabelQuest;
    public bool open = false;

    // Mode 3:

    public Text Score;
    public Text HighScore;
    public int ScorePlayer;

    private void Awake()
    {
        // speedPlushThrow = (PLushPerSecond * MaxForceThrow) / Mathf.Abs(MinAngle);
        //   angleFlipper = (PLushPerSecond * MaxAngleFlipper) / Mathf.Abs(MinAngle);
        if (Ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Ins = this;
        }
        eventForRerestGame += Reset;

        float scale0 = 720 * 1280;





        float scale1 = Screen.width * Screen.height;
        scaleScreen = 1 - (scale0 / scale1);
        if (scaleScreen > 0.5f)
        {
            scaleScreen = 1f;
            //   transform.localScale = new Vector3(scaleScreen, scaleScreen, 1);
            Camera.main.orthographicSize = 7.4f;
        }
        else
        {
            scaleScreen = 1;
        }
        eventForStartGame += ResetKey;
        eventForRerestGame += ResetKey;
    }



    // Start is called before the first frame update
    void Start()
    {

        eventClearObj += DestroyAll;
        CloseAll();


    }

    public void ResetKey()
    {

        key_in_Game = 0;
        Img_Flipper.sprite = Ctrl_Player.Ins.GetSkinFlipper();
        BG.sprite = Ctrl_Player.Ins.GetSkinBG();
    }



    public void ResetScore()
    {
        ScorePlayer = 0;
        Score.text = 0.ToString();
        HighScore.text = "Best Score " + Ctrl_Player.Ins.GetHighScore().ToString();
    }

    public void StartGame(TypeGamePlay type)
    {
        isAddForce = false;
        isStart = false;
        CountPlayer = 1;
        isX2Score = false;
        Ball.Ins.ActiveBall(true);
        isX2Score = false;
        offsetReflect = 1;
        this.typeGame = type;
        isCompleteGame = false;
        CompleteLevel = false;
        switch (type)
        {
            case TypeGamePlay.Level:

                Ctrl_Player.DiamondInPlayer = 0;
                GameMananger.Ins.isGameOver = false;
                GameMananger.Ins.isGamePause = false;

                eventClearObj();
                live = 3;

                eventForStartGame();
                CompleteLevel = false;
                eventForRerestGame();
                Open(0);

                break;
            case TypeGamePlay.Chanelegend:

                GameMananger.Ins.isGameOver = false;
                GameMananger.Ins.isGamePause = true;

                eventClearObj();

                eventForStartGame();
                live = 1;
                Ctrl_Player.DiamondInPlayer = 0;
                Open(1);


                eventForRerestGame();
                break;
            case TypeGamePlay.Infinity:
                eventClearObj();
                ResetScore();
                eventForStartGame();

                Ctrl_Player.DiamondInPlayer = 0;
                GameMananger.Ins.isGameOver = false;
                GameMananger.Ins.isGamePause = false;

                eventForRerestGame();
                Open(2);

                break;
        }


        OpenMode(type);



        //


    }



    // Update is called once per frame

    
    private void FixedUpdate()
    {
        ThrowBall();
        if (GameMananger.Ins.isGameOver || GameMananger.Ins.isGamePause)
            return;
        if (ClickUI.isButtonDown)

            return;

        if (CompleteLevel)

            return;

        if (isResetLevel)

            return;
        // Debug_1.text = ForceThrow.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            ClickToStart.gameObject.SetActive(false);
            isStart = true;


        }




        if (!isStart)
        {
            return;
        }








       

        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }


        // Debug.Log(angle);
        if (Input.GetMouseButtonUp(0))
        {
            Fliper.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            Fliper.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            if (!isAddForce)
            {
                Ball.Ins.ThrowBall();
            }

            isAddForce = false;

            ForceThrow = 1;
            count = 0;
            isMax = false;
            isPress = false;
            isPress2 = true;


            SpeedThrowBall = 1;
            angle = -DirectFlipper.Angle;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //    isAddForce = false;
            Fliper.gameObject.GetComponent<Rigidbody2D>().simulated = true;
            isPress = true;
            


        }
        if (isPress)
        {





            if (!isMax)
            {


                //Angle += angleFlipper;
                //Angle = Mathf.Clamp(Angle, 0, MaxAngleFlipper);

                //ForceThrow += speedPlushThrow;

                ////  Fliper.transform.eulerAngles = Vector3.forward * angle;
                //if (ForceThrow >= MaxForceThrow)
                //{
                //    if (!isAddForce)
                //    {
                //        Ball.Ins.ThrowBall();
                //        isAddForce = true;
                //    }
                //}

                if (DirectFlipper.Angle <= MaxAngle*0.9f)
                {
                    Fliper.gameObject.GetComponent<Rigidbody2D>().AddTorque(SpeedRotation, ForceMode2D.Force);
                    SpeedThrowBall += 0.025f;
                    
                    //if(DirectFlipper.Angle >= MaxAngle*0.75f)
                    //  {
                    //      isReflect = true;

                    //  }
                    //  else
                    //  {


                    //      isReflect = false;
                    //  }


                }
                else
                {



                    if (!isAddForce)
                    {
                        Fliper.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                        Fliper.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
                        isMax = true;
                        SpeedThrowBall = 1.55f;
                        Ball.Ins.ThrowBall();
                        isAddForce = true;
                    }

                }



            }

        }
        else if (!isPress)
        {
            
            SpeedThrowBall = 1;

            if (isPress2)
            {


                angle = Mathf.MoveTowards(angle, 0, Time.deltaTime*SpeedToque);
                if (angle== 0)
                {
                    Fliper.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                    isPress2 = false;
                }
                else
                {
                    Fliper.gameObject.transform.localEulerAngles = new Vector3(0, 0, angle);
                }
                //if (DirectFlipper.Angle > 0)
                //{
                //    Fliper.gameObject.GetComponent<Rigidbody2D>().AddTorque(-SpeedRotation, ForceMode2D.Force);
                //    //  Debug.Log("Add");

                //}
                //else
                //{

                //    isPress2 = false;
                //    Fliper.gameObject.transform.localEulerAngles = Vector3.zero;
                //    Fliper.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                //    Fliper.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
                //}
            }



        }

        if (typeGame == TypeGamePlay.Chanelegend)
        {
            if (!isCompleteGame)
            {
                t += Time.deltaTime;
                if (t >= limitTime)
                {
                    GameMananger.Ins.isGameOver = true;
                    CtrlAudio.Ins.Play("TimeOut");
                    GameMananger.Ins.Open(TypeWindow.NotCompleteDailyQuest);
                    isCompleteGame = true;
                    Debug.Log("load");
                }
                else
                {
                    //    Debug.Log("load");
                    Bar.fillAmount += timeBar;

                }
            }


        }


    }


    public void ThrowBall()
    {

        ForceFlipperThrow =  DirectFlipper.Direct * Mathf.Clamp(Mathf.Abs(Fliper.transform.GetComponent<Rigidbody2D>().angularVelocity) * 0.8f,100,Mathf.Infinity);
       

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
        firstPull = true;
        CubeBlock.localPosition = new Vector3(-1.046f, 0.09f, 0);
        Fliper.gameObject.transform.localEulerAngles = Vector3.zero;
        Fliper.gameObject.GetComponent<Rigidbody2D>().simulated = false;
        Fliper.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;

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

        while (color.a < 1)
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
        switch (typeGame)
        {


            case TypeGamePlay.Level:

             
                if (!isCompleteLevel())
                {
                    if (basket.Count <= 0)
                    {
                        Ctrl_Spawn.Ins.SetUpSpawnBasket();
                    }

                    // CtrlAudio.Ins.Play("Cheer");

                }
                else
                {
                   
                    Debug.Log("Compte Key");
                    CompleteLevel = true;
                    GameMananger.Ins.isGameOver = true;
                    Ctrl_Player.Ins.CompleteNextLevel();
                    if (Ctrl_Player.Ins.isInGameisFullKey())
                    {
                        
                        GameMananger.Ins.Open(TypeWindow.Reward);
                        Ball.Ins.ActiveBall(false);
                        CtrlReward.Ins.StartOpenStore();
                    }
                    else
                    {
                        Ctrl_Player.Ins.AddKey(key_in_Game);
                        var a = Ctrl_Spawn.Ins.SpawnUIEff(3, Vector2.zero, MainCanvas);
                        a.localPosition = Vector3.zero;
                        Ball.Ins.ActiveBall(false);

                        GameMananger.Ins.Open(TypeWindow.NextLevel);
                    }
                    CtrlAudio.Ins.Play("LevelComplete");
                    Ball.Ins.ActiveBall(false);
                    eventForLoadGame(Ctrl_Player.Ins.GetHighScore(), Ctrl_Player.Ins.GetCurrLevel());

                    CountTotalPlayer++;
                    List<int> level = new List<int> { 3, 7, 12, 16, 20, 26, 36, 50, 60, 70 };
                    if (level.Contains(Ctrl_Player.Ins.GetCurrLevel()))
                    {
                        GameMananger.Ins.Open(TypeWindow.Unlock);
                        Debug.Log("Unclock");
                    }

                }

                break;
            case TypeGamePlay.Chanelegend:

                if (!isCompleteLevel())
                {
                    if (basket.Count <= 0)
                    {
                        Ctrl_Spawn.Ins.SetUpSpawnBasket();
                    }

                    CtrlAudio.Ins.Play("Cheer");

                }
                else
                {
                    
                    Ball.Ins.ActiveBall(false);
                    CompleteLevel = true;
                    GameMananger.Ins.isGameOver = true;
                    GameMananger.Ins.Open(TypeWindow.CompleteDailyQuest);
                    CtrlAudio.Ins.Play("Cheer");
                    CountTotalPlayer++;
                    if (CountTotalPlayer == 5)
                    {
                        GameMananger.Ins.Open(TypeWindow.Unlock);
                        Debug.Log("Unclock");
                    }
                }

                break;
            case TypeGamePlay.Infinity:
                if (basket.Count <= 0)
                {
                    Ctrl_Spawn.Ins.SetUpSpawnBasket();
                }

                break;
        }


    }



    public void CompleteProcess()
    {
        if (CtrlGamePlay.Ins.isX2Score)
        {

            Ctrl_Spawn.Ins.CompleteProcess(TargetLevel);
            TargetLevel--;
            Ctrl_Spawn.Ins.CompleteProcess(TargetLevel);
            TargetLevel--;
            CtrlGamePlay.Ins.isX2Score = false;

        }
        else
        {
            Ctrl_Spawn.Ins.CompleteProcess(TargetLevel);
            TargetLevel--;
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
        if (live >= 0)
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
        for (int i = 0; i < basket.Count; i++)
        {
            StartCoroutine(basket[i].Start_Power_Up_Basket(timeChangeSize));
        }
    }

    public void X2_Score()
    {
        for (int i = 0; i < basket.Count; i++)
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
        offsetReflect = 3;
        yield return new WaitForSeconds(time);
        offsetReflect = 1;

    }



    ////// Mode 2///////

    public void LoadDailyQueset()
    {
        GameMananger.Ins.isGamePause = true;
        Bar.fillAmount = 0;
        t = 0;
        isCompleteGame = false;
        open = !open;
        GameMananger.Ins.StartLabel();
        int i = Random.Range(0, 4);

        switch (i)
        {

            case 0:
                idexChanlegend = 0;
                Ctrl_Spawn.Ins.SetUpPerBasket(50, 15, 15, 10, 5, 5, 5);
                limitTime = 40;
                GameMananger.Ins.SetLable("Score 5 baskets in 40s");
                timeBar = Time.deltaTime / limitTime*(1+Time.deltaTime);

                break;
            case 1:
                idexChanlegend = 1;
                Ctrl_Spawn.Ins.SetUpPerBasket(50, 15, 15, 10, 5, 5, 3);
                GameMananger.Ins.SetLable("Score 3 baskets from the bottom in 40s");

                limitTime = 40;
                timeBar = Time.deltaTime / limitTime* (1 + Time.deltaTime);
                break;
            case 2:
                idexChanlegend = 2;
                Ctrl_Spawn.Ins.SetUpPerBasket(50, 15, 15, 10, 5, 5, 5);
                GameMananger.Ins.SetLable("Score 5 baskets 1 time Wall bounce in 35s");

                limitTime = 35;
                timeBar = Time.deltaTime / limitTime* (1 + Time.deltaTime);
                break;
            case 3:
                idexChanlegend = 3;
                Ctrl_Spawn.Ins.SetUpPerBasket(50, 15, 15, 10, 5, 5, 5);
                GameMananger.Ins.SetLable("Score 5 baskets double-bounce basket hoop in 35s");

                limitTime = 35;
                timeBar = Time.deltaTime / limitTime * (1 + Time.deltaTime);
                break;

        }
      
    }
    public void LoadInfilyMode()
    {

    }

    public void StartLoadingTime()
    {

    }




    // CtrlMode

    public void OpenMode(TypeGamePlay type)
    {
        switch (type)
        {
            case TypeGamePlay.Level:
                Open(0);
                break;
            case TypeGamePlay.Chanelegend:
                Open(1);
                break;
            case TypeGamePlay.Infinity:
                Open(2);
                break;
        }
    }

    public void Open(int mode)
    {

        for (int i = 0; i < ModePlay.Count; i++)
        {
            if (i == mode || i == 3)
            {
                ModePlay[i].gameObject.SetActive(true);
            }
            else
            {
                ModePlay[i].gameObject.SetActive(false);
            }
        }

    }
    public void CloseAll()
    {
        for (int i = 0; i < ModePlay.Count; i++)
        {

            ModePlay[i].gameObject.SetActive(false);

        }
    }
    public void ResetMode()
    {

        GameMananger.Ins.isGameOver = false;
        switch (typeGame)
        {
            case TypeGamePlay.Level:
                StartGame(TypeGamePlay.Level);
                GameMananger.Ins.Close(TypeWindow.GameOver);
                break;
            case TypeGamePlay.Chanelegend:
                ManagerAds.Ins.ShowInterstitial();
                isCompleteGame = false;
                GameMananger.Ins.Close(TypeWindow.NotCompleteDailyQuest);
                GameMananger.Ins.Close(TypeWindow.CompleteDailyQuest);
                StartGame(TypeGamePlay.Chanelegend);
                break;
            case TypeGamePlay.Infinity:
                ResetScore();
                GameMananger.Ins.Close(TypeWindow.Over_Game_3);
                StartGame(TypeGamePlay.Infinity);


                break;
        }
        GameMananger.Ins.UnSetting();

    }

    public void StartNextLevel()
    {
        StartGame(TypeGamePlay.Level);
        GameMananger.Ins.Close(TypeWindow.NextLevel);
        GameMananger.Ins.UnSetting();

    }


    public void AddScore(int score)
    {
        this.ScorePlayer += score;

        Score.text = ScorePlayer.ToString();

    }
    public void OverGame()
    {
        CountGlobal++;
        Fliper.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
        GameMananger.Ins.isGameOver = true;
        Ball.Ins.ActiveBall(false);
        switch (typeGame)
        {

            case TypeGamePlay.Level:
             //   Ctrl_Player.Ins.RestoreKey(key_in_Game);
                CtrlAudio.Ins.Play("OverGame");
                GameMananger.Ins.Open(TypeWindow.GameOver);
                break;
            case TypeGamePlay.Chanelegend:
                CtrlAudio.Ins.Play("OverGame");
                GameMananger.Ins.Open(TypeWindow.NotCompleteDailyQuest);

                break;
            case TypeGamePlay.Infinity:
                CtrlAudio.Ins.Play("OverGame");
                GameMananger.Ins.Open(TypeWindow.Over_Game_3);
                break;
        }
        if (CountGlobal % 3 == 0)
        {
            ManagerAds.Ins.ShowInterstitial();
        }
        CountGlobal++;
        GameMananger.Ins.ShowSetting();
    }

    public void Continue()
    {

        ManagerAds.Ins.ShowRewardedVideo((active) => {

            if (active)
            {
                CountPlayer++;
                switch (typeGame)
                {

                    case TypeGamePlay.Chanelegend:
                        GameMananger.Ins.isGameOver = false;
                        GameMananger.Ins.Close(TypeWindow.GameOver);
                        GameMananger.Ins.Close(TypeWindow.NotCompleteDailyQuest);
                        live += 2;
                        break;
                    case TypeGamePlay.Infinity:
                        GameMananger.Ins.Close(TypeWindow.Over_Game_3);
                        GameMananger.Ins.isGameOver = false;
                        live += 2;
                        break;
                    case TypeGamePlay.Level:
                        GameMananger.Ins.Close(TypeWindow.GameOver);
                        live += 2;
                        GameMananger.Ins.isGameOver = false;
                        break;
                }
                Ball.Ins.ActiveBall(true);
                StartCoroutine(CtrlGamePlay.Ins.ShadowScreen());
            }
        });
        GameMananger.Ins.UnSetting();

    }

    public void OverMode_3()
    {
        eventForLoadGame(Ctrl_Player.Ins.GetHighScore(), Ctrl_Player.Ins.GetCurrLevel());
    }
    public void VisibleBlock()
    {
       // CubeBlock.gameObject.SetActive(false);
       // Invoke("restoreBlock", 0.2f);
    }
    private void restoreBlock()
    {
        CubeBlock.gameObject.SetActive(true);
    }
}







