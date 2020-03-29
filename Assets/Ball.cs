using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public SphereCollider Box3D;
    public static Ball Ins;
    public static bool isCollWithFlipper = false;
    public Rigidbody2D body;
    public Vector3 PosInit;
    public float Angle = 0;
    public SpriteRenderer SkinBall;
    
    public bool ForceInit = false;



    bool collwith_1 = false;
    bool collwith_2 = false;
//    bool collwith_3 = false;

    public float xForce = 1;
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
        body.gravityScale = body.gravityScale * CtrlGamePlay.scaleScreen;
        CtrlGamePlay.Ins.eventForRerestGame += Reset;
        body = GetComponent<Rigidbody2D>();
        Reset();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CtrlAudio.Ins.Play("Coll");
        if(collision.gameObject.layer == 9)
        {
            if (collision.gameObject.tag == "1")
            {
                xForce = 1.5f;
            }


            
                isCollWithFlipper = true;
        
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 9)
        {
            if (collision.gameObject.tag == "1")
            {
                xForce = 1;
            }

           
               

            isCollWithFlipper = false;
            
        }
    }
    
    public void ThrowBall()
    {

        if (isCollWithFlipper) 
        {
            Debug.Log("Fire");
             Instantiate(CtrlGamePlay.Ins.Test, CtrlGamePlay.Ins.MainCanvas);
            Vector3 vec = Vector3.zero;

            if (CtrlGamePlay.Ins.isReflect)
            {
               vec = (new Vector2(CtrlGamePlay.ForceFlipperThrow.x, Mathf.Abs(CtrlGamePlay.ForceFlipperThrow.y))) * CtrlGamePlay.Ins.SpeedThrowBall*xForce;
                Debug.Log("DD");
            }
            else
            {
               vec = (new Vector2(CtrlGamePlay.ForceFlipperThrow.x, Mathf.Abs(CtrlGamePlay.ForceFlipperThrow.y))) * CtrlGamePlay.Ins.SpeedThrowBall*xForce;
            }
            vec.y = Mathf.Abs(vec.y);
            body.AddForce(vec*CtrlGamePlay.scaleScreen * CtrlGamePlay.Ins.offsetReflect, ForceMode2D.Force);

               
                CtrlGamePlay.ForceThrow = 0;
          
            //body.AddForce( CtrlGamePlay.ForceFlipperThrow , ForceMode2D.Force);
          
           
            
           
        }

           
           
        
    }
    public void Reset()
    {
       
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
