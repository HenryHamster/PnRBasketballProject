using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BillBoard : MonoBehaviour
{
    private Transform mainCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        // 取得主攝影機的 Transform
        mainCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 讓物體面向鏡頭
        transform.LookAt(mainCameraTransform);

        // 取得攝影機到物體的向量
        Vector3 cameraToTarget = transform.position - mainCameraTransform.position;

        // 將物體的前方（Z軸）設定為攝影機到物體的反向向量
        transform.forward = -cameraToTarget.normalized;
    }
}

