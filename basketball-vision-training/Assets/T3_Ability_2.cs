using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class T3_Ability_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bar;
    public TextMeshProUGUI PlayType, FG;
    // public Image panelImage;

    void Start()
    {
        PlayType.text = "Cut";
        PlayType.color = Color.black;
        FG.text = "Cut: 71%";
        FG.color = Color.black;
        Bar.gameObject.SetActive(true);

    }

}
