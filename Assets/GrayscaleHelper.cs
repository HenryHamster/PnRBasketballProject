using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayscaleHelper : MonoBehaviour
{
    public static bool isOffensiveGrayscale=false;
    public static bool isDefensiveGrayscale=false;
    public bool isOffensiveGrayscaleHelper;
    private bool lastOffensiveStatus;
    private bool lastDefensiveStatus;
    public bool isDefensiveGrayscaleHelper;
    public bool isOffensive;
    private Renderer rend;
    public Texture baseTexture;
    public Texture grayscaleTexture;
    private float baseAlpha=0.5f;
    private float grayscaleAlpha=0.1f;
    private void Awake()
    {
        isOffensiveGrayscaleHelper = isOffensiveGrayscale;
        lastOffensiveStatus = isOffensiveGrayscale;
        isDefensiveGrayscaleHelper = isDefensiveGrayscale;
        lastDefensiveStatus = isDefensiveGrayscale;
        rend = GetComponent<Renderer>();
    }
    private void Update()
    {
        if (isOffensiveGrayscaleHelper != isOffensiveGrayscale&&lastOffensiveStatus==isOffensiveGrayscale) { isOffensiveGrayscale = isOffensiveGrayscaleHelper;lastOffensiveStatus = isOffensiveGrayscaleHelper; }
        else if (isOffensiveGrayscaleHelper != isOffensiveGrayscale && lastOffensiveStatus != isOffensiveGrayscale) {  isOffensiveGrayscaleHelper=isOffensiveGrayscale; lastOffensiveStatus = isOffensiveGrayscale; }

        if (isDefensiveGrayscaleHelper != isDefensiveGrayscale && lastDefensiveStatus == isDefensiveGrayscale) { isDefensiveGrayscale = isDefensiveGrayscaleHelper; lastDefensiveStatus = isDefensiveGrayscaleHelper; }
        else if (isDefensiveGrayscaleHelper != isDefensiveGrayscale && lastDefensiveStatus != isDefensiveGrayscale) { isDefensiveGrayscaleHelper = isDefensiveGrayscale; lastDefensiveStatus = isDefensiveGrayscale; }
        
        
        rend.material.SetTexture("_BaseMap", isOffensive ? (isOffensiveGrayscale ? grayscaleTexture : baseTexture) : (isDefensiveGrayscale ? grayscaleTexture : baseTexture));
        Color color = rend.material.GetColor("_BaseColor");

        // Modify the alpha value to set transparency
        color.a = (isOffensive ? (isOffensiveGrayscale ? grayscaleAlpha : baseAlpha) : (isDefensiveGrayscale ? grayscaleAlpha : baseAlpha));

        // Apply the new color back to the material
        rend.material.SetColor("_BaseColor", color);
    }
}
