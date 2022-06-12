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
    int instantiateNumber_1;
    int instantiateNumber_2;

    

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

        Instantiate(Ball, new Vector3(-10, 5, 9), Quaternion.identity);
        if (SceneManager.GetActiveScene().name == "1-1" || SceneManager.GetActiveScene().name == "1-3" || SceneManager.GetActiveScene().name == "1-5")
        {
            UserName.text = InputTextManager.instance.User1NameText.text + " is Playing!";
        }
        else
        {
            UserName.text = InputTextManager.instance.User2NameText.text + " is Playing!";
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "1-1" || SceneManager.GetActiveScene().name == "1-3" || SceneManager.GetActiveScene().name == "1-5")
        {
            scoreText.text = "Score :  " + scoreUser1.ToString("f0");
        }
        else
        {
            scoreText.text = "Score :  " + scoreUser2.ToString("f0");
        }

    }

    public void BallInstantiate()
    {
        instantiateNumber_1 = Random.Range(-11, -7);
        instantiateNumber_2 = Random.Range(3, 8);
        float halfRandom = Random.Range(-2, 2);
        

        if (halfRandom >= 0)
        {
            
            Instantiate(Ball, new Vector3(instantiateNumber_1, 5, 9), Quaternion.identity);
        }
        else
        {
            
            Instantiate(Ball, new Vector3(instantiateNumber_2, 5, 9), Quaternion.identity);

        }
    }
}

