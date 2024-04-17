using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPnRDisplayHelper : MonoBehaviour
{
    public Transform startPlayer;
    public Transform blockingPlayer;
    public Transform helpingPlayer;
    public Transform lineConnector;
    public Transform frontBlocker;
    public float blockingPlayerOffset;
    private float yPos;
    private void Update()
    {
        if (startPlayer == null || blockingPlayer == null || helpingPlayer == null) return;
        float dist = Vector3.Distance(startPlayer.position, blockingPlayer.position);
        if (dist < blockingPlayerOffset||dist>4) { yPos = -10; }
        else { yPos = 0; }
        transform.forward = blockingPlayer.position - startPlayer.position;
        Vector3 target = Vector3.MoveTowards(startPlayer.position,blockingPlayer.position,(dist)/2-blockingPlayerOffset);//Set starting position at 
        transform.position = new Vector3(target.x, yPos, target.z);
        lineConnector.transform.localScale = new Vector3(lineConnector.transform.localScale.x, lineConnector.transform.localScale.y, ((dist) / 2 - blockingPlayerOffset)*2);
        frontBlocker.transform.localPosition = Vector3.forward * ((dist) / 2 - blockingPlayerOffset);
        frontBlocker.transform.localScale = new Vector3(
            Mathf.Clamp(dist,1,5)*
            Mathf.Sin(Mathf.Deg2Rad*(Vector3.SignedAngle(blockingPlayer.position-startPlayer.position,helpingPlayer.position-startPlayer.position,Vector3.up)))
            , frontBlocker.transform.localScale.y, frontBlocker.transform.localScale.z);

    }
}
