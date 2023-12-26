using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICircleChart : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI percentageText;
    [SerializeField] private Image percentageBar;
    [SerializeField,Range(0f,1f)] public float percent;
    private void OnValidate()
    {
        UpdatePercentage(percent);
    }
    [SerializeField] private float _percent { set { UpdatePercentage(Mathf.Clamp01(value)); } get { return percentageBar.fillAmount; } }
    public void UpdatePercentage(float val)
    {
        percent = val;
        percentageBar.fillAmount = val;
        percentageText.text = (int)(Mathf.Clamp01(val) * 100) + "%";
    }
}
