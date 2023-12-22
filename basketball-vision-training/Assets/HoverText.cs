using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI hover_Text;

    private void Start()
    {
        // 將 Text 隱藏，初始狀態為不可見
        hover_Text.gameObject.SetActive(false);
    }

    // 當滑鼠進入按鈕時觸發
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 顯示 Text
        hover_Text.gameObject.SetActive(true);
    }

    // 當滑鼠離開按鈕時觸發
    public void OnPointerExit(PointerEventData eventData)
    {
        // 隱藏 Text
        hover_Text.gameObject.SetActive(false);
    }
}
