using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPositionHelper : MonoBehaviour
{
    public static BallPositionHelper instance;
    [SerializeField]private OPlayerController opc;
    public bool passingBall;
    private void Awake()
    {
        if(!passingBall)opc = transform.parent.GetComponent<OPlayerController>();
        if (!passingBall) instance = this;
    }
    private void Update()
    {
        if (passingBall||opc.isHoldingBall) { instance = this; }
    }
    public void OnBounceFloor()
    {

    }
}
