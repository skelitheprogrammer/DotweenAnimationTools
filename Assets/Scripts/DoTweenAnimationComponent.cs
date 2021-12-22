using DG.Tweening;
using UnityEngine;

public class DoTweenAnimationComponent : MonoBehaviour
{
    [SerializeField] private TweenAnimation _tweenAnimation;
    [SerializeField] private bool _onAwake;

    public TweenAnimation TweenAnimation => _tweenAnimation;

    private Tweener _tweener;

    private void Awake()
    {
        _tweenAnimation.Setup(ref _tweener, transform);

        if (_onAwake)
        {
            _tweener.Play();
        } 
    }
}
