using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTimerManager : MonoBehaviour
{
    void Update()
    {
        DataInterpreter.instance.UpdatePosition();
    }
}
