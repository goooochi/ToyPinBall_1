using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class TargetGene2 : MonoBehaviour
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
            if (transform.position.y >= 8.0)
            {
                transform.position += new Vector3(0, -slideSpeed, -slideSpeed) * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y <= 17.0)
            {
                transform.position -= new Vector3(0, -slideSpeed, -slideSpeed) * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            if (SceneManager.GetActiveScene().name == "1-1" || SceneManager.GetActiveScene().name == "1-3" || SceneManager.GetActiveScene().name == "1-5")
            {
                Debug.Log("あたったよ");
                GameManager.scoreUser2 += 500;
            }
            else
            {
                Debug.Log("あたったよ");
                GameManager.scoreUser1 += 500;
            }
        }
    }
}