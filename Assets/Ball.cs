using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Ins;
    public static bool isCollWithFlipper = false;
    public Rigidbody2D body;
    public Vector3 PosInit;
    
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
        CtrlGamePlay.Ins.eventForRerestGame += Reset;
    }
    // Start is called before the first frame update
    void Start()
    {
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
            body.AddForce(CtrlGamePlay.ForceFlipperThrow, ForceMode2D.Force);
            Debug.Log("Add Force : " + CtrlGamePlay.ForceFlipperThrow);
        }

           
           
        
    }
    public void Reset()
    {
        transform.position = PosInit;
        body.velocity = Vector3.zero;
        body.isKinematic = true;
    }
   
}
