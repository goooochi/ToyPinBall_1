using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{

    //Outの実装
    public GameObject Out1;
    public GameObject Out2;

    public int outCount = 0;

    public GameObject Ball;

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
        }

        if (outCount == 2)
        {
            Out2.SetActive(true);
        }
        else
        {
            outCount = 0;

        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            outCount++;
            Destroy(collision.gameObject);

            int position = Random.Range(-8, 9);

            Instantiate(Ball, new Vector3(position, -4, 0), Quaternion.identity);

        }

    }


}
