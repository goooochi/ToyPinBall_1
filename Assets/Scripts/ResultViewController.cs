using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultViewController : MonoBehaviour
{

    static GameManager gameManager;

    public Text winnerText;


    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.scoreUser1 > GameManager.scoreUser2)
        {
            winnerText.text = $"{InputTextManager.instance.User1NameText.text} is Win!";
        }
        else
        {
            winnerText.text = $"{InputTextManager.instance.User2NameText.text} is Win!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
