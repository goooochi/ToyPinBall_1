using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public static SliderController instance;
    static GameManager gameManager;
    public  Slider slider;
    public bool maxValue;
    public bool isClicked;
    public bool BallCheck = true;
    public Text resultText;
    public int BallCheckCount = 0;
    public GameObject Ball1;
    public GameObject Ball2;
    public GameObject Ball3;
    int instantiateNumber_1;
    int instantiateNumber_2;

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

        slider.value = 0;
        maxValue = false;
        isClicked = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            BallCheck = true;
            isClicked = true;

            if(slider.value < 75)
            {
                BallCheckCount++;
                resultText.text = "Faild";
                Invoke("TextDelete", 2.0f);

                if (BallCheckCount == 1)
                {
                    Ball1.SetActive(true);
                }
                if (BallCheckCount == 2)
                {
                    Ball2.SetActive(true);
                }
                if (BallCheckCount == 3)
                {
                    Ball3.SetActive(true);
                    BallCheck = true;
                    GameManager.instance.Invoke("ScoreupballInstantiate", 2.0f);
                }

            }
            else
            {
                resultText.text = "Success!";
                Invoke("TextDelete", 2.0f);
            }

            if (BallCheck)
            {
                Debug.Log("Slider");
                GameManager.instance.Invoke("BallInstantiate", 2.0f);
                BallCheck = false;
                slider.gameObject.SetActive(false);
            }
        }

        //クリックされていなければ実行
        if (!isClicked)
        {
            instantiateNumber_1 = Random.Range(70, 90);
            instantiateNumber_2 = Random.Range(70, 90);

            //5に達した場合と、0に戻った場合のフラグ切替え
            if (slider.value == 100)
            {
                maxValue = true;
            }

            if (slider.value == 0)
            {
                maxValue = false;
            }

            //フラグによるスライダー値の増減
            if (maxValue)
            {
                slider.value -= 10f;
            }
            else
            {
                slider.value += 10f;
            }
        }
    }

    public void TextDelete()
    {
        resultText.text = "";
    }
}
