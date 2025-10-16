using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    [Tooltip("留空=自动抓取场景中所有 Light。若只想控制部分灯，把它们拖进来。")]
    public List<Light> targetLights = new List<Light>();

    void Awake()
    {
        if (targetLights == null || targetLights.Count == 0)
        {
#if UNITY_2020_1_OR_NEWER
            targetLights = new List<Light>(FindObjectsOfType<Light>(true)); // 包含未激活
#else
            targetLights = new List<Light>(FindObjectsOfType<Light>());
#endif
        }
    }

    public void TurnOffAll()
    {
        foreach (var l in targetLights)
            if (l) l.enabled = false;
    }

    // 可选：开灯/切换备用
    public void TurnOnAll()
    {
        foreach (var l in targetLights)
            if (l) l.enabled = true;
    }
    public void ToggleAll()
    {
        bool anyOn = targetLights.Exists(l => l && l.enabled);
        foreach (var l in targetLights)
            if (l) l.enabled = !anyOn;
    }
}