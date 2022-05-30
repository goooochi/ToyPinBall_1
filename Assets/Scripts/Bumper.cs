using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private float power = 250.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        

        // 今回はタグでプレイヤーかどうか判断
        if (other.transform.CompareTag("Ball"))
        {
            // プレイヤーのリジッドボディを取得
            Rigidbody playerRigid = other.transform.GetComponent<Rigidbody>();

            Debug.Log(playerRigid.velocity.magnitude.ToString());

            if (playerRigid.velocity.magnitude >= 2.7f)
            {
                // プレイヤーのリジッドボディに、現在の進行方向の逆向きに力を加える
                playerRigid.AddForce(-playerRigid.velocity * power * 0.8f);
            }
            else
            {
                playerRigid.AddForce(-playerRigid.velocity * power * 5);
            }
            
            
        }
    }
}