using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bumper : MonoBehaviour
{
    private float power = 200.0f;
    private Vector3 vector;

    //Outの実装
    public GameObject Strike1;
    public GameObject Strike2;

    public int outCount = 0;

    //アニメーション
    Animator animator;
    //上半身のコライダー用
    GameObject headCollider;

    Rigidbody playerRigidbody;

    public static Bumper instance;
    public GameManager gameManager;
    static GameOverManager gameOverManager;
    //public static SliderController sliderController;

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
        Strike1.SetActive(false);
        Strike2.SetActive(false);

        animator = GetComponent<Animator>();

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

            if(playerRigid.velocity.magnitude < 4.5f)
            {
                vector = new Vector3(Random.Range(-3,4),0,0);
                playerRigid.AddForce(-playerRigid.velocity * power * 6);
                playerRigid.AddForce(vector * 400);
            }
            else
            {
                playerRigid.AddForce(-playerRigid.velocity * power);
            }


            GameManager.instance.isCatchCount += 1;
            if (GameManager.instance.isCatchCount == 1)
            {
                Debug.Log("Strike1");
                Strike1.SetActive(true);
            }
            else if (GameManager.instance.isCatchCount == 2)
            {
                Debug.Log("Strike2");
                Strike2.SetActive(true);
            }
            else
            {
                Audio.PlayOneShot(BGM);
                GameOverManager.gameOverManager.outCount++;
                if (GameOverManager.gameOverManager.outCount <= 2)
                {
                    SliderController.instance.slider.gameObject.SetActive(true);
                    SliderController.instance.isClicked = false;
                    //GameManager.instance.BallInstantiate();
                }

                Destroy(other.gameObject);
                Strike1.SetActive(false);
                Strike2.SetActive(false);
                GameManager.instance.isCatchCount = 0;
            }
 
            animator.SetBool("Attack", true);
            Invoke("turnFalse", 1.0f);
            
        }

        if (other.transform.CompareTag("ScoreupBall"))
        {
            // プレイヤーのリジッドボディを取得
            Rigidbody playerRigid = other.transform.GetComponent<Rigidbody>();

            if (playerRigid.velocity.magnitude < 4.5f)
            {
                vector = new Vector3(Random.Range(-3, 4), 0, 0);
                playerRigid.AddForce(-playerRigid.velocity * power * 6);
                playerRigid.AddForce(vector * 400);
            }
            else
            {
                playerRigid.AddForce(-playerRigid.velocity * power);
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