using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGene3 : MonoBehaviour
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
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x >= -9.0f)
            {
                transform.position -= new Vector3(slideSpeed, 0, 0) * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x <= 9.0f)
            {
                transform.position += new Vector3(slideSpeed, 0, 0) * Time.deltaTime;
            }
        }
    }

    //-4から9
}
