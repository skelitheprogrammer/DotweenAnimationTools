using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class AnimationType
{
    [SerializeField] private DoTweenAnimationType _animationType;

    [SerializeField] private float _duration;

    [SerializeField] private Vector3 _vector3ToValue;

    public DoTweenAnimationType DoTweenAnimationType => _animationType;
    public float Duration => _duration;
    public Vector3 Vector3ToValue => _vector3ToValue;

    public Tweener Setup(Transform target)
    {
        Tweener tweener = null;

        switch (_animationType)
        {
            case DoTweenAnimationType.None:
                break;
            case DoTweenAnimationType.Move:
                tweener = target.DOMove(_vector3ToValue, _duration);
                break;
            case DoTweenAnimationType.Rotate:
                tweener = target.DORotate(_vector3ToValue, _duration);
                break;
            case DoTweenAnimationType.Scale:
                tweener = target.DOScale(_vector3ToValue, _duration);
                break;
            case DoTweenAnimationType.MoveBlend:
                tweener = target.DOBlendableMoveBy(_vector3ToValue, _duration);
                break;
            case DoTweenAnimationType.RotateBlend:
                tweener = target.DOBlendableRotateBy(_vector3ToValue, _duration);
                break;
            case DoTweenAnimationType.ScaleBlend:
                tweener = target.DOBlendableScaleBy(_vector3ToValue, _duration);
                break;
        }

        return tweener;
    }

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
            _vector3ToValue = new Vector3(value, _vector3ToValue.y, _vector3ToValue.z);
        }

        if (axis == Vector3.up)
        {
            _vector3ToValue = new Vector3(_vector3ToValue.x, value, _vector3ToValue.z);
        }

        if (axis == Vector3.forward)
        {
            _vector3ToValue = new Vector3(_vector3ToValue.x, _vector3ToValue.y, value);
        }
    }
}
