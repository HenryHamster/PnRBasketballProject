using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayPauseButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    private bool isGameRunning = false;

    void Start()
    {
        Time.timeScale = 0f;

    }
    public void ToggleGameRunning()
    {
        isGameRunning = !isGameRunning;

        if (isGameRunning)
        {
            // 遊戲開始運行
            buttonText.text = "Pause";
            Time.timeScale = 1f;
            // 在這裡添加開始運行的邏輯
        }
        else
        {
            // 遊戲暫停
            buttonText.text = "Play";
            Time.timeScale = 0f;
            // 在這裡添加暫停運行的邏輯
        }
    }
}
