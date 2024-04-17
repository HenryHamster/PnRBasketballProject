// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;


// public class DisplayAbility : MonoBehaviour
// {
//     //public TextMeshProUGUI buttonText;
//     public GameObject Image;
//     // private bool isDisplay = false;
//     // Start is called before the first frame update
//     void Start()
//     {
//         Image.SetActive(false);
//     }

//     // Update is called once per frame
//     public void OnBtnClick()
//     {
//         // isDisplay = !isDisplay;
//         Image.SetActive(true);
//         DisplayAbility[] allButtons = FindObjectsOfType<DisplayAbility>();
//         foreach (DisplayAbility button in allButtons)
//         {
//             if (button != this)
//             {
//                 button.Image.SetActive(false);
//             }
//         }
//         // if (isDisplay)
//         // {
//         //     // 遊戲開始運行
//         //     //buttonText.text = "";
//         //     Image.SetActive(true);

//         //     // 在這裡添加開始運行的邏輯
//         // }
//         // else
//         // {
//         //     // 遊戲暫停
//         //     //buttonText.text = "Play";
//         //     Image.SetActive(false);

//         //     Time.timeScale = 0f;
//         //     // 在這裡添加暫停運行的邏輯
//         // }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayAbility : MonoBehaviour
{
    public GameObject Image;
    private Image selfImage;
    public GameObject Panel;
    public TextMeshProUGUI panelText;
    public Button abilityBtn;
    private bool isPanelVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        selfImage = GetComponent<Image>();
        Image.SetActive(false);
        Panel.SetActive(false);
        panelText.text = "";
        abilityBtn.onClick.AddListener(() => OnBtnClick(abilityBtn.name));
    }

    // Update is called once per frame
    public void OnBtnClick(string buttonName)
    {
        if (Image.activeSelf && isPanelVisible)
        {
            selfImage.color = Color.white;
            // 如果 Image 和 Panel 都是顯示的，則隱藏它們
            Image.SetActive(false);
            Panel.SetActive(false);
            panelText.text = "";
            isPanelVisible = false;
            Debug.Log("Image active state: " + Image.activeSelf+" from go: "+name);

        }
        else
        {
            // 如果 Image 和 Panel 都是隱藏的，則顯示它們

            // 先隱藏所有其他的 Image
            DisplayAbility[] allButtons = FindObjectsOfType<DisplayAbility>();
            foreach (DisplayAbility button in allButtons)
            {
                if (button != this)
                {
                    button.Image.SetActive(false);
                    button.Panel.SetActive(false);
                    button.panelText.text = "";
                    button.isPanelVisible = false;
                    button.selfImage.color = Color.white;
                }
            }
            selfImage.color = new Color(1,0.8f,0.8f,1);

            // 再顯示目前的 Image 和 Panel
            Image.SetActive(true);
            Panel.SetActive(true);
            Debug.Log("Image active state: "+Image.activeSelf);
            // 根據按鈕的名稱設置相應的 panelText.text
            if (buttonName == "Handler_Btn")
            {
                panelText.text = "Handler Ability";
                isPanelVisible = true;
            }
            else if (buttonName == "Rollman_Btn")
            {
                panelText.text = "RollMan Ability";
                isPanelVisible = true;
            }
            else if (buttonName == "OffBall_Btn")
            {
                panelText.text = "OffBall Ability";
                isPanelVisible = true;
            }
            Debug.Log("Image active state: " + Image.activeSelf + " from go: " + name);


            // 可以繼續添加其他按鈕的處理
        }
    }

    public void SetDisplayValue(bool val)
    {
        selfImage.color = val ? new Color(1, 0.8f, 0.8f) : Color.white;
    }
}