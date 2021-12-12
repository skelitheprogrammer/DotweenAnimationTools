using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class AnimationSettings
{
    [SerializeField] private AnimationType _animationType;
    public AnimationType AnimationType => _animationType;

    [SerializeField] private bool _blend;

    [Space(5f)]
    [SerializeField] private bool _invert;

    [Space(5f)]
    [SerializeField] private bool _isLoopable;
    [SerializeField] private int loopCount;
    [SerializeField] private LoopType loopType;

    [Space(5f)]
    [SerializeField] private float _delay;

    public Tweener Tweener { get; private set; }

    [Space(5f)]
    [SerializeField] private bool _useCustomData;

    [SerializeField] private DoTweenAnimationData<Vector3> _customData;
    [SerializeField] private DoTweenAnimationDataCreator<Vector3> _animationData;

    [Space(10f)]
    [SerializeField] private UnityEvent _onCompleteEvent;
    public UnityEvent OnCompleteEvent => _onCompleteEvent;

    public void Setup(Transform target)
    {
        if (target == null)
        {
            throw new NullReferenceException($"AnimationSettings: script requiers a target");
        }

        if (_animationType == AnimationType.None)
        {
            throw new Exception($"AnimationSettings: Choose animation type in {target.gameObject.name}");
        }

        if (!_useCustomData && _animationData == null)
        {
            throw new NullReferenceException($"AnimationSettings: Assign animation data to {target.gameObject.name} or use custom data");
        }

        float time;
        Ease easeMode;
        Vector3 toValue;

        if (_useCustomData)
        {
            time = _customData.Time;
            easeMode = _customData.EaseMode;
            toValue = _customData.Variable;
        }
        else
        {
            time = _animationData.Settings.Time;
            easeMode = _animationData.Settings.EaseMode;
            toValue = _animationData.Settings.Variable;
        }

        if (time == 0)
        {
            Debug.LogWarning($"AnimationSettings: {target.gameObject.name} timer set to 0!");
        }

        if (_blend)
        {
            switch (_animationType)
            {
                case AnimationType.Move:
                    Tweener = target.DOBlendableMoveBy(toValue, time);
                    break;
                case AnimationType.Rotate:
                    Tweener = target.DOBlendableRotateBy(toValue, time);
                    break;
                case AnimationType.Scale:
                    Tweener = target.DOBlendableScaleBy(toValue, time);
                    break;
            }
        }
        else
        {
            switch (_animationType)
            {
                case AnimationType.Move:
                    Tweener = target.DOMove(toValue, time);
                    break;
                case AnimationType.Rotate:
                    Tweener = target.DORotate(toValue, time);
                    break;
                case AnimationType.Scale:
                    Tweener = target.DOScale(toValue, time);
                    break;
            }
        }

        if (_invert)
        {
            Tweener.SetInverted();
        }

        Tweener.SetEase(easeMode);

        if (_isLoopable)
        {
            Tweener.SetLoops(loopCount, loopType);
        }

        Tweener.SetDelay(_delay);

        Tweener.OnComplete(() => _onCompleteEvent?.Invoke());
    }
}