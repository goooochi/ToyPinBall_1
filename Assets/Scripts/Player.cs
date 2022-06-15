using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameManager gameManager;

    private float power = 10.0f;

    float LeftforceAngle = -1.5f;

    float RightforceAngle = 1.5f;

    Vector3 LeftforceDirection;
    Vector3 RightforceDirection;


    // Start is called before the first frame update
    void Start()
    {
        LeftforceDirection = new Vector3(LeftforceAngle, 1.0f, 1.0f);
        RightforceDirection = new Vector3(RightforceAngle, 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Rigidbody playerRigid = transform.GetComponent<Rigidbody>();
        //playerRigid.AddForce(playerRigid.velocity);
    }

    public void OnCollisionStay(Collision collision)
    {
        // 今回はタグでプレイヤーかどうか判断
        if (collision.gameObject.tag == "LeftMainWall")
        {
            // プレイヤーのリジッドボディを取得
            Rigidbody playerRigid = transform.GetComponent<Rigidbody>();

            // プレイヤーのリジッドボディに、現在の進行方向の逆向きに力を加える
            playerRigid.AddForce(-LeftforceDirection * power);
        }

        if (collision.gameObject.tag == "RightMainWall")
        {
            // プレイヤーのリジッドボディを取得
            Rigidbody playerRigid = transform.GetComponent<Rigidbody>();

            // プレイヤーのリジッドボディに、現在の進行方向の逆向きに力を加える
            playerRigid.AddForce(-RightforceDirection * power);
        }

    }
}
