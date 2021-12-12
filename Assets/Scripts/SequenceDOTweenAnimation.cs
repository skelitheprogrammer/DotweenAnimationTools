using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SequenceDOTweenAnimation : MonoBehaviour
{
    public bool onAwake;
    public List<CustomSequenceElement> tweens;
    private Sequence _sequence;

    public UnityEvent onSequenceEndEvent;


    private void Awake()
    {
        _sequence = DOTween.Sequence();

        foreach(var item in tweens)
        {
            item.animationSettings.Setup(transform);
            
            if (item.join)
            {
                _sequence.Join(item.animationSettings.Tweener);
            }
            else
            {
                _sequence.Append(item.animationSettings.Tweener);
            }
        }

        _sequence.OnComplete(() => onSequenceEndEvent?.Invoke());

        if (onAwake)
        {
            PlaySequence();
        }

    }

    public void PlaySequence()
    {
        _sequence.Play();
    }
}
