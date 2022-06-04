using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using 

public class GameOverManager : MonoBehaviour
{

    //Outの実装
    public GameObject Out1;
    public GameObject Out2;

    public int outCount = 0;

    //public GameObject Ball;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Out1.SetActive(false);
        Out2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (outCount == 1)
        {
            Out1.SetActive(true);
        }else if (outCount == 2)
        {
            Out2.SetActive(true);
        }else if(outCount == 3)
        {
            gameManager.turnEndText.text = "交代！";
            
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            outCount++;
            if(outCount <= 2)
            {
                gameManager.BallInstantiate();
            }
        }
        Destroy(collision.gameObject);
    }
}
