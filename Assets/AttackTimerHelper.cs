using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackTimerHelper : MonoBehaviour
{
    public static AttackTimerHelper instance;
    public TextMeshProUGUI attackTimerText;
    public float startingTime;
    private void Awake()
    {
        instance = this;
        startingTime = Time.time;
    }
    public void ResetTime()
    {
        startingTime = Time.time;
    }
    public void Update()
    {
        attackTimerText.text = (Mathf.Clamp(24 - Mathf.FloorToInt((Time.time - startingTime)*10)/10f,0,24)).ToString();
    }
}
