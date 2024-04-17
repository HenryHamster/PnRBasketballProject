using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BallHandlerTendencyDisplay : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    private Image image;
    public GameObject Tendency;
    private bool isDisplay = false;
    void Start()
    {
        image = GetComponent<Image>();
        //Tendency.SetActive(false);
    }

    // Update is called once per frame
    public void Btn_TendencyDisplay()
    {
        isDisplay = !isDisplay;
        if (isDisplay)
        {
            Tendency.SetActive(true);
            image.color = Color.gray;
            // buttonText.text = "Tendency (Hide)";
        }
        else
        {
            //Tendency.SetActive(false);

            image.color = Color.white;
            // buttonText.text = "Offense Tendency (Show)";
        }
    }
}
