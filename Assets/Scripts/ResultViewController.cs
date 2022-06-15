using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultViewController : MonoBehaviour
{

    static GameManager gameManager;
    static InputTextManager inputTextManager;

    public Text winnerText;

    public Text scoreResltText;

    private static bool isLook = true;

    public AudioClip WinBGM;
    public AudioClip DrawBGM;
    AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        //このスクリプトがアタッチされたオブジェクトに付与されているAudioSourceコンポーネントを認識させる
        Audio = GetComponent<AudioSource>();

        if (GameManager.scoreUser1 > GameManager.scoreUser2)
        {
            Audio.PlayOneShot(WinBGM);
            winnerText.text = $"{InputTextManager.instance.User1NameText.text} is Win!";
            scoreResltText.text = $"Score : {GameManager.scoreUser1}";
        }
        else if (GameManager.scoreUser1 < GameManager.scoreUser2)
        {
            Audio.PlayOneShot(WinBGM);
            winnerText.text = $"{InputTextManager.instance.User2NameText.text} is Win!";
            scoreResltText.text = $"Score : {GameManager.scoreUser2}";
        }
        else
        {
            Audio.PlayOneShot(DrawBGM);
            //
            scoreResltText.text = $"Score : {GameManager.scoreUser2}";
            //
            winnerText.text = "Draw!";
        }

        Ranking ranking = new Ranking();

        if (isLook == true)
        {
            //ranking.SetRanking(GameManager.scoreUser1, InputTextManager.instance.User1NameText.text);
            ranking.SetRanking(GameManager.scoreUser1, InputTextManager.instance.User1NameText.text);
            ranking.SetRanking(GameManager.scoreUser2, InputTextManager.instance.User2NameText.text);
            isLook = false;
        }

    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}


}
