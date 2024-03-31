using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScriptSelector : MonoBehaviour
{
    public GameObject player, script;
    public TMP_Dropdown dropdown;
    private DistCalculate distScript;
    private PnRSpace areaScript;
    private GenerateTriangle triangleScript;
    private bool isSceneRunning = true; // 根據場景運行狀態設定為true或false

    // Start is called before the first frame update
    void Start()
    {
        distScript = player.GetComponent<DistCalculate>();
        areaScript = player.GetComponent<PnRSpace>();
        triangleScript = script.GetComponent<GenerateTriangle>();
        dropdown.value = 0; // 預設選項為None
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        SetDropdownInteractable(isSceneRunning); // 根據場景運行狀態設置下拉選單的互動狀態
    }

    // Update is called once per frame
    private void OnDropdownValueChanged(int value)
    {
        switch (value)
        {
            case 0: // None
                distScript.enabled = false;
                areaScript.enabled = false;
                triangleScript.gameObject.SetActive(false);
                break;
            case 1: // Show Dist
                distScript.enabled = true;
                areaScript.enabled = false;
                triangleScript.gameObject.SetActive(false);
                break;
            case 2: // Show Area
                distScript.enabled = false;
                areaScript.enabled = true;
                triangleScript.gameObject.SetActive(true);
                break;
        }
    }
    public void SetSceneRunning(bool isRunning)
    {
        isSceneRunning = isRunning;
        SetDropdownInteractable(isRunning);
    }

    private void SetDropdownInteractable(bool isInteractable)
    {
        dropdown.interactable = isInteractable;
    }
}
