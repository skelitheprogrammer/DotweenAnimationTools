using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public abstract class AnimationSettings<T> where T : struct
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
    [SerializeField] private bool useCustomData;

    public abstract DoTweenAnimationData<T> CustomData { get;}
    public abstract DoTweenAnimationDataCreator<T> SOAnimationData { get; }

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

        if (!useCustomData && SOAnimationData == null)
        {
            throw new NullReferenceException($"AnimationSettings: Assign animation data to {target.gameObject.name} or use custom data");
        }

        float time;
        Ease easeMode;
        T toValue;

        if (useCustomData)
        {
            time = CustomData.Time;
            easeMode = CustomData.EaseMode;
            toValue = CustomData.Variable;
        }
        else
        {
            time = SOAnimationData.Settings.Time;
            easeMode = SOAnimationData.Settings.EaseMode;
            toValue = SOAnimationData.Settings.Variable;
        }

        if (time == 0)
        {
            Debug.LogWarning($"AnimationSettings: {target.gameObject.name} timer set to 0!");
        }
/*
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
        }*/

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

    protected abstract void SetupTweener(object target, T tovalue, float time);
}

public sealed class AnimationSettingsFloat : AnimationSettings<float>
{
    [SerializeField] private DoTweenAnimationData<float> _customData;
    [SerializeField] private DoTweenAnimationDataCreator<float> _soAnimationData;

    public override DoTweenAnimationData<float> CustomData => _customData;
    public override DoTweenAnimationDataCreator<float> SOAnimationData => _soAnimationData;

    protected override void SetupTweener(object target, float tovalue, float time)
    {

    }
}

public sealed class AnimationSettingsVector3 : AnimationSettings<Vector3>
{
    [SerializeField] private DoTweenAnimationData<Vector3> _customData;
    [SerializeField] private DoTweenAnimationDataCreator<Vector3> _soAnimationData;

    public override DoTweenAnimationData<Vector3> CustomData => _customData;
    public override DoTweenAnimationDataCreator<Vector3> SOAnimationData => _soAnimationData;

    protected override void SetupTweener(object target, Vector3 tovalue, float time)
    {
    }
}