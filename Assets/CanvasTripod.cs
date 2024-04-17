using UnityEngine;
using System.Collections;

public class CanvasTripod : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }
    void Update()
    {
        Camera camera = Camera.main;

        transform.LookAt(transform.position + camera.transform.rotation * Vector3.back, camera.transform.rotation * Vector3.up);

    }
}