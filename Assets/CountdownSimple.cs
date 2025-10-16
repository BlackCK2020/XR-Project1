using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownSimple : MonoBehaviour
{
    [Header("Bind in Inspector")]
    public TMP_Text text;          // 拖入 Text_Countdown
    [Header("Timer")]
    public int startSeconds = 180; // 3 分钟
    private float t;
    private int last = -1;

    void Start()
    {
        t = Mathf.Max(0, startSeconds);
        UpdateText();
    }

    void Update()
    {
        if (t <= 0) return;
        t -= Time.deltaTime;
        if (t < 0) t = 0;

        int whole = Mathf.CeilToInt(t);
        if (whole != last)
        {
            last = whole;
            UpdateText();
        }
    }

    void UpdateText()
    {
        int whole = Mathf.CeilToInt(t);
        int mm = whole / 60;
        int ss = whole % 60;
        if (text) text.text = $"{mm:00}:{ss:00}";
    }

    // 可选：其他脚本可调用
    public void Restart(int seconds)
    {
        startSeconds = seconds;
        t = Mathf.Max(0, seconds);
        last = -1;
        UpdateText();
    }
}