using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputTextManager : MonoBehaviour
{
    public static InputTextManager instance;

    public InputField User1InputField;
    public InputField User2InputField;
    public Text User1NameText;
    public Text User2NameText;
    public bool Prepare1;
    public bool Prepare2;

    public Text readyText;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // ボタンをゲットコンポーネント
        readyText = GameObject.Find("ReadyText").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        User1InputField = GameObject.Find("User1InputField").GetComponent<InputField>();
        User2InputField = GameObject.Find("User2InputField").GetComponent<InputField>();
        User1NameText = User1NameText.GetComponent<Text>();
        User2NameText = User2NameText.GetComponent<Text>();

        Prepare1 = false;
        Prepare2 = false;

        readyText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Prepare1 && Prepare2)
        {
            readyText.gameObject.SetActive(true);
        }
    }

    public void InputText1()
    {
        //InputFieldからテキスト情報を取得する
        string name = User1InputField.text;
        User1NameText.text = name;
        Prepare1 = true;
    }
    public void InputText2()
    {
        //InputFieldからテキスト情報を取得する
        string name = User2InputField.text;
        User2NameText.text = name;
        Prepare2 = true;
    }

}
