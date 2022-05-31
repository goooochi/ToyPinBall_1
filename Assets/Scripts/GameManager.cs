using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text scoreText;

    public int score;

    //Outの実装
    public GameObject Out1;
    public GameObject Out2;

    public bool isOneOut;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Out1.SetActive(false);
        Out2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score.ToString("f0");

    }

    

}
