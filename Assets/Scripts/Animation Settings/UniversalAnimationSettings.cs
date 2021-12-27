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

    [SerializeField] private bool _useCurve;

    [SerializeField] private Ease _easeMode;
    [SerializeField] private AnimationCurve _curve;

    public float Delay => _delay;
    public float TimeScale => _timeScale;
    public float TimeScaleDuration => _timeScaleDuration;
    public bool Invert => _invert;

    public Ease EaseMode => _easeMode;

    public bool UseCurve => _useCurve;
    public AnimationCurve Curve => _curve;
}