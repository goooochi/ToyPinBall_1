using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bumper : MonoBehaviour
{
    private float power = 200.0f;
    private Vector3 vector;

    

    //アニメーション
    Animator animator;
    //上半身のコライダー用
    GameObject headCollider;

    Rigidbody playerRigidbody;

    public static Bumper instance;
    public GameManager gameManager;

    static GameOverManager gameOverManager;

    public AudioClip BGM;
    AudioSource Audio;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        

        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

        //このスクリプトがアタッチされたオブジェクトに付与されているAudioSourceコンポーネントを認識させる
        Audio = GetComponent<AudioSource>();
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

            if(playerRigid.velocity.magnitude < 2.5f)
            {
                vector = new Vector3(Random.Range(-2,3),0,0);
                playerRigid.AddForce(-playerRigid.velocity * power * 5);
                playerRigid.AddForce(vector * 300);
            }
            else
            {
                playerRigid.AddForce(-playerRigid.velocity * power);
            }

            GameManager.instance.isCatchCount += 1;
            Debug.Log("isCatchCount : " + GameManager.instance.isCatchCount.ToString());
            if (GameManager.instance.isCatchCount == 3)
            {
                Audio.PlayOneShot(BGM);
                GameOverManager.gameOverManager.outCount++;
                if (GameOverManager.gameOverManager.outCount <= 2)
                {
                    GameManager.instance.BallInstantiate();
                }

                Destroy(other.gameObject);
                GameManager.instance.isCatchCount = 0;
            }

            animator.SetBool("Attack", true);
            Invoke("turnFalse", 1.0f);
            
        }
    }

    public void turnFalse()
    {
        animator.SetBool("Attack", false);
    }
}