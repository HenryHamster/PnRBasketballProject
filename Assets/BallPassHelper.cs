using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPassHelper : MonoBehaviour
{
    public bool isActive=false;
    private int startFrame;
    private int endFrame;
    private Vector3 startLocation;
    private Vector3 endLocation;
    public GameObject passingBall;
    Vector3 offset = new Vector3(7, 0, 13);
    // Update is called once per frame
    void Update()
    {
        passingBall.SetActive(isActive);
        if (DataInterpreter.instance.frameCount == 0) return;
        if (!isActive)
        {
            if (DataInterpreter.instance.ballHandlerIndex[DataInterpreter.instance.frameCount] == -1)
            {
                isActive = true;
                startFrame = DataInterpreter.instance.frameCount;
                startLocation = DataInterpreter.instance.players[DataInterpreter.instance.ballHandlerIndex[DataInterpreter.instance.frameCount - 1]].transform.position;
                PlayerTransform end = FindNextPlayerWithBall(out endFrame);
                if (end == null)
                {
                    endLocation = new Vector3(0, 3, -12.5f);
                    endFrame = startFrame + 12;
                }
                else
                {
                    endLocation = new Vector3(end.framePositions[endFrame].y, 0, end.framePositions[endFrame].x) / 50 * 1.5f - offset + Vector3.up * 2;
                }
            }
        }
        else
        {
            if(!(DataInterpreter.instance.ballHandlerIndex[DataInterpreter.instance.frameCount] == -1 )) { isActive = false; return; }
            passingBall.transform.position = Vector3.Lerp(startLocation, endLocation, (DataInterpreter.instance.frameCount - startFrame) / ((float)endFrame - startFrame));
        }
    }
    public PlayerTransform FindNextPlayerWithBall(out int endFrame)
    {
        endFrame = startFrame;
        for (int i = DataInterpreter.instance.frameCount; i < DataInterpreter.instance.ballHandlerIndex.Length; i++)
        {
            if (!(DataInterpreter.instance.ballHandlerIndex[i] ==-1))
            {
                endFrame = i;
                return DataInterpreter.instance.players[DataInterpreter.instance.ballHandlerIndex[i]];
            }
        }
        return null;
    }
}
