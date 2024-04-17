using UnityEngine;
using UnityEngine.UI;
public class ShowMenu : MonoBehaviour
{
    public CanvasGroupManager Panel;
    public CanvasGroupManager Panel2;

    public Button Menu;
    // private PnRSpace showAreaScript;

    public bool ResetSceneValues = false;
    private void Start()
    {
        if (ResetSceneValues)
        {
            Menu.onClick.AddListener(ToggleObjectVisibility);
            Time.timeScale = 0f;
        }
        // Legend.SetActive(false);

    }

    private void ToggleObjectVisibility()
    {
        Panel.ToggleState();
        Panel2.ToggleState();
    }
}
