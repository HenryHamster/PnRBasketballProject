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
    private Vector3 lastFramePos;
    private float minSqrMagnitude = 0.01f;
    // private string Role
    // 感覺這裡會需要加入角色設定


    // Start is called before the first frame update
    void Start()
    {
        TrajectoryManager = GameObject.FindObjectOfType<TrajectoryManager>();
        playerName = gameObject.name;
        playerID = int.Parse(playerName.Replace("O", ""));
        Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimationSpeed();

    }
    private void LateUpdate()
    {
        lastFramePos = transform.position;
    }

    private void SetAnimationSpeed()
    {
        float sqrDist = (lastFramePos - transform.position).sqrMagnitude;
        Debug.Log("distSqr: " + sqrDist);

        Animator.SetFloat("_move", (sqrDist > minSqrMagnitude * Time.deltaTime) ? 2 : 0);
        Animator.speed = sqrDist > minSqrMagnitude*Time.deltaTime ? Mathf.Clamp(sqrDist *400, 0, 1) : 0;
    }

    public void Init_Player()
    {
        Animator.SetFloat("_move", 0.0f);
        lastFramePos = transform.position;
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
    /*
    private void Control_Animation(Vector2 prepos, Vector2 pos)
    {
        if (Mathf.Abs(prepos[0] - pos[0]) < 0.01f && Mathf.Abs(prepos[1] - pos[1]) < 0.01f)
            Animator.SetFloat("_move", 0.0f);
        else
            Animator.SetFloat("_move", 2.0f);
    }*/
}
