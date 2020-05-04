using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    public SphereCollider Box3D;
    public static Ball Ins;
    public bool isCollWithFlipper = false;
    public Rigidbody2D body;
    public Vector3 PosInit;
    public float Angle = 0;
    public SpriteRenderer SkinBall;
    public LayerMask layer;
    public bool ForceInit = false;


    public float MaxForce;
    bool collwith_1 = false;
    bool collwith_2 = false;
    public float MaxPush;
    public bool max = false;
    //    bool collwith_3 = false;
    public float xMax = 0;
    public float xForce = 1;

    public TrailRenderer Trailer;

    public static bool isReset = false;

    public bool isWall = false;

    public bool  isMax = false;
    private void Awake()
    {

        if (Ins != null)
        {
            Destroy(gameObject);

        }
        else
        {
            Ins = this;

        }
        PosInit = transform.position;


    }
    // Start is called before the first frame update
    void Start()
    {

        //   body.gravityScale = body.gravityScale * CtrlGamePlay.scaleScreen;
        //  Physics2D.gravity = Physics2D.gravity * CtrlGamePlay.scaleScreen;
        //  body.angularDrag = CtrlGamePlay.scaleScreen * body.angularDrag;
        CtrlGamePlay.Ins.eventForRerestGame += Reset;
        body = GetComponent<Rigidbody2D>();
        body.mass = body.mass * CtrlGamePlay.scaleScreen;


        Reset();

    }

    // Update is called once per frame
    void Update()
    {
        var a = Physics2D.CircleCastAll(transform.position, 0.4f, Vector2.zero, 0.1f, layer);
        if (a.Length > 0)
        {
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i].collider.gameObject.tag == "Max")
                {
                    isMax = true;
                }
                  
                
            }
          //  Debug.Log(a.Length);
            isCollWithFlipper = true;

        }
        else
        {
            isMax = false;
            isCollWithFlipper = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        CtrlAudio.Ins.Play("Coll");
       
        if( collision.gameObject.layer == 23)
            isWall = true;
        if (collision.gameObject.layer == 9)
            isWall = false;

        if (collision.gameObject.layer == 9)
        {
            if (collision.gameObject.tag == "1")
            {
           //     MaxForce = 1.6f;
            }
            if (collision.gameObject.tag == "Max")
            {
             //   MaxForce = 2.5f;
            }


        }

        


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       
        if (collision.gameObject.layer == 9)
        {
            if (collision.gameObject.tag == "1")
            {
              //  MaxForce = 1;
            }
            if (collision.gameObject.tag == "Max")
            {
              //  MaxForce = 1f;
            }

        }
       
    }

    public void ThrowBall()
    {

        if (isCollWithFlipper)
        {
            
            if (CtrlGamePlay.Ins.firstPull)
            {
                CtrlGamePlay.Ins.firstPull = false;
                CtrlGamePlay.Ins.CubeBlock.gameObject.SetActive(false);
            }
            CtrlGamePlay.Ins.VisibleBlock();
              //   Instantiate(CtrlGamePlay.Ins.Test, CtrlGamePlay.Ins.MainCanvas);
              Vector3 vec = Vector3.zero;

            //if (max)
            //{
            //    i = 0;
            //    vec = 2.5f * (new Vector2(CtrlGamePlay.ForceFlipperThrow.x, Mathf.Abs(CtrlGamePlay.ForceFlipperThrow.y))) * CtrlGamePlay.Ins.SpeedThrowBall * 1.5f * MaxForce;
            //    body.AddForce(vec * CtrlGamePlay.Ins.offsetReflect, ForceMode2D.Force);
            //}
            //else
            //{
            //    i = 1;
            //    vec = (new Vector2(CtrlGamePlay.ForceFlipperThrow.x, Mathf.Abs(CtrlGamePlay.ForceFlipperThrow.y))) * CtrlGamePlay.Ins.SpeedThrowBall * MaxForce;
            //    body.AddForce(vec * CtrlGamePlay.Ins.offsetReflect, ForceMode2D.Force);
            //}

            //if (body.velocity.magnitude >= MaxPush)
            //{
            //    i = 2;
            //    body.velocity = Vector2.zero;
            //    vec = (new Vector2(CtrlGamePlay.ForceFlipperThrow.x, Mathf.Abs(CtrlGamePlay.ForceFlipperThrow.y))).normalized * MaxPush;
            //    body.velocity = (vec * CtrlGamePlay.Ins.offsetReflect);
            //}
            if (isMax)
            {
                MaxForce = 2.22f;
                vec = (new Vector2(CtrlGamePlay.ForceFlipperThrow.x, Mathf.Abs(CtrlGamePlay.ForceFlipperThrow.y))) * (1 + CtrlGamePlay.Ins.SpeedThrowBall) * MaxForce * 0.6f;
            }
            else
            {
                MaxForce = 1.6f;
                vec = (new Vector2(CtrlGamePlay.ForceFlipperThrow.x, Mathf.Abs(CtrlGamePlay.ForceFlipperThrow.y))) * (1 + CtrlGamePlay.Ins.SpeedThrowBall) * MaxForce * 0.6f;
            }

          //  Debug.Log("VEC : "+vec.magnitude);
            if (vec.magnitude < 230)
            {
                vec = 230 * vec.normalized;
            }
            else if((vec.magnitude > 650))
            {
                vec = 650 * vec.normalized;
            }


            body.AddForce(vec * CtrlGamePlay.Ins.offsetReflect, ForceMode2D.Force);


          //  Debug.Log("Fire : " + " " + vec.x + "  " + vec.y + ":" + (int)(vec.magnitude));   


            CtrlGamePlay.Ins.SpeedThrowBall = 0;
            CtrlGamePlay.Ins.isAddForce = true;


            //body.AddForce( CtrlGamePlay.ForceFlipperThrow , ForceMode2D.Force);


            Debug.Log("Add Force");
          
        }
        else
        {
            Debug.Log("Deo");
        }




    }
    public void Reset()
    {
        isWall = false;
        transform.position = PosInit;
        //  transform.parent = CtrlGamePlay.Ins.Fliper.transform;
        body.velocity = Vector3.zero;
        body.angularVelocity = 0;

        //  GetComponent<TrailRenderer>().enabled = false;
        //   body.isKinematic = true;
        //  body.simulated = false;

        transform.eulerAngles = Vector3.zero;
        SkinBall.sprite = Ctrl_Player.Ins.GetSkinBall();


    }
    public void ActiveBall(bool active)
    {
        gameObject.SetActive(active);

    }

    public void ReflectDirect()
    {
        //  body.velocity = Vector3.SqrMagnitude(body.velocity)*2*(Vector3.Reflect(body.velocity.normalized, Vector3.up)).normalized ;

        Vector3 vec = body.velocity;
        vec.x = -vec.x;
        body.velocity = vec;
    }

    public void LoadDataPlayer()
    {

    }

}
