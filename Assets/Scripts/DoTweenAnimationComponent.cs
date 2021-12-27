using DG.Tweening;
using UnityEngine;
using NaughtyAttributes;

public class DoTweenAnimationComponent : MonoBehaviour
{
    
    [SerializeField] private bool _onAwake;
    [SerializeField] private bool _useSavedSettings;

    [ShowIf(nameof(_useSavedSettings))]
    [SerializeField] private TweenAnimationSO _tweenAnimationSO;

    [HideIf(nameof(_useSavedSettings))]
    [SerializeField] private TweenAnimation _tweenAnimation;

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
