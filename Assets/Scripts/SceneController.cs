using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    static InputTextManager inputTextManager;

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
            if(InputTextManager.instance.Prepare1 && InputTextManager.instance.Prepare2)
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
        SceneManager.LoadScene("1-1");
    }

    //public void ToResult()
    //{
    //    //Resultシーンに移動する
    //    SceneManager.LoadScene("Result");
    //}
}
