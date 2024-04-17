using UnityEngine;
using UnityEngine.UI;

public class panelgradient : MonoBehaviour
{
    public Gradient gradient;

    private Image panelImage;

    private void Start()
    {
        // 获取面板的 Image 组件
        panelImage = GetComponent<Image>();

        // 创建渐变色键
        // GradientColorKey[] colorKeys = new GradientColorKey[2];
        // colorKeys[0] = new GradientColorKey(Color.blue, 0f);
        // colorKeys[1] = new GradientColorKey(Color.black, 1f);

        // // 创建渐变透明度键
        // GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        // alphaKeys[0] = new GradientAlphaKey(1f, 0f);
        // alphaKeys[1] = new GradientAlphaKey(1f, 1f);

        // // 设置渐变色和透明度键
        // gradient.SetKeys(colorKeys, alphaKeys);

        // // 设置面板的背景色为渐变的起始颜色
        // panelImage.color = gradient.Evaluate(0f);
        // panelImage = GetComponent<Image>();

        // 设置面板的背景色为渐变的起始颜色
        panelImage.color = gradient.Evaluate(0f);
    }

    private void Update()
    {

    }
}
