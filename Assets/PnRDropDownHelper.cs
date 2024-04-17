using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnRDropDownHelper : MonoBehaviour
{
    public void OnChangedScene(int scene)
    {
        DataInterpreter.instance.usedDataIndex = scene;
    }
}
