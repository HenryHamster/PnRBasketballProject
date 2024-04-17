using UnityEngine;
using UnityEngine.UI;
public class InfoBtn_Display : MonoBehaviour
{
    public GameObject InfoBtn;
    public Button Ability;
    // private PnRSpace showAreaScript;

    private bool isObjectVisible = false;

    private void Start()
    {
        Ability.onClick.AddListener(ToggleObjectVisibility);
        InfoBtn.SetActive(false);
        // Time.timeScale = 0f;
        // Legend.SetActive(false);
    }

    private void ToggleObjectVisibility()
    {
        isObjectVisible = !isObjectVisible;
        InfoBtn.SetActive(isObjectVisible);
    }
}
