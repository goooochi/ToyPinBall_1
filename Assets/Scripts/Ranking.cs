using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public static Ranking instance;


    [SerializeField, Header("数値")]
    int point;
    string UserName;

    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    int[] rankingValue = new int[5];

    string[] rankingUserName = { "User1", "User2", "User3", "User4", "User5" };
    string[] rankingName = new string[5];


    [SerializeField, Header("表示させるテキスト_value")]
    Text[] rankingText = new Text[5];

    [SerializeField, Header("表示させるテキスト_name")]
    Text[] rankingnameText = new Text[5];


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
        GetRanking();

        SetRanking(point, UserName);

        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingValue[i].ToString();
        }
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    public void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    public void SetRanking(int _value,string _UserName)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
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
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
            PlayerPrefs.SetString(rankingUserName[i], rankingName[i]);
        }
    }

    //public void SetRankingName(string userName)
    //{
    //    //書き込み用
    //    for (int i = 0; i < ranking.Length; i++)
    //    {
    //        //取得した値とRankingの値を比較して入れ替え
    //        if (userName > rankingName[i])
    //        {
    //            var change = rankingName[i];
    //            rankingName[i] = userName;
    //            userName = change;
    //        }
    //    }

    //    //入れ替えた値を保存
    //    for (int i = 0; i < ranking.Length; i++)
    //    {
    //        PlayerPrefs.SetString(rankingUserName[i], rankingName[i]);
    //    }
    //}
}
