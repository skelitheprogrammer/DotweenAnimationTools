using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class AnimationType
{
    [SerializeField] private DoTweenAnimationType _animationType;

    [SerializeField] private float _duration;

    [SerializeField] private bool _useFrom;
    [SerializeField] private Vector3 _fromValue;
    [SerializeField] private Vector3 _ToValue;

    public DoTweenAnimationType DoTweenAnimationType => _animationType;
    public float Duration => _duration;

    public bool UseFrom => _useFrom;
    public Vector3 FromValue => _fromValue;
    public Vector3 ToValue => _ToValue;

    public Tweener SetupAnimationType(Transform target)
    {
        Tweener tweener = null;

        switch (_animationType)
        {
            case DoTweenAnimationType.None:
                break;
            case DoTweenAnimationType.Move:

                if (_useFrom)
                {
                    tweener = target.DOMove(_ToValue, _duration).From(_fromValue);
                }
                else
                {
                    tweener = target.DOMove(_ToValue, _duration);
                }

                break;
            case DoTweenAnimationType.Rotate:

                if (_useFrom)
                {
                    tweener = target.DORotate(_ToValue, _duration).From(_fromValue);
                }
                else
                {
                    tweener = target.DORotate(_ToValue, _duration);
                }

                break;
            case DoTweenAnimationType.Scale:

                if (_useFrom)
                {
                    tweener = target.DOScale(_ToValue, _duration).From(_fromValue);
                }
                else
                {
                    tweener = target.DOScale(_ToValue, _duration);
                }

                break;
            case DoTweenAnimationType.MoveBlend:

                tweener = target.DOBlendableMoveBy(_ToValue, _duration);

                break;
            case DoTweenAnimationType.RotateBlend:

                tweener = target.DOBlendableRotateBy(_ToValue, _duration);

                break;
            case DoTweenAnimationType.ScaleBlend:

                tweener = target.DOBlendableScaleBy(_ToValue, _duration);

                break;
        }

        return tweener;
    }

    #region Set Methods
    public void SetAnimationType(DoTweenAnimationType type)
    {
        _animationType = type;
    }

    public void SetDuration(float duration)
    {
        _duration = duration;
    }

    public void SetAxisValue(float value, Vector3 axis)
    {
        if (axis == Vector3.right)
        {
            _ToValue = new Vector3(value, _ToValue.y, _ToValue.z);
        }

        if (axis == Vector3.up)
        {
            _ToValue = new Vector3(_ToValue.x, value, _ToValue.z);
        }

        if (axis == Vector3.forward)
        {
            _ToValue = new Vector3(_ToValue.x, _ToValue.y, value);
        }
    }
    #endregion

}
