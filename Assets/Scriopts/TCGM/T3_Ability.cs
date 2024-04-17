using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class T3_Ability : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Off_Player;
    public GameObject Bar;
    public TextMeshProUGUI PlayType, FG;
    // public Image panelImage;

    void Start()
    {
        PlayType.text = "C&S";
        PlayType.color = Color.black;
        FG.text = "FG: 38%";
        FG.color = Color.black;
        Bar.gameObject.SetActive(true);

    }

}
