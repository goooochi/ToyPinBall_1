using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    //
    public static GameManager instance;
    //

    static InputTextManager inputTextManager;

    public Text scoreText;
    public static int scoreUser1;
    public static int scoreUser2;
    public Text turnEndText;
    public GameObject Ball;
    public Text UserName;
    public bool isPlaying;

    //
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        isPlaying = true;
    }
    //

    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(Ball, new Vector3(-7, -4, 1), Quaternion.identity);
        if (SceneManager.GetActiveScene().name == "1-1" || SceneManager.GetActiveScene().name == "1-3" || SceneManager.GetActiveScene().name == "1-5")
        {
            UserName.text = InputTextManager.instance.User1NameText.text + "がプレイ中！";
        }
        else
        {
            UserName.text = InputTextManager.instance.User2NameText.text + "がプレイ中！";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "1-1" || SceneManager.GetActiveScene().name == "1-3" || SceneManager.GetActiveScene().name == "1-5")
        {
            scoreText.text = "Score : " + scoreUser1.ToString("f0");
        }
        else
        {
            scoreText.text = "Score : " + scoreUser2.ToString("f0");
        }
        
    }

    public void BallInstantiate()
    {
        int position = Random.Range(-2, 10);
        Instantiate(Ball, new Vector3(position, -4, 1), Quaternion.identity);
    }
}


