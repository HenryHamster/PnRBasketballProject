using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public Camera minimapCamera;
    public Camera original;
    public static bool inMinimap;
    private void Awake()
    {
        original = Camera.main;
    }
    public void UpdateCameraStatus(bool value)
    {
        original.gameObject.SetActive(!value);
        minimapCamera.gameObject.SetActive(value);
        inMinimap = value;
    }
}
