using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Spawn : MonoBehaviour
{
    public List<GameObject> PrebObjGame;

    public List<Transform> Right;
    public List<Transform> Left;
    public float offsetX;
    public Transform TransGamePlay;
    float distanceLeft;
    float distanceRight;
    Vector2 PosRight;
    Vector2 PosLeft;
    // Start is called before the first frame update
    void Start()
    {
        PosRight = Right[0].transform.position;
        PosLeft = Left[0].transform.position;
        distanceLeft = Vector2.Distance(Left[0].transform.position, Left[1].transform.position);
        distanceRight = Vector2.Distance(Right[0].transform.position, Right[1].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnBasket(Random.Range(0, 2) == 1 ? true : false);
        }
        Debug.Log("Spawn");
    }
    public void SpawnBasket(bool isLeft)
    {
        int i = isLeft ? -1 : 1;

        if (isLeft)
        {
            Vector2 pos = (Vector2)Left[0].transform.position - Vector2.up * Random.Range(0, distanceLeft) + Vector2.right*offsetX*i;

            var a =   Poolers.Ins.GetObject(PrebObjGame[0],pos,Quaternion.identity);

            a.GetComponent<Basket>().Start_Move_Spawn(pos.x - (offsetX * i));

            a.OnSpawn();

        }
        else
        {
            Vector2 pos = (Vector2)Right[0].transform.position - Vector2.up * Random.Range(0, distanceRight) + Vector2.right*offsetX*i;

          var a =   Poolers.Ins.GetObject(PrebObjGame[1],pos,Quaternion.identity);
            a.GetComponent<Basket>().Start_Move_Spawn(pos.x - (offsetX * i));

            a.OnSpawn();

        }
    }
}
