using DG.Tweening;
using UnityEngine;

public class DoTweenAnimationComponent : MonoBehaviour
{
    [SerializeField] private AnimationSettings _animationSettings;
    public AnimationSettings AnimationSettings => _animationSettings;

    [SerializeField] private bool _onAwake;
    
    private Tweener _tweener;

    private void Awake()
    {
        _animationSettings.Setup(ref _tweener, transform);

        if (_onAwake)
        {
            _tweener.Play();
        }
    }

    public void PlayTweener()
    {
        if (_tweener.IsPlaying()) return;

        _animationSettings.Setup(ref _tweener, transform);
        _tweener.Play().OnComplete(() => _tweener.Rewind());
    }

    public void StopTweener()
    {
        if (!_tweener.IsPlaying()) return;
        
        _tweener.Rewind();
    }
}
