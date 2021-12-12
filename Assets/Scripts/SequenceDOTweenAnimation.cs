using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class SequenceDOTweenAnimation : MonoBehaviour
{
    public List<CustomSequenceElement> _tweens;
    private Sequence _sequence;

    private void Awake()
    {
        _sequence = DOTween.Sequence();

        foreach (var item in _tweens)
        {
            if (item.reference.onAwake)
            {
                item.reference.onAwake = false;
            } 

            var tweener = item.reference.Tweener;
            
            if (item.join)
            {
                _sequence.Join(tweener);
            }
            else
            {
                _sequence.Append(tweener);
            }
        }

        _sequence.Play();
    }
}
