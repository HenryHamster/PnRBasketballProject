using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateCanvasSizes : MonoBehaviour

{
    public List<CanvasScaler> cs;
    public Slider scaleSlider;
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            UpdateScale();
        }
    }
    public void UpdateScale()
    {
            foreach (CanvasScaler css in cs)
            {
                css.referenceResolution = new Vector2(scaleSlider.value, scaleSlider.value);
            }
    }
}
