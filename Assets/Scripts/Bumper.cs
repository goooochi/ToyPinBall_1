using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private float power = 200.0f;

    //アニメーション
    Animator animator;
    //上半身のコライダー用
    GameObject headCollider;

    Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void OnCollisionEnter(Collision other)
    {


        // 今回はタグでプレイヤーかどうか判断
        if (other.transform.CompareTag("Ball"))
        {
            // プレイヤーのリジッドボディを取得
            Rigidbody playerRigid = other.transform.GetComponent<Rigidbody>();

            Debug.Log(playerRigid.velocity.magnitude.ToString());

            if(playerRigid.velocity.magnitude < 2.0f)
            {
                playerRigid.AddForce(-playerRigid.velocity * power * 5);
            }
            else
            {
                playerRigid.AddForce(-playerRigid.velocity * power);
            }
            // プレイヤーのリジッドボディに、現在の進行方向の逆向きに力を加える

            animator.SetBool("Attack", true);
            Invoke("turnFalse", 1.0f);
        }
    }

    public void turnFalse()
    {
        animator.SetBool("Attack", false);
    }
}