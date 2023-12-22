using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{

    public int GroundTruth;
    public int D_GroundTruth;

    private MenuManager MenuManager;
    private TrajectoryManager TrajectoryManager;
    private TimerManager TimerManager;

    public bool taskIsReady;
    public bool taskIsStart;    // true: user start
    public bool taskIsSetup;
    public bool taskIsPause;
    public int QuestionID = 0;
    public int StepID = 0;

    public int DQuestionID = 0;
    public int DStepID = 0;

    public GameObject T1, T2, T3, T4, T5, T6, O1, O2, O3, O4, O5, O6;
    public Text T1RN, T2RN, T3RN, T4RN, T5RN;
    public Text O1RN, O2RN, O3RN, O4RN, O5RN;
    public TPlayerController TC1, TC2, TC3, TC4, TC5, TC6;
    public OPlayerController OC1, OC2, OC3, OC4, OC5, OC6;

    // Add new role for PnR
    public class BallHandler : MonoBehaviour { }
    public class Screener : MonoBehaviour { }
    public class Others : MonoBehaviour { }
    public class Ball : MonoBehaviour { }


    // Add radius for each role
    private float radius1;
    private float radius2;
    private float radius3;
    private float radius4;
    private float radius5;
    private float radius6;


    // private LineRenderer lineRenderer;

    public GameObject M1, M2, M3, M4, M5;
    public SkinnedMeshRenderer meshRenderer;
    public Material TMN1, TMN2, TMN3, TMN4, TMN5, TMS;


    private List<List<string>> MDNQuestion = new List<List<string>>();
    private List<List<string>> MENQuestion = new List<List<string>>();
    private List<List<string>> MDCQuestion = new List<List<string>>();
    private List<List<string>> MECQuestion = new List<List<string>>();
    public List<string> ChangeTime = new List<string>();
    public List<string> ChangePlayer = new List<string>();

    private List<List<string>> D_MDNQuestion = new List<List<string>>();
    private List<List<string>> D_MENQuestion = new List<List<string>>();
    private List<List<string>> D_MDCQuestion = new List<List<string>>();
    private List<List<string>> D_MECQuestion = new List<List<string>>();
    public List<string> D_ChangeTime = new List<string>();
    public List<string> D_ChangePlayer = new List<string>();


    void Awake()
    {

        MenuManager = GameObject.FindObjectOfType<MenuManager>();
        TrajectoryManager = GameObject.FindObjectOfType<TrajectoryManager>();
        TimerManager = GameObject.FindObjectOfType<TimerManager>();

    }

    // Start is called before the first frame update

    void Start()
    {

        TextAsset MDNs = Resources.Load<TextAsset>("Question/MovableDisableNumberAccumulation");
        Split_Question(MDNs.text, "MDN");
        TextAsset MENs = Resources.Load<TextAsset>("Question/MovableEnableNumberAccumulation");
        Split_Question(MENs.text, "MEN");
        TextAsset MDCs = Resources.Load<TextAsset>("Question/MovableDisableColorChange");
        Split_Question(MDCs.text, "MDC");
        TextAsset MECs = Resources.Load<TextAsset>("Question/MovableEnableColorChange");
        Split_Question(MECs.text, "MEC");
        TextAsset CTs = Resources.Load<TextAsset>("Question/ChangeTime");
        Split_ChangeTimePlayer(CTs.text, "CT");
        TextAsset CPs = Resources.Load<TextAsset>("Question/ChangePlayer");
        Split_ChangeTimePlayer(CPs.text, "CP");

        TextAsset D_MDNs = Resources.Load<TextAsset>("D_Question/MovableDisableNumberAccumulation");
        Split_DQuestion(D_MDNs.text, "D_MDN");
        TextAsset D_MENs = Resources.Load<TextAsset>("D_Question/MovableEnableNumberAccumulation");
        Split_DQuestion(D_MENs.text, "D_MEN");
        TextAsset D_MDCs = Resources.Load<TextAsset>("D_Question/MovableDisableColorChange");
        Split_DQuestion(D_MDCs.text, "D_MDC");
        TextAsset D_MECs = Resources.Load<TextAsset>("D_Question/MovableEnableColorChange");
        Split_DQuestion(D_MECs.text, "D_MEC");
        TextAsset D_CTs = Resources.Load<TextAsset>("D_Question/ChangeTime");
        Split_ChangeTimePlayer(D_CTs.text, "D_CT");
        TextAsset D_CPs = Resources.Load<TextAsset>("D_Question/ChangePlayer");
        Split_ChangeTimePlayer(D_CPs.text, "D_CP");

        // radius1 = T1.transform.localScale.x * 0.8f;
        radius2 = T2.transform.localScale.x * 0.8f;
        radius3 = T3.transform.localScale.x * 0.8f;
        radius4 = T4.transform.localScale.x * 1.5f;
        radius5 = T5.transform.localScale.x * 0.8f;
        radius6 = T6.transform.localScale.x * 1f;

        T2.AddComponent<BallHandler>();
        GameObject circle2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        circle2.transform.position = T2.transform.position;
        circle2.transform.localScale = new Vector3(radius2, 0.01f, radius2);
        circle2.GetComponent<Renderer>().material.color = new Color(0.5f, 0.85f, 1f);
        circle2.transform.parent = T2.transform;

        // 將 O2 設定為 Screener 角色，並在其腳下產生一個半徑是其物體 1.5 倍大的綠色圓圈
        // T5.AddComponent<Screener>();
        // GameObject circle5 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // circle5.transform.position = T5.transform.position;
        // circle5.transform.localScale = new Vector3(radius2, 0.01f, radius2);
        // circle5.GetComponent<Renderer>().material.color = Color.green;
        // circle5.transform.parent = T5.transform;

        // Vector3 circle3Pos = circle3.transform.position;
        // Vector3 circle5Pos = circle5.transform.position;

        T3.AddComponent<Screener>();
        GameObject circle3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        circle3.transform.position = T3.transform.position;
        circle3.transform.localScale = new Vector3(radius3, 0.01f, radius3);
        circle3.GetComponent<Renderer>().material.color = new Color(0.5f, 0.85f, 1f);
        circle3.transform.parent = T3.transform;

        // GameObject line = new GameObject();
        // LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        // lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        // lineRenderer.widthMultiplier = 0.05f;
        // lineRenderer.startColor = Color.red;
        // lineRenderer.endColor = Color.red;
        // lineRenderer.numCapVertices = 10;
        // lineRenderer.numCornerVertices = 10;

        // lineRenderer.SetPositions(new Vector3[] { circle1Pos, circle2Pos });
        // lineRenderer.useWorldSpace = true;
        // lineRenderer.textureMode = LineTextureMode.Stretch;
        // lineRenderer.material.mainTextureScale = new Vector2(0.1f, 1f);
        // lineRenderer.material.SetTextureOffset("_MainTex", new Vector2(0, Time.time));

        // 將 O3,O4 設定為 Others 角色，並在其腳下產生一個半徑是其物體 1.5 倍大的咖啡色圓圈
        T6.AddComponent<Others>();
        T4.AddComponent<Others>();
        T5.AddComponent<Others>();

        GameObject circle6 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        circle6.transform.position = T6.transform.position;
        circle6.transform.localScale = new Vector3(radius6, 0.01f, radius6);
        circle6.GetComponent<Renderer>().material.color = new Color(1f, 0.6f, 0f, 0.3f);
        circle6.transform.parent = T6.transform;

        GameObject circle4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        circle4.transform.position = T4.transform.position;
        circle4.transform.localScale = new Vector3(radius4, 0.01f, radius4);
        circle4.GetComponent<Renderer>().material.color = Color.red;
        circle4.transform.parent = T4.transform;

        GameObject circle5 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        circle5.transform.position = T5.transform.position;
        circle5.transform.localScale = new Vector3(radius5, 0.01f, radius5);
        circle5.GetComponent<Renderer>().material.color = new Color(0.5f, 0.85f, 1f);
        circle5.transform.parent = T5.transform;

        // 將 T1 定義成球的類別
        // T1.AddComponent<Ball>();
        // GameObject circle1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // circle1.transform.position = T1.transform.position;
        // circle1.transform.localScale = new Vector3(radius1, 0.01f, radius1);
        // circle1.GetComponent<Renderer>().material.color = new Color(0.5f, 0f, 0f);
        // circle1.transform.parent = T1.transform;


        TC1 = T1.GetComponent<TPlayerController>();
        TC2 = T2.GetComponent<TPlayerController>();
        TC3 = T3.GetComponent<TPlayerController>();
        TC4 = T4.GetComponent<TPlayerController>();
        TC5 = T5.GetComponent<TPlayerController>();
        TC6 = T6.GetComponent<TPlayerController>();

        OC1 = O1.GetComponent<OPlayerController>();
        OC2 = O2.GetComponent<OPlayerController>();
        OC3 = O3.GetComponent<OPlayerController>();
        OC4 = O4.GetComponent<OPlayerController>();
        OC5 = O5.GetComponent<OPlayerController>();
        OC6 = O6.GetComponent<OPlayerController>();

    }



    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     if (taskIsStart)
    //     {
    //         if (MenuManager.ConfigureType == "MovableDisableNumberAccumulation")
    //         {
    //             T1RN.text = MDNQuestion[QuestionID][0];
    //             T2RN.text = MDNQuestion[QuestionID][1];
    //             T3RN.text = MDNQuestion[QuestionID][2];
    //             T4RN.text = MDNQuestion[QuestionID][3];
    //             T5RN.text = MDNQuestion[QuestionID][4];
    //         }
    //         else if (MenuManager.ConfigureType == "MovableEnableNumberAccumulation")
    //         {
    //             T1RN.text = MENQuestion[QuestionID][0];
    //             T2RN.text = MENQuestion[QuestionID][1];
    //             T3RN.text = MENQuestion[QuestionID][2];
    //             T4RN.text = MENQuestion[QuestionID][3];
    //             T5RN.text = MENQuestion[QuestionID][4];

    //             O1RN.text = D_MECQuestion[DQuestionID][0];
    //             O2RN.text = D_MECQuestion[DQuestionID][1];
    //             O3RN.text = D_MECQuestion[DQuestionID][2];
    //             O4RN.text = D_MECQuestion[DQuestionID][3];
    //             O5RN.text = D_MENQuestion[DQuestionID][4];
    //         }
    //         // else if (MenuManager.ConfigureType == "MovableDisableColorChange")
    //         // {
    //         //     T1RN.text = MDCQuestion[QuestionID][0];
    //         //     T2RN.text = MDCQuestion[QuestionID][1];
    //         //     T3RN.text = MDCQuestion[QuestionID][2];
    //         //     T4RN.text = MDCQuestion[QuestionID][3];
    //         //     // T5RN.text = MDCQuestion[QuestionID][4];
    //         // }
    //         // else
    //         // {
    //         //     T1RN.text = MECQuestion[QuestionID][0];
    //         //     T2RN.text = MECQuestion[QuestionID][1];
    //         //     T3RN.text = MECQuestion[QuestionID][2];
    //         //     T4RN.text = MECQuestion[QuestionID][3];
    //         //     // T5RN.text = MECQuestion[QuestionID][4];
    //         // }

    //     }
    // }

    public void Init_Task()
    {
        taskIsStart = false;
        taskIsSetup = false;
        taskIsPause = false;
        DQuestionID = 0;
        DStepID = 0;
        QuestionID = 0;
        StepID = 0;

        // T1RN.text = "";
        // T2RN.text = "";
        // T3RN.text = "";
        // T4RN.text = "";
        // T5RN.text = "";

        // O1RN.text = "";
        // O2RN.text = "";
        // O3RN.text = "";
        // O4RN.text = "";

        // meshRenderer = M1.GetComponent<SkinnedMeshRenderer>();
        // meshRenderer.material = TMN1;
        // meshRenderer = M2.GetComponent<SkinnedMeshRenderer>();
        // meshRenderer.material = TMN2;
        // meshRenderer = M3.GetComponent<SkinnedMeshRenderer>();
        // meshRenderer.material = TMN3;
        // meshRenderer = M4.GetComponent<SkinnedMeshRenderer>();
        // meshRenderer.material = TMN4;
        // meshRenderer = M5.GetComponent<SkinnedMeshRenderer>();
        // meshRenderer.material = TMN5;

        TC1.Init_Player();
        TC2.Init_Player();
        TC3.Init_Player();
        TC4.Init_Player();
        TC5.Init_Player();
        TC6.Init_Player();

        OC1.Init_Player();
        OC2.Init_Player();
        OC3.Init_Player();
        OC4.Init_Player();
        OC5.Init_Player();

    }

    public void Init_Pos()
    {
        T1.transform.position = new Vector3(0f, 0f, 6.5f);
        T2.transform.position = new Vector3(-3.5f, 0.0f, 6.5f);
        T3.transform.position = new Vector3(3.5f, 0.0f, 6.5f);
        T4.transform.position = new Vector3(-2.2f, 0.0f, 11f);
        T5.transform.position = new Vector3(2.2f, 0.0f, 11f);
        T6.transform.position = new Vector3(0f, 0.0f, 11f);


        O1.transform.position = new Vector3(-3.0f, 0.0f, 5.5f);
        O2.transform.position = new Vector3(3.0f, 0.0f, 5.5f);
        O3.transform.position = new Vector3(-1.7f, 0.0f, 10f);
        O4.transform.position = new Vector3(1.7f, 0.0f, 10f);
        O5.transform.position = new Vector3(0.0f, 0.0f, 10f);
        O6.transform.position = new Vector3(0.0f, 0.0f, 10f);

        T2.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        T3.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        T4.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        T5.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        T6.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);

        O1.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        O2.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        O3.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        O4.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        O5.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        O6.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

    }

    public void Split_Question(string questions, string type)
    {
        string[] content = questions.Split('\n');
        for (int i = 0; i < content.Length; i++)
        {
            List<string> questionList = content[i].Split(' ').ToList();
            if (type == "MDN")
                MDNQuestion.Add(questionList);
            else if (type == "MEN")
                MENQuestion.Add(questionList);
            else if (type == "MDC")
                MDCQuestion.Add(questionList);
            else
                MECQuestion.Add(questionList);

        }
    }

    public void Split_DQuestion(string d_questions, string d_type)
    {
        string[] d_content = d_questions.Split('\n');
        for (int i = 0; i < d_content.Length; i++)
        {
            List<string> d_questionList = d_content[i].Split(' ').ToList();
            if (d_type == "D_MDN")
                D_MDNQuestion.Add(d_questionList);
            else if (d_type == "D_MEN")
                D_MENQuestion.Add(d_questionList);
            else if (d_type == "D_MDC")
                D_MDCQuestion.Add(d_questionList);
            else
                D_MECQuestion.Add(d_questionList);

        }
    }

    public void Split_ChangeTimePlayer(string questions, string type)
    {
        string[] content = questions.Split('\n');
        for (int i = 0; i < content.Length; i++)
        {
            if (type == "CT")
                ChangeTime.Add(content[i]);
            if (type == "CP")
                ChangePlayer.Add(content[i]);
        }
    }

    public void Split_DChangeTimePlayer(string questions, string type)
    {
        string[] content = questions.Split('\n');
        for (int i = 0; i < content.Length; i++)
        {
            if (type == "D_CT")
                D_ChangeTime.Add(content[i]);
            if (type == "D_CP")
                D_ChangePlayer.Add(content[i]);
        }
    }
    public void Init_Question()
    {
        StepID = 0;
        DStepID = 0;

        // Debug.Log(MenuManager.ConfigureType);
        int playerID = int.Parse(ChangePlayer[QuestionID]);
        // int D_playerID = int.Parse(D_ChangePlayer[DQuestionID]);

        if (MenuManager.ConfigureType == "MovableDisableNumberAccumulation")
            GroundTruth = int.Parse(MDNQuestion[QuestionID][0]) + int.Parse(MDNQuestion[QuestionID][1]) + int.Parse(MDNQuestion[QuestionID][2]) + int.Parse(MDNQuestion[QuestionID][3]);
        else if (MenuManager.ConfigureType == "MovableEnableNumberAccumulation")
        {
            GroundTruth = int.Parse(MENQuestion[QuestionID][0]) + int.Parse(MENQuestion[QuestionID][1]) + int.Parse(MENQuestion[QuestionID][2]) + int.Parse(MENQuestion[QuestionID][3]) + int.Parse(MENQuestion[QuestionID][4]);
            // D_GroundTruth = int.Parse(D_MENQuestion[DQuestionID][0]) + int.Parse(D_MENQuestion[DQuestionID][1]) + int.Parse(D_MENQuestion[DQuestionID][2]) + int.Parse(D_MENQuestion[DQuestionID][3]) + int.Parse(D_MENQuestion[DQuestionID][4]);
        }
        else if (MenuManager.ConfigureType == "MovableDisableColorChange")
            GroundTruth = int.Parse(MDCQuestion[QuestionID][playerID - 1]);
        else
            GroundTruth = int.Parse(MECQuestion[QuestionID][playerID - 1]);
    }

    public void Player_NextPosition()
    {

        if (!taskIsPause)
        {
            if (StepID < TrajectoryManager.TrajectorySteps[QuestionID])
            {
                // Debug.Log(TrajectoryManager.TrajectorySteps[QuestionID]);
                // Debug.Log(StepID);
                // Debug.Log(QuestionID);
                TC1.MoveOn_NextPos(QuestionID, StepID);
                TC2.MoveOn_NextPos(QuestionID, StepID);
                TC3.MoveOn_NextPos(QuestionID, StepID);
                TC4.MoveOn_NextPos(QuestionID, StepID);
                TC5.MoveOn_NextPos(QuestionID, StepID);
                TC6.MoveOn_NextPos(QuestionID, StepID);

                // 如果有對手
                // if (MenuManager.OpponentType == "Enable" && DStepID < TrajectoryManager.DefTrajectorySteps[DQuestionID])
                // {
                //     Debug.Log(TrajectoryManager.DefTrajectorySteps[DQuestionID]);
                //     Debug.Log(DStepID);
                //     OC1.MoveOn_NextPos(DQuestionID, DStepID);
                //     OC2.MoveOn_NextPos(DQuestionID, DStepID);
                //     OC3.MoveOn_NextPos(DQuestionID, DStepID);
                //     OC4.MoveOn_NextPos(DQuestionID, DStepID);
                //     // OC5.MoveOn_NextPos(QuestionID, StepID);
                //     DStepID = DStepID + 1;
                // }


                StepID = StepID + 1;
            }
        }
    }

    public void DPlayer_NextPosition()
    {

        if (!taskIsPause)
        {
            if (DStepID < TrajectoryManager.DefTrajectorySteps[DQuestionID])
            {
                // Debug.Log(TrajectoryManager.TrajectorySteps[QuestionID]);
                // Debug.Log(StepID);
                // Debug.Log(TrajectoryManager.DefTrajectorySteps[DQuestionID]);
                // Debug.Log(DStepID);
                OC1.MoveOn_NextPos(DQuestionID, DStepID);
                OC2.MoveOn_NextPos(DQuestionID, DStepID);
                OC3.MoveOn_NextPos(DQuestionID, DStepID);
                OC4.MoveOn_NextPos(DQuestionID, DStepID);
                OC5.MoveOn_NextPos(DQuestionID, DStepID);
                OC6.MoveOn_NextPos(DQuestionID, DStepID);

                DStepID = DStepID + 1;

                // 如果有對手
                // if (MenuManager.OpponentType == "Enable" && DStepID < TrajectoryManager.DefTrajectorySteps[DQuestionID])
                // {
                //     Debug.Log(TrajectoryManager.DefTrajectorySteps[DQuestionID]);
                //     Debug.Log(DStepID);
                //     OC1.MoveOn_NextPos(DQuestionID, DStepID);
                //     OC2.MoveOn_NextPos(DQuestionID, DStepID);
                //     OC3.MoveOn_NextPos(DQuestionID, DStepID);
                //     OC4.MoveOn_NextPos(DQuestionID, DStepID);
                //     // OC5.MoveOn_NextPos(QuestionID, StepID);
                //     DStepID = DStepID + 1;
                // }


                // StepID = StepID + 1;
            }
        }
    }

    public void Player_ChangeColor()
    {
        int playerID = int.Parse(ChangePlayer[QuestionID]);
        if (playerID == 1)
            meshRenderer = M1.GetComponent<SkinnedMeshRenderer>();
        else if (playerID == 2)
            meshRenderer = M2.GetComponent<SkinnedMeshRenderer>();
        else if (playerID == 3)
            meshRenderer = M3.GetComponent<SkinnedMeshRenderer>();
        else
            meshRenderer = M4.GetComponent<SkinnedMeshRenderer>();

        meshRenderer.material = TMS;
    }

    public void Player_ChangeColorBack()
    {
        int playerID = int.Parse(ChangePlayer[QuestionID]);
        if (playerID == 1)
            meshRenderer.material = TMN1;
        else if (playerID == 2)
            meshRenderer.material = TMN2;
        else if (playerID == 3)
            meshRenderer.material = TMN3;
        else if (playerID == 4)
            meshRenderer.material = TMN4;
        else
            meshRenderer.material = TMN5;


    }

    public void Setup_TaskContent()
    {
        TimerManager.Initial_StartTimer();
        TimerManager.Initial_QuestionTimer();
    }

    public void ReadyTask()
    {

        if (MenuManager.OpponentType == "Disable")
        {
            O1.transform.position = new Vector3(100f, 0.0f, 5.5f);
            O2.transform.position = new Vector3(100f, 0.0f, 5.5f);
            O3.transform.position = new Vector3(100f, 0.0f, 10f);
            O4.transform.position = new Vector3(100f, 0.0f, 10f);
            O5.transform.position = new Vector3(100f, 0.0f, 10f);
        }

        TimerManager.Initial_StartTimer();
        taskIsReady = true;
    }


    //  這部分是為了要呈現 持球者與掩護者之間的關係
    /*private void OnDrawGizmos()
    {
        if (ballHandler == null || screener == null) return;

        Get the positions of the ball handler and screener
        Vector3 ballHandlerPosition = ballHandler.transform.position;
        Vector3 screenerPosition = screener.transform.position;

        Set the line color to black and the line style to dashed
        Gizmos.color = Color.red;
        Gizmos.DrawDashedLine(ballHandlerPosition, screenerPosition, 10f);
    }*/
}
