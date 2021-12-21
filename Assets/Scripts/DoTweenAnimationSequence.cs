using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class DoTweenAnimationSequence : MonoBehaviour
{
    [SerializeField] private SequenceAnimation _sequenceAnimation;
    [SerializeField] private List<CustomSequence> _tweens;

    public SequenceAnimation SequenceAnimation => _sequenceAnimation;

    private Tweener _tweener;
    private Sequence _sequence;
    
    private void Awake()
    {
        #region oldCode
        /*        var universalSettings = _sequenceAnimation.UniversalSettings;
        var loopSettings = _sequenceAnimation.LoopSettings;

        _sequence = DOTween.Sequence();

        if (loopSettings.Loop)
        {
            _sequence.SetLoops(loopSettings.LoopCount, loopSettings.LoopType);
        }

        foreach (var item in _tweens)
        {
            if (item.settings.AnimationType.DoTweenAnimationType is DoTweenAnimationType.None)
            {
                return;
            }

            item.settings.Setup(ref _tweener, transform);

            if (item.Join)
            {
                _sequence.Join(_tweener);
            }
            else
            {
                _sequence.Append(_tweener);
            }

        }

        _sequence.SetDelay(universalSettings.Delay, loopSettings.DelayEachLoop);

        if (universalSettings.TimeScale != 1)
        {
            if (universalSettings.TimeScaleDuration == 0)
            {
                _sequence.timeScale = universalSettings.TimeScale;
            }
            else
            {
                _sequence.DOTimeScale(universalSettings.TimeScale, universalSettings.TimeScaleDuration);
            }
        }

        if (universalSettings.Invert)
        {
            _sequence.Flip();
        }


        if (universalSettings.OnAwake)
        {
            _sequence.Play();
        }*/
        #endregion

        _sequence = DOTween.Sequence();

        foreach (var item in _tweens)
        {
            if (item.settings.AnimationType.DoTweenAnimationType is DoTweenAnimationType.None)
            {
                return;
            }

            item.settings.Setup(ref _tweener, transform);

            if (item.Join)
            {
                _sequence.Join(_tweener);
            }
            else
            {
                _sequence.Append(_tweener);
            }

        }

        _sequenceAnimation.Setup(_tweener, transform);
    }
}
