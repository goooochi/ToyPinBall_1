using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float power = 10.0f;

    float LeftforceAngle = -10.0f;

    float RightforceAngle = 10.0f;

    Vector3 LeftforceDirection;
    Vector3 RightforceDirection;

    private GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        LeftforceDirection = new Vector3(LeftforceAngle, 1.0f, 1.0f);
        RightforceDirection = new Vector3(RightforceAngle, 1.0f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // 今回はタグでプレイヤーかどうか判断
        if (other.transform.CompareTag("LeftMainWall"))
        {
            // プレイヤーのリジッドボディを取得
            Rigidbody playerRigid = transform.GetComponent<Rigidbody>();

            // プレイヤーのリジッドボディに、現在の進行方向の逆向きに力を加える
            playerRigid.AddForce(-LeftforceDirection * power);
        }

        if (other.transform.CompareTag("RightMainWall"))
        {
            // プレイヤーのリジッドボディを取得
            Rigidbody playerRigid = transform.GetComponent<Rigidbody>();

            // プレイヤーのリジッドボディに、現在の進行方向の逆向きに力を加える
            playerRigid.AddForce(-RightforceDirection * power);
        }
    }
}
