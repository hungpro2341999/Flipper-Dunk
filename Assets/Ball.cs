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
    public bool ForceInit = false;
    private void Awake()
    {
        Physics2D.defaultContactOffset = 0.07f;
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
        if(collision.gameObject.layer == 9)
        {
          
            isCollWithFlipper = true;
        
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 9)
        {

            isCollWithFlipper = false;
            
        }
    }
    public void ThrowBall()
    {

        if (isCollWithFlipper) 
        {

            // Instantiate(CtrlGamePlay.Ins.Test, CtrlGamePlay.Ins.MainCanvas);
            if (!ForceInit)
            {

               
                //body.AddForce( CtrlGamePlay.ForceFlipperThrow , ForceMode2D.Force);
                Vector3 vec = Quaternion.AngleAxis(Mathf.Abs(CtrlGamePlay.Ins.angle * 0.65f), Vector3.forward) * (new Vector2(CtrlGamePlay.ForceFlipperThrow.x, CtrlGamePlay.ForceFlipperThrow.y)) * 7.5f;
                body.AddForce(vec * CtrlGamePlay.Ins.offsetReflect, ForceMode2D.Force);
               
                // body.velocity = Quaternion.AngleAxis(CtrlGamePlay.Angle,Vector3.forward)*(new Vector2(CtrlGamePlay.ForceFlipperThrow.x,Mathf.Abs(CtrlGamePlay.ForceFlipperThrow.y)));
                CtrlGamePlay.ForceThrow = 0;
            }
            else
            {
                Vector3 vec = (new Vector2(-CtrlGamePlay.ForceFlipperThrow.y, CtrlGamePlay.ForceFlipperThrow.x)) * 7.5f;
                Ball.Ins.transform.parent = Ctrl_Spawn.Ins.TransGamePlay;
                GetComponent<TrailRenderer>().enabled = true;
                ForceInit = false;
                body.AddForce(vec , ForceMode2D.Force);
                CtrlGamePlay.ForceThrow = 0;

            }
            
           
        }

           
           
        
    }
    public void Reset()
    {
        ForceInit = false ;
        transform.position = PosInit;
      //  transform.parent = CtrlGamePlay.Ins.Fliper.transform;
        body.velocity = Vector3.zero;
      //  GetComponent<TrailRenderer>().enabled = false;
        body.isKinematic = true;
        body.simulated = false;

        transform.eulerAngles = Vector3.zero;



    }
    public void ActiveBall()
    {
      
        body.simulated = true;
        body.isKinematic = false;
    }

    public void ReflectDirect()
    {
        //  body.velocity = Vector3.SqrMagnitude(body.velocity)*2*(Vector3.Reflect(body.velocity.normalized, Vector3.up)).normalized ;

        Vector3 vec = body.velocity;
        vec.x = -vec.x;
        body.velocity = vec;
    }
   
  

}
