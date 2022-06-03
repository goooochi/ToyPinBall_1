using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    InputTextManager inputTextManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //シーンの名前がTitleならば
        if (SceneManager.GetActiveScene().name == "Title")
        {
            if(inputTextManager.Prepare1 == true)
                //spaceキーを押したら
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                   ToMain();

                 }
            }

        //if (SceneManager.GetActiveScene().name == "Result")
        //{
        //    //spaceキーを押したら
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        ToMain();

        //    }
        //}
    }

    public void ToMain()
    {
        //Mainシーンに移動する
        SceneManager.LoadScene("Main");
    }

    //public void ToResult()
    //{
    //    //Resultシーンに移動する
    //    SceneManager.LoadScene("Result");
    //}
}
