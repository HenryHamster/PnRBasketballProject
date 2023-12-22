using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPlayerController : MonoBehaviour
{
    private string playerName;
    private int playerID;
    private TrajectoryManager TrajectoryManager;
    private Animator Animator;
    private GameObject ballObject; // 球的物體
    private GameObject circleObject; // 圓圈的物體
    private bool hasBall = false; // 是否持球

    public enum PlayerRole
    {
        Holder,
        Protector,
        Other
    }

    public PlayerRole role;

    public Color holderColor = Color.red;
    public Color protectorColor = Color.green;
    public Color otherColor = Color.magenta;

    public float circleRadius = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        TrajectoryManager = GameObject.FindObjectOfType<TrajectoryManager>();
        playerName = gameObject.name;
        playerID = int.Parse(playerName.Replace("O", ""));
        Animator = gameObject.GetComponent<Animator>();

        // 創建圓圈物體
        circleObject = new GameObject();
        circleObject.transform.parent = gameObject.transform;
        circleObject.transform.localPosition = new Vector3(0, 0.1f, 0);
        var circleRenderer = circleObject.AddComponent<SpriteRenderer>();
        circleRenderer.sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 更新圓圈顏色
        if (role == PlayerRole.Holder)
        {
            circleObject.GetComponent<SpriteRenderer>().color = holderColor;
        }
        else if (role == PlayerRole.Protector)
        {
            circleObject.GetComponent<SpriteRenderer>().color = protectorColor;
        }
        else
        {
            circleObject.GetComponent<SpriteRenderer>().color = otherColor;
        }

        // 更新圓圈大小
        circleObject.transform.localScale = new Vector3(circleRadius, circleRadius, 1.0f);

        // 更新持球者的球的位置
        if (hasBall)
        {
            ballObject.transform.position = gameObject.transform.position + new Vector3(0, 0.5f, 0);
        }
    }

    public void Init_Player()
    {
        Animator.SetFloat("_move", 0.0f);
    }

    public void MoveOn_NextPos(int questionID, int stepID)
    {
        Vector2 prepos, pos;

        pos = TrajectoryManager.GetPosition_Defender(questionID, stepID, playerID - 1);

        if (stepID != 0)
        {
            prepos = TrajectoryManager.GetPosition_Defender(questionID, stepID - 1, playerID - 1);
            Control_Animation(prepos, pos);
        }

        gameObject.transform.LookAt(new Vector3(pos[0], 0, pos[1]));
        gameObject.transform.position = new Vector3(pos[0], 0, pos[1]);
    }

    private void Control_Animation(Vector2 prepos, Vector2 pos)
    {
        if (Mathf.Abs(prepos[0] - pos[0]) < 0.01f && Mathf.Abs(prepos[1] - pos[1]) < 0.01f)
            Animator.SetFloat("_move", 0.0f);
        else
            Animator.SetFloat("_move", 2.0f);
    }

    // 設置是否持球
    public void SetHasBall(bool value)
    {
        hasBall = value;
        if (hasBall)
        {
            // 創建球的物體
            ballObject = new GameObject();
            ballObject.transform.parent = gameObject.transform;
            ballObject.transform.localPosition = new Vector3(0, 0.5f, 0);
            var ballRenderer = ballObject.AddComponent<SpriteRenderer>();
            ballRenderer.sprite = Resources.Load<Sprite>("Ball");
            ballRenderer.sortingOrder = 2;
        }
        else
        {
            Destroy(ballObject);
        }
    }
}