using DG.Tweening;
using UnityEngine;

public class DoTweenAnimationComponent : MonoBehaviour
{
    [SerializeField] private bool _onAwake;
    [SerializeField] private TweenAnimation _tweenAnimation;
    [SerializeField] private bool _useSavedSettings;
    [SerializeField] private TweenAnimationSO _tweenAnimationSO;

    public TweenAnimation TweenAnimation => _tweenAnimation;

    private Tweener _tweener;

    private void Awake()
    {
        if (_useSavedSettings)
        {
            _tweenAnimationSO.Animation.Setup(ref _tweener, transform);
        }
        else
        {
            _tweenAnimation.Setup(ref _tweener, transform);
        }


        if (_onAwake)
        {
            _tweener.Play();
        } 
    }
}
