using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameIdUpdater : MonoBehaviour
{
    [SerializeField] private int _startFrame;
    [SerializeField] private int _endFrame;
    public GameObject obj;
    public int UsedScene;
    // Update is called once per frame
    void Update()
    {
        obj.SetActive((UsedScene==DataInterpreter.instance.usedDataIndex?DataInterpreter.instance.frameCount >= _startFrame && DataInterpreter.instance.frameCount <= _endFrame:false));
    }
}
