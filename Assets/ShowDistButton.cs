using UnityEngine;
using UnityEngine.UI;


public class ShowDistButton : MonoBehaviour
{
    public GameObject Player;
    public Toggle PnR_Area_Toggle;
    public Toggle PnR_Dist_Toggle;
    private DistCalculate showDistScript;

    private void Start()
    {
        showDistScript = Player.GetComponent<DistCalculate>();
    }

    public void OnButtonClick()
    {
        if (!showDistScript.enabled)
        {
            showDistScript.enabled = true;
            Debug.Log("ShowDist script enabled");
        }
        else
        {
            showDistScript.enabled = false;
            Debug.Log("Show Dist script disabled");
        }

        // PnR_Area_Toggle.interactable = false;
        // PnR_Dist_Toggle.interactable = false;
    }
}
