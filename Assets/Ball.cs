using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Ins;
    public static bool isCollWithFlipper = false;
    public Rigidbody2D body;
    public Vector3 PosInit;
    public float Angle = 0;
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

            Instantiate(CtrlGamePlay.Ins.Test, CtrlGamePlay.Ins.MainCanvas);


            //body.AddForce( CtrlGamePlay.ForceFlipperThrow , ForceMode2D.Force);

            body.velocity = CtrlGamePlay.ForceFlipperThrow;
        }

           
           
        
    }
    public void Reset()
    {
        transform.position = PosInit;
        body.velocity = Vector3.zero;

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

        body.AddForce(Vector3.Reflect(body.velocity.normalized,Vector3.forward)*Vector3.SqrMagnitude(body.velocity),ForceMode2D.Force);
    }
   
}
