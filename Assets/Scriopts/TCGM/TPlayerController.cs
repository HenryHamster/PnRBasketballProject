using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TPlayerController : MonoBehaviour
{
    private string playerName;
    private int playerID;
    private TrajectoryManager TrajectoryManager;
    private Animator Animator;
    private Vector3 lastFramePos;
    private float minSqrMagnitude = 0.01f;

    private List<float> PlayersPos = new List<float>();
    private Vector3 prevPosition;
    public Image defenderFillCircle;
    public LineRenderer lr;

    private int pastIndex;
    private int pastFrameIndex;

    public bool isHoldingBall = false;

    public Color overrideColor = new Color(0, 0, 0, 1);
    private static Color tLineColor = new Color(128f/255, 1, 128f / 255,0.3f);


    public SkinnedMeshRenderer smr;
    // Start is called before the first frame update
    void Start()
    {
        TrajectoryManager = GameObject.FindObjectOfType<TrajectoryManager>();
        playerName = gameObject.name;
        playerID = int.Parse(playerName.Replace("T", ""))+5; //TODO very bad temp system
        Animator = gameObject.GetComponent<Animator>();

        pastIndex = -1;
        pastFrameIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (DataInterpreter.instance.usedDataIndex != pastIndex) { SetLineRenderer(); pastIndex = DataInterpreter.instance.usedDataIndex; }

        SetAnimationSpeed();
        PlayerTransform target=DataInterpreter.instance.GetClosestOffense(transform, out float dist);
        Debug.Log("Closest target: " + target.id + " for " + name);
        float distFromBall = Vector2.Distance(transform.position, BallPositionHelper.instance.transform.position);
        Vector3 targetPos2 = Vector3.MoveTowards(target.transform.position, BallPositionHelper.instance.transform.position, 1.5f);
        Vector3 targetPos = new Vector3(BallPositionHelper.instance.transform.position.x, transform.position.y, BallPositionHelper.instance.transform.position.z);
        if (dist < 100&&dist>distFromBall*1.5)
        {
            Debug.Log("dist: " + dist);
            defenderFillCircle.fillAmount = (2-dist) / 4;
            transform.forward = (target.transform.position - transform.position).normalized;
            Animator.SetBool("_defending", true);
        }
        else {
            defenderFillCircle.fillAmount = (2 - distFromBall) / 4;
            transform.forward = (targetPos - transform.position).normalized;
            Animator.SetBool("_defending", true);
        }
        /*else
        {
            Animator.SetBool("_defending", false);
        }*/

        //ballGameObject.SetActive(isHoldingBall);

    }
    private void LateUpdate()
    {
        lastFramePos = transform.position;

        if(!Animator.GetBool("_defending"))gameObject.transform.LookAt(2*Vector3.Slerp(transform.position,prevPosition,0.5f));
        //gameObject.transform.LookAt(new Vector3(0, 0, -12));
        prevPosition = transform.position;
    }

    private void SetAnimationSpeed()
    {
        float sqrDist = (lastFramePos - transform.position).magnitude;
        lastFramePos = transform.position;
        Debug.Log("distSqr: " + sqrDist);

        Animator.SetFloat("_move", 2);
        //Animator.SetFloat("_move", (sqrDist > minSqrMagnitude * Time.deltaTime) ? 2 : 0);
        Animator.speed = sqrDist==0?0:Mathf.Clamp(1000*sqrDist / Time.deltaTime, 0.5f, 1);
        //Animator.speed = 1;
    }
    public void Init_Player()
    {
        Animator.SetFloat("_move", 0.0f);
    }

    public void MoveOn_NextPos(int questionID, int stepID)
    {
        Vector2 prepos, pos;
        pos = TrajectoryManager.GetPosition(questionID, stepID, playerID - 1);
        // Debug.Log(playerID);

        if (stepID != 0)
        {
            prepos = TrajectoryManager.GetPosition(questionID, stepID - 1, playerID - 1);
           // Control_Animation(prepos, pos);
        }

        gameObject.transform.position = new Vector3(pos[0], 0, pos[1]);
    }
    public void SetLineRenderer()
    {
        if (lr == null) return;
        lr.material.color = overrideColor.Equals(Color.black) ? tLineColor : overrideColor;
        PlayerTransform selfPt = null;
        foreach (PlayerTransform pt in DataInterpreter.instance.players)
        {
            if (pt.id == playerID)
            {
                selfPt = pt;
                break;
            }
        }
        Vector3[] trajectoryPositions = new Vector3[selfPt.framePositions.Count];
        Debug.Log("TP: Count: " + selfPt.framePositions.Count + " " + trajectoryPositions.Length);
        int index = 0;
        foreach (FrameData fd in selfPt.framePositions)
        {
            Debug.Log("TP: " + index + " -> " + DataInterpreter.GetPositionFromFrameData(fd));
            trajectoryPositions[index] = DataInterpreter.GetPositionFromFrameData(fd) + Vector3.up * 0.05f;
            index++;
        }
        //PrintVector3Array(trajectoryPositions);
        lr.positionCount = selfPt.framePositions.Count;
        lr.SetPositions(trajectoryPositions);
    }

    /*private void Control_Animation(Vector2 prepos, Vector2 pos)
    {
        if (Mathf.Abs(prepos[0] - pos[0]) < 0.01f && Mathf.Abs(prepos[1] - pos[1]) < 0.01f)
            Animator.SetFloat("_move", 0.0f);
        else
            Animator.SetFloat("_move", 2.0f);
    }*/
}
