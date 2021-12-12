using DG.Tweening;
using UnityEngine;

[System.Serializable]
public struct DoTweenAnimationData<T> where T : struct
{
    [SerializeField] private float _time;
    [SerializeField] private Ease _easeMode;
    [SerializeField] private T _variable;

    public float Time => _time;
    public Ease EaseMode => _easeMode;
    public T Variable => _variable;
}