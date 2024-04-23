using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackSpeedHelper : MonoBehaviour
{

    public void SetFPSMultiplier(float value)
    {
        DataInterpreter.instance.UpdateFPSMultiplier(value/25);
    }
}
