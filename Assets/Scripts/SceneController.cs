using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    static InputTextManager inputTextManager;
    static GameOverManager gameOverManager;
    

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
            if (InputTextManager.instance.Prepare1 && InputTextManager.instance.Prepare2)
                //spaceキーを押したら
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ToMain();
                }
        }

        if (SceneManager.GetActiveScene().name == "1-1")
        {
            //1-2に移動
            if (GameOverManager.sceneCount == 2)
            {
                Invoke("ToNext", 4.0f);
            }
        }

        if (SceneManager.GetActiveScene().name == "1-2")
        {
            //1-3に移動
            if (GameOverManager.sceneCount == 3)
            {
                Invoke("ToNext", 4.0f);
            }
        }

        if (SceneManager.GetActiveScene().name == "1-3")
        {
            //1-4に移動
            if (GameOverManager.sceneCount == 4)
            {
                Invoke("ToNext", 4.0f);
            }
        }

        if (SceneManager.GetActiveScene().name == "1-4")
        {
            //1-5に移動
            if (GameOverManager.sceneCount == 5)
            {
                Invoke("ToNext", 4.0f);
            }
        }

        if (SceneManager.GetActiveScene().name == "1-5")
        {
            //1-6に移動
            if (GameOverManager.sceneCount == 6)
            {
                Invoke("ToNext", 4.0f);
            }
        }

        if (SceneManager.GetActiveScene().name == "1-6")
        {
            //1-6に移動
            if (GameOverManager.sceneCount == 7)
            {
                Invoke("ToResult", 4.0f);
            }
        }


        if (SceneManager.GetActiveScene().name == "Result")
        {
            //spaceキーを押したら
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ToTitle();
            }
        }

    }

    public void ToMain()
    {
        //Mainシーンに移動する
        SceneManager.LoadScene("1-1");
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void ToNext()
    {
        //Mainシーンに移動する
        SceneManager.LoadScene($"1-{GameOverManager.sceneCount}");
    }

    public void ToResult()
    {
        //Resultシーンに移動する
        SceneManager.LoadScene("Result");
    }

}
