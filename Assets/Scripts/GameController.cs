using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * 脚本功能：计数器控制
 * 编写日期：2019-03-15
 * 编写人：HYZ
 */
public class GameController : MonoBehaviour {
    [SerializeField]
    private Text showText;
    [SerializeField]
    private Button countBtn;
    [SerializeField]
    private Button zeroBtn;
    /// <summary>
    /// 本地保存的Key值
    /// </summary>
    private const string saveKey = "NainFo";

    /// <summary>
    /// 当前计数
    /// </summary>
    private int count = 0;


    void OnAwake()
    {
        GetKey();
    }

    void Start()
    {
        countBtn.onClick.AddListener(CountClick);
        zeroBtn.onClick.AddListener(OnZeroClick);
    }

    void OnDestroy()
    {
        countBtn.onClick.RemoveListener(CountClick);
        zeroBtn.onClick.RemoveListener(OnZeroClick);
        PostKey();
    }

    /// <summary>
    /// 自增
    /// </summary>
    private void CountClick()
    {
        count++;
        showText.text = "念佛第"+count+"声";
//#if UNITY_ANDROID && !UNITY_EDITOR
//         Handheld.Vibrate();
//#endif
    }

    /// <summary>
    /// 清零
    /// </summary>
    private void OnZeroClick()
    {
        count = 0;
        showText.text = "计数清零";
    }

    void PostKey()
    {
        PlayerPrefs.SetInt(saveKey,count);
    }

    void GetKey()
    {
        count = PlayerPrefs.GetInt(saveKey);
        showText.text = "念佛第" + count + "声";
    }

}
