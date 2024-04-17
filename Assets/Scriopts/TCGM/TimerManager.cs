using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Oculus.Voice.Demo;
//NO LONGER CONTROLS PLAYER MOVEMENT
public class TimerManager : MonoBehaviour
{
    // Question
    public TimeSpan QuestionTime;
    public TimeSpan QuestionTimer, QuestionTimerCurrent, QuestionTimerInitial;
    public TimeSpan QuestionTimerInitial_TMP;

    // Step
    public TimeSpan StepTime;
    public TimeSpan StepTimer, StepTimerCurrent, StepTimerInitial;
    public TimeSpan StepTimerInitial_TMP;

    public TimeSpan StartTime;
    public TimeSpan StartTimer, StartTimerCurrent, StartTimerInitial;
    public TimeSpan StartTimerInitial_TMP;

    public TimeSpan ChangeTime, ChangeTimeEnd;
    public TimeSpan ChangeTimer, ChangeTimerCurrent, ChangeTimerInitial;
    public TimeSpan ChangeTimerInitial_TMP;

    private TaskManager TaskManager;
    private MenuManager MenuManager;
    private CorrectManager CorrectManager;
    private InteractionHandler InteractionHandler;

    void Awake()
    {
        MenuManager = GameObject.FindObjectOfType<MenuManager>();
        TaskManager = GameObject.FindObjectOfType<TaskManager>();
        CorrectManager = GameObject.FindObjectOfType<CorrectManager>();
        InteractionHandler = GameObject.FindObjectOfType<InteractionHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        QuestionTimer = new TimeSpan(0, 0, 0, 0, 0);
        QuestionTimerCurrent = new TimeSpan(0, 0, 0, 0, 0);
        QuestionTimerInitial = new TimeSpan(0, 0, 0, 0, 0);
        QuestionTime = new TimeSpan(0, 0, 0, 0, 100000);


        StepTimer = new TimeSpan(0, 0, 0, 0, 0);
        StepTimerCurrent = new TimeSpan(0, 0, 0, 0, 0);
        StepTimerInitial = new TimeSpan(0, 0, 0, 0, 0);
        StepTime = new TimeSpan(0, 0, 0, 0, 100);


        StartTimer = new TimeSpan(0, 0, 0, 0, 0);
        StartTimerCurrent = new TimeSpan(0, 0, 0, 0, 0);
        StartTimerInitial = new TimeSpan(0, 0, 0, 0, 0);
        StartTime = new TimeSpan(0, 0, 0, 0, 4000);
    }

    void FixedUpdate()
    {

        if (TaskManager.taskIsReady)
        {
            StartTimerCurrent = DateTime.Now.TimeOfDay;
            StartTimer = StartTimerCurrent.Subtract(StartTimerInitial_TMP);
            string coutdown = StartTime.Subtract(StartTimer).ToString(@"ss");
            if (coutdown == "03")
                MenuManager.HintText.text = "3";
            else if (coutdown == "02")
                MenuManager.HintText.text = "2";
            else if (coutdown == "01")
                MenuManager.HintText.text = "1";
            else
                MenuManager.HintText.text = "GO!";


            if (StartTimer > StartTime)
            {
                TaskManager.taskIsStart = true;
                TaskManager.taskIsReady = false;
                TaskManager.Init_Question();
                Initial_QuestionTimer();
                Initial_StepTimer();
                InteractionHandler.ToggleActivation();

                if (MenuManager.TaskType == "ColorChange")
                {
                    ChangeTime = new TimeSpan(0, 0, 0, 0, int.Parse(TaskManager.ChangeTime[TaskManager.QuestionID]));
                    ChangeTimeEnd = new TimeSpan(0, 0, 0, 0, Int32.Parse(TaskManager.ChangeTime[TaskManager.QuestionID]) + 1000);
                    Initial_ChangeTimer();
                }
                MenuManager.HintBackground.SetActive(false);
                MenuManager.GameBackground.SetActive(true);
            }
        }



        if (TaskManager.taskIsStart && !TaskManager.taskIsPause)
        {

            // Debug.Log("Start!");
            QuestionTimerCurrent = DateTime.Now.TimeOfDay;
            QuestionTimer = QuestionTimerCurrent.Subtract(QuestionTimerInitial_TMP);

            StepTimerCurrent = DateTime.Now.TimeOfDay;
            StepTimer = StepTimerCurrent.Subtract(StepTimerInitial_TMP);

            ChangeTimerCurrent = DateTime.Now.TimeOfDay;
            ChangeTimer = ChangeTimerCurrent.Subtract(ChangeTimerInitial_TMP);


            // 強制下一題
            if (QuestionTimer > QuestionTime)
            {
                TaskManager.QuestionID = TaskManager.QuestionID + 1;
                // TaskManager.DQuestionID = TaskManager.DQuestionID + 1;
                CorrectManager.CheckAnswer();
                TaskManager.Init_Question();
                Initial_QuestionTimer();
                Initial_StepTimer();
                InteractionHandler.ToggleActivation();

                if (MenuManager.TaskType == "ColorChange")
                {
                    ChangeTime = new TimeSpan(0, 0, 0, 0, Int32.Parse(TaskManager.ChangeTime[TaskManager.QuestionID]));
                    ChangeTimeEnd = new TimeSpan(0, 0, 0, 0, Int32.Parse(TaskManager.ChangeTime[TaskManager.QuestionID]) + 1000);
                    Initial_ChangeTimer();
                }

            }
            else
            {
                if (MenuManager.ModeType == "Movable")
                {
                    if (StepTimer > StepTime)
                    {
                        TaskManager.Player_NextPosition();
                        TaskManager.DPlayer_NextPosition();
                        Initial_StepTimer();
                    }
                }

                // if (MenuManager.TaskType == "ColorChange")
                // {
                //     // 將目標球員的衣服變換顏色
                //     if (ChangeTimer > ChangeTime && ChangeTimer < ChangeTimeEnd)
                //         TaskManager.Player_ChangeColor();
                //     // 變回統一的顏色
                //     if (ChangeTimer > ChangeTimeEnd)
                //         TaskManager.Player_ChangeColorBack();
                // }
            }
        }

    }

    public void Initial_QuestionTimer()
    {
        QuestionTimerInitial = DateTime.Now.TimeOfDay;
        QuestionTimerInitial_TMP = QuestionTimerInitial;
    }

    public void Initial_StepTimer()
    {
        StepTimerInitial = DateTime.Now.TimeOfDay;
        StepTimerInitial_TMP = StepTimerInitial;
    }

    public void Initial_StartTimer()
    {
        StartTimerInitial = DateTime.Now.TimeOfDay;
        StartTimerInitial_TMP = StartTimerInitial;
    }

    public void Initial_ChangeTimer()
    {
        ChangeTimerInitial = DateTime.Now.TimeOfDay;
        ChangeTimerInitial_TMP = ChangeTimerInitial;
    }
}
