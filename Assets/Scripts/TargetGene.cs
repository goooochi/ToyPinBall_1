using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

public class TargetGene : MonoBehaviour
{
    public Vector3 targetpos;
    public float slideSpeed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
