using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TendencyBar : MonoBehaviour
{
    [SerializeField] private RectTransform _driveFill;//left
    [SerializeField] private RectTransform _driveIcon;
    [SerializeField] private RectTransform _passFill;//center
    [SerializeField] private RectTransform _passIcon;
    [SerializeField] private RectTransform _shootFill;//right
    [SerializeField] private RectTransform _shootIcon;
    private float maxIconScale=1.5f;
    private float maxFill = 420;

    //Using sqrt(x) as scale
    public float driveWeight;
    public float passWeight;
    public float shootWeight;
    // Update is called once per frame
    void Update()
    {
        float totalWeight = driveWeight + passWeight + shootWeight;
        _driveFill.offsetMax = new Vector2(-(20 + maxFill *( 1-driveWeight / totalWeight)),_driveFill.offsetMax.y);

        _passFill.offsetMin =new Vector2(460-(20+maxFill * (1 - driveWeight / totalWeight)), _passFill.offsetMin.y);
        _passFill.offsetMax = new Vector2(-460+(20+maxFill * (1 -  shootWeight/ totalWeight)), _passFill.offsetMax.y);

        _shootFill.offsetMin = new Vector2(20 + maxFill * (1 - shootWeight / totalWeight), _shootFill.offsetMin.y);
        float sqrtTotalWeight = Mathf.Sqrt(totalWeight);
        _driveIcon.localScale = Vector3.one*maxIconScale * Mathf.Sqrt(driveWeight) / sqrtTotalWeight;
        _passIcon.localScale = Vector3.one * maxIconScale * Mathf.Sqrt(passWeight) / sqrtTotalWeight;
        _shootIcon.localScale = Vector3.one * maxIconScale * Mathf.Sqrt(shootWeight) / sqrtTotalWeight;

    }
}
