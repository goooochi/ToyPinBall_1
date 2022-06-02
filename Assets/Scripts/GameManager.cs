using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text scoreText;

    public int score;

    public Text turnEndText;

    public GameObject Ball;

    public bool isPlaying;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Instantiate(Ball, new Vector3(-7, -3, 1), Quaternion.identity);
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score.ToString("f0");
    }

    public void BallInstantiate()
    {
        int position = Random.Range(-2, 15);
        Instantiate(Ball, new Vector3(position, -4, 0), Quaternion.identity);
    }
}
