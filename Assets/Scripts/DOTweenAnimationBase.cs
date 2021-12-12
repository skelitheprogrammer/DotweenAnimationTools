using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public abstract class DOTweenAnimationBase : MonoBehaviour
{
    [SerializeField] protected AnimationType _animationType;
    public bool onAwake;

    [Space(5f)]
    [SerializeField] protected bool _invert;

    [Space(5f)]
    [SerializeField] protected bool _isLoopable;
    [SerializeField] protected int _loopCount;
    [SerializeField] protected LoopType _loopType;

    [Space(5f)]
    [SerializeField] protected float _delay;

    [Space(5f)]
    [SerializeField] protected bool _useCustomData;

    [SerializeField] protected DoTweenAnimationData<Vector3> _customData;

    [SerializeField] protected DoTweenAnimationDataCreator<Vector3> _animationData;

    [Space(10f)]
    [SerializeField] protected UnityEvent _onCompleteEvent;
    public UnityEvent OnCompleteEvent => _onCompleteEvent;

    public Tweener Tweener { get; protected set; }

    public void Setup()
    {
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

        switch (_animationType)
        {
            case AnimationType.Move:
                Tweener = transform.DOMove(toValue, time);
                break;
            case AnimationType.Rotate:
                Tweener = transform.DORotate(toValue, time);
                break;
            case AnimationType.Scale:
                Tweener = transform.DOScale(toValue, time);
                break;
        }

        if (_invert)
        {
            Tweener.SetInverted();
        }

        Tweener.SetEase(easeMode);

        if (_isLoopable)
        {
            Tweener.SetLoops(_loopCount, _loopType);
        }

        Tweener.SetDelay(_delay);

        Tweener.OnComplete(() => _onCompleteEvent.Invoke());
    }
}