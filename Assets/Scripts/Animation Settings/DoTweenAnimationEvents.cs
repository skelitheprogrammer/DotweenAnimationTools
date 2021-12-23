using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DoTweenAnimationEvents
{
    [SerializeField] private UnityEvent _onStartEvent;
    [SerializeField] private UnityEvent _onCompleteEvent;
    [SerializeField] private UnityEvent _onKillEvent;
    [SerializeField] private UnityEvent _onStepComplete;

    public UnityEvent OnStartEvent => _onStartEvent;
    public UnityEvent OnCompleteEvent => _onCompleteEvent;
    public UnityEvent OnKillEvent => _onKillEvent;
    public UnityEvent OnStepComplete => _onStepComplete;
}