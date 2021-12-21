using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AnimationSettings
{
    [SerializeField] private bool _loop;
    [SerializeField] private LoopType _loopType;
    [Min(-1)]
    [SerializeField] private int _loopCount;

    [SerializeField] private Ease _easeMode;

    [Range(0, 1f)]
    [SerializeField] private float _timeScale = 1f;
    [SerializeField] private float _timeScaleDuration;

    [Min(0)]
    [SerializeField] private float _delay;

    [SerializeField] private bool _invert;

    [SerializeField] private AnimationType _animationType;

    [SerializeField] private UnityEvent _onStart;
    [SerializeField] private UnityEvent _onComplete;

    public bool Loop => _loop;

    public LoopType LoopType => _loopType;

    public int LoopCount => _loopCount;

    public Ease EaseMode => _easeMode;

    public float Delay => _delay;

    public UnityEvent OnComplete => _onComplete;
    public UnityEvent OnStart => _onStart;

    public AnimationType TypeAnimation => _animationType;

    public void Setup(ref Tweener tweener, Transform target)
    {
        tweener = _animationType.SetupAnimationType(target);

        tweener.SetEase(_easeMode);

        if (_loop)
        {
            tweener.SetLoops(_loopCount, _loopType);
        }

        if (_delay > 0)
        {
            tweener.SetDelay(_delay);
        }

        if (_timeScale != 1)
        {
            if (_timeScaleDuration == 0)
            {
                tweener.timeScale = _timeScale;
            }
            else
            {
                tweener.DOTimeScale(_timeScale, _timeScaleDuration);
            }
        }

        if (_invert)
        {
            tweener.Flip();
        }

        tweener.OnStart(() => _onStart?.Invoke());
        tweener.OnComplete(() => _onComplete?.Invoke());
    }

    #region Sets
    public void SetLoopState(bool state)
    {
        _loop = state;
    }

    public void SetLoopType(int loopIndex)
    {
        if (loopIndex < 0)
        {
            _loopType = 0;
            return;
        }

        _loopType = (LoopType)loopIndex;
    }

    public void SetLoopCount(int count)
    {
        if (count < -1)
        {
            _loopCount = -1;
            return;
        }

        _loopCount = count;
    }

    public void SetEaseMode(int easeIndex)
    {
        if (easeIndex < 0)
        {
            _easeMode = 0;
        }

        _easeMode = (Ease)easeIndex;
    } 

    public void SetDelay(float value)
    {
        if (value < 0)
        {
            _delay = 0;
            return;
        }

        _delay = value;
    }

    public void SetInvertState(bool state)
    {
        _invert = state;
    }
    #endregion
}
