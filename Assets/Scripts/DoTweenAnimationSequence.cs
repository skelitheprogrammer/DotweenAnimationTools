using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class DoTweenAnimationSequence : MonoBehaviour
{
    [SerializeField] private bool _onAwake;
    [SerializeField] private SequenceAnimation _sequenceAnimation;
    [SerializeField] private List<CustomSequence> _tweens;

    public SequenceAnimation SequenceAnimation => _sequenceAnimation;

    private Tweener _tweener;
    private Sequence _sequence;
    
    private void Awake()
    {
        _sequence = DOTween.Sequence();

        _sequenceAnimation.Setup(_sequence);

        foreach (var item in _tweens)
        {
            if (item.TweenSettings.AnimationType.DoTweenAnimationType is DoTweenAnimationType.None)
            {
                return;
            }

            if (item.UseSavedSettings)
            {
                item.TweenSettingsSO.Animation.Setup(ref _tweener, transform);
            }
            else
            {
                item.TweenSettings.Setup(ref _tweener, transform);
            }

            if (item.Join)
            {
                _sequence.Join(_tweener);
            }
            else
            {
                _sequence.Append(_tweener);
            }

        }

        if (_onAwake)
        {
            _sequence.Play();
        }

    }
}
