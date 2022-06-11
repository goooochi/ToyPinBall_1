using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;
//using UnityStandardAssets.Vehicles.Car;


public class TargetGene2 : MonoBehaviour
{
    public Vector3 targetpos;
    public float slideSpeed = 10.0f;



    //public float time = 0.0f;

    //float vertical;

    //public int thisMovableBumperID;

    // Start is called before the first frame update
    void Start()
    {
        //targetpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //float posY = transform.position.y;
        //float posZ = transform.position.z;

        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y >= 10.0)
            {
                transform.position += new Vector3(0, -slideSpeed, -slideSpeed) * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y <= 21.0)
            {
                transform.position -= new Vector3(0, -slideSpeed, -slideSpeed) * Time.deltaTime;
            }
        }
    }

    //public float Abs(float number)
    //{
    //    if (number < 0)
    //    {
    //        return number * -1;
    //    }
    //    else
    //    {
    //        return number;
    //    }
    //}

}
