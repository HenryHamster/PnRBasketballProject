using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Oculus.Voice.Demo;

public class MenuManager : MonoBehaviour
{

    private InteractionHandler InteractionHandler;

    public Text OpponentDebug, TaskDebug;


    // 提供使用者選擇訓練內容
    public GameObject ConfigureBackground;
    public GameObject DribbleBackground;
    public GameObject StartButton;

    // 訓練準備的倒數
    public GameObject HintBackground;
    public Text HintText;

    // 進入訓練之後可以在返回來
    public GameObject GameBackground;
    public GameObject ReturnBackground;


    public Sprite[] Pound = new Sprite[11];
    public Image DribbleGIFImage;


    private TaskManager TaskManager;
    private AudioManager AudioManager;

    // public ToggleGroup ModeOptionsGroup;
    public ToggleGroup OpponentOptionsGroup;
    public ToggleGroup TaskOptionsGroup;

    // private Toggle[] ModeOptionsArray;
    private Toggle[] OpponentOptionsArray;
    private Toggle[] TaskOptionsArray;


    public string ModeType, OpponentType, TaskType;
    public string ConfigureType;

    void Awake()
    {
        TaskManager = GameObject.FindObjectOfType<TaskManager>();
        AudioManager = GameObject.FindObjectOfType<AudioManager>();
        InteractionHandler = GameObject.FindObjectOfType<InteractionHandler>();
    }

    void Start()
    {
        OpponentOptionsArray = OpponentOptionsGroup.GetComponentsInChildren<Toggle>(true);
        TaskOptionsArray = TaskOptionsGroup.GetComponentsInChildren<Toggle>(true);
        Init_Menu();
        SetConfigure();

    }

    void Update()
    {
        OpponentToggle();
        TaskToggle();
        DribbleGIFImage.sprite = Pound[(int)(Time.time * 10) % Pound.Length];
    }

    public void Init_Menu()
    {
        ConfigureBackground.SetActive(true);
        DribbleBackground.SetActive(true);
        StartButton.SetActive(true);
        HintBackground.SetActive(false);
        ReturnBackground.SetActive(false);
        GameBackground.SetActive(false);

    }

    private void OpponentToggle()
    {
        for (int i = 0; i < OpponentOptionsArray.Length; i++)
            if (OpponentOptionsArray[i].isOn)
                OpponentType = OpponentOptionsArray[i].name;
    }

    private void TaskToggle()
    {
        for (int i = 0; i < TaskOptionsArray.Length; i++)
            if (TaskOptionsArray[i].isOn)
                TaskType = TaskOptionsArray[i].name;
    }

    public void SetConfigure()
    {
        ModeType = "Movable";
        OpponentType = "Enable";
        TaskType = "NumberAccumulation";

        OpponentDebug.text = OpponentType;
        TaskDebug.text = TaskType;

        ConfigureType = ModeType + OpponentType + TaskType;
        TaskManager.ReadyTask();
        AudioManager.AudioSource.Play();
        ConfigureBackground.SetActive(false);
        DribbleBackground.SetActive(false);
        StartButton.SetActive(false);
        HintBackground.SetActive(true);
        GameBackground.SetActive(true);

    }


    // 想要返回，確認是否要返回
    public void SetStop()
    {
        TaskManager.taskIsPause = true;
        ReturnBackground.SetActive(true);

    }

    // 重返球場
    public void SetCancel()
    {
        TaskManager.taskIsPause = false;
        ReturnBackground.SetActive(false);
    }

    // 重新設定配置
    public void SetReturn()
    {
        TaskManager.taskIsPause = false;
        Init_Menu();

        InteractionHandler.Init_Speech();
        AudioManager.Init_Audio();
        TaskManager.Init_Task();
        TaskManager.Init_Pos();
    }

}
