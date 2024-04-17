using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPlayerController : MonoBehaviour
{
    private string playerName;
    private int playerID;
    private TrajectoryManager TrajectoryManager;
    private Animator Animator;

    [Header("Animation Values")]
    private Vector3[] lastFramePos=new Vector3[10];
    private float minSqrMagnitude = 0.01f;
    // private string Role
    // 感覺這裡會需要加入角色設定
    private float lastFrameDist = 0;

    public bool isHoldingBall = false;
    public bool lastFrameStatus = false;
    public GameObject ballGameObject;
    public GameObject playerHighlight;
    public LineRenderer lr;
    private int pastIndex;
    private int pastFrameIndex;


    private Vector3[] _trajectoryPositions;
    private List<Vector3> currentTrajectoryPositions;
    private const int trajectoryLineLength = 48;
    // Start is called before the first frame update
    void Start()
    {
        TrajectoryManager = GameObject.FindObjectOfType<TrajectoryManager>();
        playerName = gameObject.name;
        playerID = int.Parse(playerName.Replace("O", ""));
        Animator = gameObject.GetComponent<Animator>();
        ballGameObject.SetActive(isHoldingBall);
        playerHighlight.SetActive(isHoldingBall);
        pastIndex = -1;
        pastFrameIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (DataInterpreter.instance.usedDataIndex != pastIndex) { SetLineRenderer(); pastIndex = DataInterpreter.instance.usedDataIndex; }
        if (DataInterpreter.instance.frameCount != pastFrameIndex) { FrameUpdate();pastFrameIndex = DataInterpreter.instance.frameCount; }
        SetAnimationSpeed();
        for(int i = 0; i <9; i++)
        {
            lastFramePos[i] = lastFramePos[i + 1];
        }
        lastFramePos[9] = transform.position;
        
        if (lastFrameStatus != isHoldingBall) { playerHighlight.SetActive(isHoldingBall); ballGameObject.SetActive(isHoldingBall); lastFrameStatus = isHoldingBall; }
    }
    private void LateUpdate()
    {
        float sqrDist = (lastFramePos[0] - transform.position).magnitude;
        if (sqrDist == float.NaN) sqrDist = 0;
        sqrDist /= 4;
        Animator.SetFloat("_move", Mathf.Clamp(Mathf.MoveTowards(lastFrameDist, sqrDist, 5*Time.deltaTime) / Time.deltaTime, 0, 100)); ;
        
        Animator.SetFloat("_move", Mathf.Clamp(Mathf.MoveTowards(lastFrameDist, sqrDist, 5 * Time.deltaTime) / Time.deltaTime, 0, 100));
        if (isHoldingBall) Animator.SetFloat("_move", 2);
        lastFrameDist = sqrDist;
    }

    private void SetAnimationSpeed()
    {
        
        float sqrDist = (lastFramePos[0] - transform.position).sqrMagnitude;
        
        Debug.Log("distSqr: " + sqrDist);
        if (sqrDist == float.NaN) sqrDist = 0;
        sqrDist /= 4;
        if ((sqrDist > 1f && sqrDist / Time.deltaTime > 1f) || isHoldingBall) { Debug.Log("Option A " + (transform.position - lastFramePos[0])) ; transform.forward=(transform.position - lastFramePos[0]); }
        else { transform.forward = new Vector3(BallPositionHelper.instance.transform.position.x, transform.position.y, BallPositionHelper.instance.transform.position.z) - transform.position; Debug.Log("Option B"); }
        float angle = Vector3.SignedAngle(transform.position, BallPositionHelper.instance.transform.position, Vector3.up);
        int dir = -1;
        if (angle < -150) dir = 3;
        else if (angle < -90) dir = 2;
        else if (angle < -30) dir = 1;
        else if (angle < 30) dir = 0;
        else if (angle < 90) dir = 5;
        else if (angle < 150) dir = 4;
        else dir = 3;
        Animator.SetInteger("_direction", dir);
        //(sqrDist > minSqrMagnitude * Time.deltaTime) ? 2 : 0);
        Animator.speed = 1;//sqrDist > minSqrMagnitude*Time.deltaTime ? Mathf.Clamp(sqrDist *400, 0, 1) : 0;
    }

    public void Init_Player()
    {
        //Animator.SetFloat("_move", 0.0f);
        for(int i=0;i<10;i++)lastFramePos[i]=transform.position;
    }

    public void MoveOn_NextPos(int questionID, int stepID)
    {
        Vector2 prepos, pos;


        pos = TrajectoryManager.GetPosition_Defender(questionID, stepID, playerID - 1);

        if (stepID != 0)
        {
            prepos = TrajectoryManager.GetPosition_Defender(questionID, stepID - 1, playerID - 1);
       //     Control_Animation(prepos, pos);
        }

        gameObject.transform.LookAt(new Vector3(pos[0], 0, pos[1]));
        gameObject.transform.position = new Vector3(pos[0], 0, pos[1]);
    }
    public void SetLineRenderer()
    {
        if (lr == null) return;
        PlayerTransform selfPt=null;
        foreach(PlayerTransform pt in DataInterpreter.instance.players)
        {
            if (pt.id == playerID)
            {
                selfPt = pt;
                break;
            }
        }
        Vector3[] trajectoryPositions = new Vector3[selfPt.framePositions.Count];
        Debug.Log("TP: Count: " + selfPt.framePositions.Count+ " "+trajectoryPositions.Length);
        int index = 0;
        foreach(FrameData fd in selfPt.framePositions)
        {
            Debug.Log("TP: " + index + " -> " + DataInterpreter.GetPositionFromFrameData(fd));
            trajectoryPositions[index] = DataInterpreter.GetPositionFromFrameData(fd) + Vector3.up * 0.05f ;
            index++;
        }
        PrintVector3Array(trajectoryPositions);
        lr.positionCount = selfPt.framePositions.Count;
        lr.SetPositions(trajectoryPositions);
    }
    void PrintVector3Array(Vector3[] vectors)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (Vector3 v in vectors)
        {
            sb.Append(v.ToString()).Append(", ");
        }
        if (sb.Length > 2) sb.Length -= 2; // Remove the last comma and space
        Debug.Log("TP: "+sb.ToString());
    }
    public void FrameUpdate()
    {

    }
    /*
    private void Control_Animation(Vector2 prepos, Vector2 pos)
    {
        if (Mathf.Abs(prepos[0] - pos[0]) < 0.01f && Mathf.Abs(prepos[1] - pos[1]) < 0.01f)
            Animator.SetFloat("_move", 0.0f);
        else
            Animator.SetFloat("_move", 2.0f);
    }*/
}
