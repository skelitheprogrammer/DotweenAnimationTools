using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class SequenceAnimation
{
    [SerializeField] private LoopSettings _loopSettings;
    [SerializeField] private UniversalAnimationSettings _universalSettings;

    public LoopSettings LoopSettings => _loopSettings;
    public UniversalAnimationSettings UniversalSettings => _universalSettings;

    public void Setup(Tweener tween, Transform transform)
    {
        if (_loopSettings.Loop)
        {
            tween.SetLoops(_loopSettings.LoopCount, _loopSettings.LoopType);
        }

        tween.SetDelay(_universalSettings.Delay, _loopSettings.DelayEachLoop);

        if (_universalSettings.TimeScale != 1)
        {
            if (_universalSettings.TimeScaleDuration == 0)
            {
                tween.timeScale = _universalSettings.TimeScale;
            }
            else
            {
                tween.DOTimeScale(_universalSettings.TimeScale, _universalSettings.TimeScaleDuration);
            }
        }

        if (_universalSettings.Invert)
        {
            tween.Flip();
        }


        if (_universalSettings.OnAwake)
        {
            tween.Play();
        }
    }
}
