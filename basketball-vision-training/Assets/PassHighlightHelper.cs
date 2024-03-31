using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassHighlightHelper : MonoBehaviour
{
    public List<Transform> defenders;
    public float safeDistance = 3f;
    public GameObject passHighlight;
    public OPlayerController opc;
    private void Awake()
    {
        opc = transform.parent.GetComponent<OPlayerController>();
        passHighlight = transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        passHighlight.SetActive(!(opc.isHoldingBall)&&!IsObstacleNearLine(passHighlight.transform.position, BallPositionHelper.instance.transform.position, defenders, safeDistance));
    }
    public bool IsObstacleNearLine(Vector3 start, Vector3 end, List<Transform> obstacles, float thresholdDistance)
    {
        foreach (Transform obstacle in obstacles)
        {
            float distance = DistanceFromPointToLineSegment(new Vector3(start.x,0,start.z), new Vector3(end.x, 0, end.z), new Vector3(obstacle.position.x, 0, obstacle.position.z));
            if (distance <= thresholdDistance)
            {
                return true; // An obstacle is within the threshold distance
            }
        }

        return false; // No obstacles are within the threshold distance
    }

    // Calculates the shortest distance from a point to a line segment
    private float DistanceFromPointToLineSegment(Vector3 start, Vector3 end, Vector3 point)
    {
        Vector3 lineDirection = end - start;
        float lineLength = lineDirection.magnitude;
        lineDirection.Normalize();

        float projectLength = Vector3.Dot(point - start, lineDirection);
        if (projectLength <= 0)
        {
            // Point projects before the start of the line segment
            return 100f;//(point - start).magnitude;
        }
        else if (projectLength >= lineLength)
        {
            // Point projects after the end of the line segment
            return 100f;//(point - end).magnitude;
        }
        else
        {
            // Point projects onto the line segment
            Vector3 projection = start + lineDirection * projectLength;
            return (point - projection).magnitude;
        }
    }
}
