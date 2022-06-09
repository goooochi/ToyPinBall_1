using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGene : MonoBehaviour
{
    public Vector3 targetpos;

    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetpos.x, -Mathf.Sin(Time.time) * 4.0f + targetpos.y, -Mathf.Sin(Time.time) * 4.0f + targetpos.z);
    }
}
