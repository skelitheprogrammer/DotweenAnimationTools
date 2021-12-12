using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AnimationSettings
{
    public AnimationType animationType;

    [Space(5f)]
    public bool invert;

    [Space(5f)]
    public bool isLoopable;
    public int loopCount;
    public LoopType loopType;

    [Space(5f)]
    public float delay;

    public Tweener Tweener;

    [Space(5f)]
    public bool useCustomData;

    public DoTweenAnimationData<Vector3> customData;
    public DoTweenAnimationDataCreator<Vector3> animationData;

    [Space(10f)]
    public UnityEvent onCompleteEvent;

    public void Setup(Transform target)
    {
        if (animationType == AnimationType.None)
        {
            Debug.LogError($"Choose animation type in {target.gameObject.name}");
        }

        float time;
        Ease easeMode;
        Vector3 toValue;

        if (useCustomData)
        {
            time = customData.Time;
            easeMode = customData.EaseMode;
            toValue = customData.Variable;
        }
        else
        {
            time = animationData.Settings.Time;
            easeMode = animationData.Settings.EaseMode;
            toValue = animationData.Settings.Variable;
        }

        switch (animationType)
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

        if (invert)
        {
            Tweener.SetInverted();
        }

        Tweener.SetEase(easeMode);

        if (isLoopable)
        {
            Tweener.SetLoops(loopCount, loopType);
        }

        Tweener.SetDelay(delay);

        Tweener.OnComplete(() => onCompleteEvent?.Invoke());
    }
}