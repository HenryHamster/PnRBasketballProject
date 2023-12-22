using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Voice.Demo;

public class CorrectManager : MonoBehaviour
{

    public TaskManager TaskManager;
    public InteractionHandler InteractionHandler;
    public AudioManager AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        TaskManager = GameObject.FindObjectOfType<TaskManager>();
        AudioManager = GameObject.FindObjectOfType<AudioManager>();
        InteractionHandler = GameObject.FindObjectOfType<InteractionHandler>();
    }

    public void CheckAnswer()
    {
        if(TaskManager.GroundTruth == InteractionHandler.ResponseAns)
            AudioManager.Play_CorrectAudio();
        else
            AudioManager.Player_WrongAudio();

        InteractionHandler.ResponseAns = -1;  
    }
}
