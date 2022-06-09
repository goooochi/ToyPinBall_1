using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public GameManager gameManager;

    public int User1hitScore;
    public int User2hitScore;

    public Text scoreInformationText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (SceneManager.GetActiveScene().name == "1-1" || SceneManager.GetActiveScene().name == "1-3" || SceneManager.GetActiveScene().name == "1-5")
        {
            //GameManager側にて、score宣言時にpublicがついているからできること
            GameManager.scoreUser1 += User1hitScore;

            if(User1hitScore == 1000)
            {
                scoreInformationText.text = "Base Hit!";
                Invoke("TextHide", 1.0f);
            }
            else if(User1hitScore == 2000)
            {
                scoreInformationText.text = "Two Base Hit!!";
                Invoke("TextHide", 1.0f);
            }
            else if(User1hitScore == 3000)
            {
                scoreInformationText.text = "Three Base Hit!!!";
                Invoke("TextHide", 1.0f);
            }
            else
            {
                scoreInformationText.text = "Home Run!!!!";
                Invoke("TextHide", 1.0f);
            }
        }
        else
        {
            //GameManager側にて、score宣言時にpublicがついているからできること
            GameManager.scoreUser2 += User2hitScore;

            if (User1hitScore == 1000)
            {
                scoreInformationText.text = "Base Hit!";
                Invoke("TextHide", 1.0f);
            }
            else if (User1hitScore == 2000)
            {
                scoreInformationText.text = "Two Base Hit!!";
                Invoke("TextHide", 1.0f);
            }
            else if (User1hitScore == 3000)
            {
                scoreInformationText.text = "Three Base Hit!!!";
                Invoke("TextHide", 1.0f);
            }
            else
            {
                scoreInformationText.text = "Home Run!!!!";
                Invoke("TextHide", 1.0f);
            }
        }
            
    }


    void TextHide()
    {
        scoreInformationText.text = "";
    }
}
