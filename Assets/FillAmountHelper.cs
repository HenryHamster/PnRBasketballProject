using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillAmountHelper : MonoBehaviour
{
    public Image reference;
    public Image target;
    

    // Update is called once per frame
    void Update()
    {
        target.fillAmount = reference.fillAmount;    
    }
}
