using UnityEngine;
using UnityEngine.UI;
public class ShowAreaButton : MonoBehaviour
{
    public GameObject Player;
    public Toggle PnR_Dist_Toggle;
    private PnRSpace showAreaScript;

    private void Start()
    {
        showAreaScript = Player.GetComponent<PnRSpace>();
    }

    public void OnToggleClick()
    {
        if (!showAreaScript.enabled)
        {
            showAreaScript.enabled = true;
            Debug.Log("ShowArea script enabled");
        }
        else
        {
            showAreaScript.enabled = false;
            Debug.Log("ShowArea script disable");
        }

        // PnR_Dist_Toggle.interactable = false;
    }
}
