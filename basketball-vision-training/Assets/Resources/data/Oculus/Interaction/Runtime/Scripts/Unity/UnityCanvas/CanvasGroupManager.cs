using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupManager : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    [SerializeField] private float _transitionTime;//how long does it take to transition
    [SerializeField] private bool _targetState;//true is on false is off
    [SerializeField] private float onAlpha = 1;
    public UnityEvent openCanvasEvent;
    public UnityEvent closeCanvasEvent;
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        if (_transitionTime > 0) _canvasGroup.alpha =
                Mathf.MoveTowards(_canvasGroup.alpha, _targetState ? onAlpha : 0, Time.unscaledDeltaTime / _transitionTime);
        else _canvasGroup.alpha = _targetState ? onAlpha : 0;

        _canvasGroup.blocksRaycasts = _targetState;
        _canvasGroup.interactable = _targetState;
    }
    public void SetState(bool state)
    {
        _targetState = state;
        (state ? openCanvasEvent : closeCanvasEvent).Invoke();
    }
    public void ToggleState()
    {
        _targetState = !_targetState;
    }
}
