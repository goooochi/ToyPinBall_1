using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public static GameOverManager instance;

    static GameManager gameManager;

    //Outの実装
    public GameObject Out1;
    public GameObject Out2;
    public int outCount = 0;
    public static int sceneCount = 1;
    public bool TwoBalls;

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
        
        Out1.SetActive(false);
        Out2.SetActive(false);

        //このスクリプトがアタッチされたオブジェクトに付与されているAudioSourceコンポーネントを認識させる
        Audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (outCount == 1)
        {
            Out1.SetActive(true);
        }
        else if (outCount == 2)
        {
            Out2.SetActive(true);
        }
        else if(outCount == 3)
        {
            if (SceneManager.GetActiveScene().name == "1-6")
            {
                GameManager.instance.turnEndText.text = "Finish!";
            }
            else
            {
                GameManager.instance.turnEndText.text = "Change!";
            }


            if (GameManager.instance.isPlaying)
            {
                sceneCount++;
                //
                //sceneCount = 7;
                //
                GameManager.instance.isPlaying = false;
            }

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Audio.PlayOneShot(BGM);
        if (collision.gameObject.tag == "Ball")
        {
            if (TwoBalls)
            {
                GameManager.instance.Scoreupball.tag = "Ball";
                TwoBalls = false;
            }
            else
            {
                outCount++;
                if (outCount <= 2)
                {
                    SliderController.instance.slider.gameObject.SetActive(true);
                    SliderController.instance.isClicked = false;
                    SliderController.instance.SecondClickLock = false;
                    Debug.Log("SecondClickLock変えたよ");
                    //GameManager.instance.BallInstantiate();
                    GameManager.instance.isCatchCount = 0;
                }
                Bumper.instance.Strike1.SetActive(false);
                Bumper.instance.Strike2.SetActive(false);
            }

        }
        Destroy(collision.gameObject);
        
    }
}
