using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class T2_Ability_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject T2;
    public GameObject Bar;
    public TextMeshProUGUI PlayType, FG;
    //public Image panelImage;
    void Start()
    {
        PlayType.text = "Cut";
        FG.text = "FG: 53% ";
        PlayType.color = Color.black;
        FG.color = Color.black;
        Bar.gameObject.SetActive(true);
    }
}
