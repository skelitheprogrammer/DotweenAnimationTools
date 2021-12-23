using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class TweenAnimation
{
    [SerializeField] private UniversalAnimationSettings _universalSettings;
    [SerializeField] private AnimationType _animationType;
    [SerializeField] private LoopSettings _loopSettings;
    [SerializeField] private DoTweenAnimationEvents _events;

    public UniversalAnimationSettings UniversalSettings => _universalSettings;
    public AnimationType AnimationType => _animationType;
    public LoopSettings LoopSettings => _loopSettings;
    public DoTweenAnimationEvents Events => _events;

    public void Setup(ref Tweener tweener, Transform target)
    {
        tweener = _animationType.SetupAnimationType(target);

        if (_universalSettings.UseCurve)
        {
            tweener.SetEase(_universalSettings.Curve);
        }
        else
        {
            tweener.SetEase(_universalSettings.EaseMode);
        }

        if (_loopSettings.Loop)
        {
            tweener.SetLoops(_loopSettings.LoopCount, _loopSettings.LoopType);
        }

        if (_universalSettings.Delay > 0)
        {
            tweener.SetDelay(_universalSettings.Delay);
        }

        var timeScale = _universalSettings.TimeScale;
        var timeDuration = _universalSettings.TimeScaleDuration;

        if (timeScale != 1)
        {
            if (_universalSettings.TimeScaleDuration == 0)
            {
                tweener.timeScale = timeScale;
            }
            else
            {
                tweener.DOTimeScale(timeScale, timeDuration);
            }
        }

        if (_universalSettings.Invert)
        {
            tweener.Flip();
        }

        tweener.OnStart(() => _events.OnStartEvent?.Invoke());
        tweener.OnComplete(() => _events.OnCompleteEvent?.Invoke());
        tweener.OnKill(() => _events.OnKillEvent?.Invoke());
        tweener.OnStepComplete(() => _events.OnStepComplete?.Invoke());
    }

}
