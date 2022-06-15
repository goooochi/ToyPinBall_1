using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public GameManager gameManager;

    public int UserhitScore;
    
    public Text scoreInformationText;

    public AudioClip ScoreUpBGM;
    public AudioClip HomeRunBGM;
    AudioSource Audio;
    public bool isFever;

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
        //このスクリプトがアタッチされたオブジェクトに付与されているAudioSourceコンポーネントを認識させる
        Audio = GetComponent<AudioSource>();
        isFever = false;
    }

    //Update is called once per frame
    

    public void OnCollisionEnter(Collision collision)
    {
        
        if (SceneManager.GetActiveScene().name == "1-1" || SceneManager.GetActiveScene().name == "1-3" || SceneManager.GetActiveScene().name == "1-5")
        {
            
                //GameManager側にて、score宣言時にpublicがついているからできること
                GameManager.scoreUser1 += UserhitScore;
            
            
        }
        else
        {
            
                //GameManager側にて、score宣言時にpublicがついているからできること
                GameManager.scoreUser2 += UserhitScore;
            
        }


        if (UserhitScore == 1000)
        {
            Audio.PlayOneShot(ScoreUpBGM);
            scoreInformationText.text = "BaseHit!";
            Invoke("TextHide", 1.0f);
        }
        else if (UserhitScore == 2000)
        {
            Audio.PlayOneShot(ScoreUpBGM);
            scoreInformationText.text = "TwoBaseHit!!";
            Invoke("TextHide", 1.0f);
        }
        else if (UserhitScore == 3000)
        {
            Audio.PlayOneShot(ScoreUpBGM);
            scoreInformationText.text = "ThreeBaseHit!!!";
            Invoke("TextHide", 1.0f);
        }
        else
        {
            Audio.PlayOneShot(HomeRunBGM);
            scoreInformationText.text = "HomeRun!!!!";
            Invoke("TextHide", 1.0f);
        }
    }


    void TextHide()
    {
        scoreInformationText.text = "";
    }
}
