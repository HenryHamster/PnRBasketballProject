using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AnimationState
{
   idle, sidestepping,backwards,forwards
}
[RequireComponent(typeof(Animator))]

public class AnimationStateMachine : MonoBehaviour
{
    [SerializeField] private AnimationState state;
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        StateMachine();
    }
    void StateMachine()
    {
        switch (state)
        {
            case AnimationState.idle:
                IdleStateActions();
                IdleTransitions();
                break;

            case AnimationState.sidestepping:
                SideSteppingActions();
                SideSteppingTransitions();
                break;

            case AnimationState.backwards:
                BackwardsActions();
                BackwardsTransition();
                break;
            case AnimationState.forwards:
                ForwardsActions();
                ForwardsTransition();
                break;

            default:
                break;
        }
    }
    void IdleStateActions()
    {

    }
    void SideSteppingActions()
    {

    }

    void BackwardsActions()
    {

    }

    void ForwardsActions()
    {

    }
    void IdleTransitions()
    {

    }
    void SideSteppingTransitions()
    {

    }

    void BackwardsTransition()
    {

    }

    void ForwardsTransition()
    {

    }
}
