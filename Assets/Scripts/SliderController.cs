using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public static SliderController instance;
    
    public ScoreManager scoreManager;

    public  Slider slider;
    public bool maxValue;
    public bool isClicked;
    public bool BallCheck = true;
    public bool SecondClickLock;
    public Text resultText;
    public int BallCheckCount = 0;
    public GameObject Ball1;
    public GameObject Ball2;
    public GameObject Ball3;
    public GameObject MaskCube;
    int instantiateNumber_1;
    public Text MissionText;
   

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
        

        Ball1.SetActive(false);
        Ball2.SetActive(false);
        Ball3.SetActive(false);

        slider.value = 1;
        maxValue = false;
        isClicked = false;
        SecondClickLock = false;

        instantiateNumber_1 = Random.Range(70, 90);
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log(SecondClickLock + " 前段階");
            isClicked = true;
            StartCoroutine(Setactivefalse(2, MaskCube));
            MissionText.text = "";
            TextFlicker.instance.txt.gameObject.SetActive(false);

            if (SecondClickLock == false)
            {
                
                BallCheck = true;

                // ballの処理
                if (slider.value < instantiateNumber_1)
                {
                    BallCheckCount++;
                    resultText.text = "Faild";
                    StartCoroutine(TextDelete(2, resultText));

                    if (BallCheckCount == 1)
                    {
                        Ball1.SetActive(true);
                    }else if (BallCheckCount == 2)
                    {
                        Ball2.SetActive(true);
                        ScoreManager.instance.isFever = true;
                    }else if (BallCheckCount == 3)
                    {
                        Ball3.SetActive(true);
                        //ボールを2個生成
                        GameManager.instance.Invoke("ScoreupballInstantiate", 2.0f);
                        GameOverManager.instance.TwoBalls = true;
                    }
                }
                else
                {
                    resultText.text = "Success!";
                    StartCoroutine(TextDelete(2, resultText));
                }

                Debug.Log(SecondClickLock + " 2段階");

                // ballの生成
                if (BallCheck)
                {
                    GameManager.instance.Invoke("BallInstantiate", 2.0f);
                    BallCheck = false;
                    slider.gameObject.SetActive(false);
                }

                
                SecondClickLock = true;
            }
           
        }

        //クリックされていなければ実行
        if (!isClicked)
        {
            
            MissionText.text = $"Stop at {instantiateNumber_1}% or more!";
            TextFlicker.instance.txt.gameObject.SetActive(true);
            MaskCube.SetActive(true);


            if (slider.value == 100)
            {
                maxValue = true;
            }

            if (slider.value <= 1)
            {
                maxValue = false;
            }

            //フラグによるスライダー値の増減
            if (maxValue)
            {
                slider.value -= slider.value / 8;
            }
            else
            {
                slider.value += 1;
                slider.value += slider.value / 8;
            }
        }
    }

    public IEnumerator TextDelete(int sec1, Text text)
    {
        yield return new WaitForSeconds(sec1);

        text.text = "";
    }

    public IEnumerator Setactivefalse(int sec1, GameObject gameObject)
    {
        yield return new WaitForSeconds(sec1);
        gameObject.SetActive(false);
    }
    
}
