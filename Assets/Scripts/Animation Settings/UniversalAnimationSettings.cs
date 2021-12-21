using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class UniversalAnimationSettings
{

    [SerializeField] private float _delay;

    [Min(0f)]
    [SerializeField] private float _timeScale = 1f;
    
    [Min(0f)]
    [SerializeField] private float _timeScaleDuration;
    [SerializeField] private bool _invert;

    [SerializeField] private bool _onAwake;

    public float Delay => _delay;
    public float TimeScale => _timeScale;
    public float TimeScaleDuration => _timeScaleDuration;
    public bool Invert => _invert;
    public bool OnAwake => _onAwake;
}