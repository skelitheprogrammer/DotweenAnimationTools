using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class SequenceAnimation
{
    [SerializeField] private UniversalAnimationSettings _universalSettings;
    [SerializeField] private LoopSettings _loopSettings;

    [SerializeField] private bool _delaySequence;
    [SerializeField] private float _delayDuration;

    [SerializeField] private DoTweenAnimationEvents _events;

    public UniversalAnimationSettings UniversalSettings => _universalSettings;
    public LoopSettings LoopSettings => _loopSettings;

    public bool DelaySequence => _delaySequence;
    public float DelayDuration => _delayDuration;

    public DoTweenAnimationEvents Events => _events;

    public void Setup(Sequence seq)
    {
        if (_loopSettings.Loop)
        {
            seq.SetLoops(_loopSettings.LoopCount, _loopSettings.LoopType);
        }

        if (_delaySequence)
        {
            seq.SetDelay(_delayDuration, _delaySequence);
        }

        if (_universalSettings.TimeScale != 1)
        {
            if (_universalSettings.TimeScaleDuration == 0)
            {
                seq.timeScale = _universalSettings.TimeScale;
            }
            else
            {
                seq.DOTimeScale(_universalSettings.TimeScale, _universalSettings.TimeScaleDuration);
            }
        }

        if (_universalSettings.UseCurve)
        {
            seq.SetEase(_universalSettings.Curve);
        }
        else
        {
            if (_universalSettings.EaseMode != Ease.Unset)
            {
                seq.SetEase(_universalSettings.EaseMode);
            }
        }

        if (_universalSettings.Invert)
        {
            seq.Flip();
        }

        seq.OnStart(() => _events.OnStartEvent?.Invoke());
        seq.OnComplete(() => _events.OnCompleteEvent?.Invoke());
        seq.OnKill(() => _events.OnKillEvent?.Invoke());
        seq.OnStepComplete(() => _events.OnStepComplete?.Invoke());
    }
}
