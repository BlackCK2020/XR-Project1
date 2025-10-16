using UnityEngine; // 引入 Unity 核心功能
using UnityEngine.UI; // 引入 UI 相关功能，用于可选的按钮文字变化

public class LightController : MonoBehaviour
{
    // public 变量会在 Inspector 面板中显示，方便我们拖入对象
    // 这里声明了两盏灯，我们稍后会把场景中的灯拖到这里
    public Light directionalLight1;
    public Light directionalLight2;

    // 这个变量用来追踪当前灯的开关状态
    // private 表示它只能在这个脚本内部访问
    // 初始设置为 false，表示灯一开始是关的，第一次点击会打开
    private bool lightsOn = false;

    // 这是一个公共方法，按钮点击时会调用它
    public void ToggleLights()
    {
        // 切换灯的状态：如果 lightsOn 是 true，就变成 false；如果是 false，就变成 true
        lightsOn = !lightsOn;

        // 根据 lightsOn 的新状态，同时设置两盏灯的 enabled 属性
        // enabled 为 true 表示灯亮，为 false 表示灯灭
        directionalLight1.enabled = lightsOn;
        directionalLight2.enabled = lightsOn;

        // 在 Unity 的 Console 窗口中打印日志，方便调试
        Debug.Log("Lights are now " + (lightsOn ? "ON" : "OFF"));
    }
}
