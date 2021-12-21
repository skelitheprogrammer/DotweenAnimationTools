using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class TweenAnimation
{
    [SerializeField] private UniversalAnimationSettings _universalSettings;
    [SerializeField] private AnimationType _animationType;
    [SerializeField] private Ease _easeMode;
    [SerializeField] private LoopSettings _loopSettings;

    public UniversalAnimationSettings UniversalSettings => _universalSettings;
    public AnimationType AnimationType => _animationType;
    public Ease EaseMode => _easeMode;
    public LoopSettings LoopSettings => _loopSettings;

    public void Setup(ref Tweener tweener, Transform target)
    {
        tweener = _animationType.Setup(target);

        tweener.SetEase(_easeMode);

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

/*        tweener.OnStart(() => _onStart?.Invoke());
        tweener.OnComplete(() => _onComplete?.Invoke());*/

        if (_universalSettings.OnAwake)
        {
            tweener.Play();
        }
    }

}
