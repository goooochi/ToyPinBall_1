using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public static Ranking instance;
    static GameManager gameManager;

    public Text[] rankingScoreText = new Text[5];
    public Text[] rankingUserNameText = new Text[5];

    //キーの作成
    string[] rankingkey = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    int[] rankingValue = new int[5];

    //キーの作成
    string[] rankingUserNamekey = { "User1", "User2", "User3", "User4", "User5" };
    string[] rankingName = new string[5];

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        //GetRanking();

        for (int i = 0; i < rankingkey.Length; i++)
        {
            rankingScoreText[i].text = PlayerPrefs.GetInt(rankingkey[i]).ToString();
            rankingUserNameText[i].text = PlayerPrefs.GetString(rankingUserNamekey[i]);
        }


        //Test.text = PlayerPrefs.GetInt("キー", GameManager.scoreUser2).ToString();
    }

    public void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < rankingkey.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(rankingkey[i]);
            rankingName[i] = PlayerPrefs.GetString(rankingUserNamekey[i]);
        }
    }


    public void SetRanking(int _value, string _UserName)
    {
        GetRanking();
        Debug.Log("書き込み");
        //書き込み用
        for (int i = 0; i < rankingkey.Length; i++)
        {
            //取得した値とRankingの値を比較して入れ替え
            if (_value > rankingValue[i])
            {
                var change_value = rankingValue[i];
                var change_UserName = rankingName[i];
                rankingValue[i] = _value;
                rankingName[i] = _UserName;
                _value = change_value;
                _UserName = change_UserName;
            }
        }

        //入れ替えた値を保存
        for (int i = 0; i < rankingkey.Length; i++)
        {
            PlayerPrefs.SetInt(rankingkey[i], rankingValue[i]);
            PlayerPrefs.SetString(rankingUserNamekey[i], rankingName[i]);
        }
    }

}
