using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class SequenceAnimation
{
    [SerializeField] private UniversalAnimationSettings _universalSettings;
    [SerializeField] private LoopSettings _loopSettings;

    public UniversalAnimationSettings UniversalSettings => _universalSettings;
    public LoopSettings LoopSettings => _loopSettings;

    public void Setup(Sequence seq)
    {
        if (_loopSettings.Loop)
        {
            seq.SetLoops(_loopSettings.LoopCount, _loopSettings.LoopType);
        }

        seq.SetDelay(_universalSettings.Delay, _loopSettings.DelayEachLoop);

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
            seq.SetEase(_universalSettings.EaseMode);
        }

        if (_universalSettings.Invert)
        {
            seq.Flip();
        }

    }
}
