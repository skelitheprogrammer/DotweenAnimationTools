using DG.Tweening;
using UnityEngine;

public class SingleDoTweenAnimation : DOTweenAnimationBase
{
    private void Awake()
    {
        if (_animationType == AnimationType.None)
        {
            Debug.LogError($"Choose animation type in {gameObject.name} {name}");
        }

        Setup();

        if (onAwake)
        {
            Tweener.Play();
        }
    }
}
