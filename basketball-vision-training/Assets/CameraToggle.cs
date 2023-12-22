using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public Camera minimapCamera;
    public void UpdateCameraStatus(bool value)
    {
        minimapCamera.gameObject.SetActive(value);
    }
}
