using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text scoreText;

    public int score;

    
    //public bool isOneOut;

    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score.ToString("f0");

        
    }

    

}
