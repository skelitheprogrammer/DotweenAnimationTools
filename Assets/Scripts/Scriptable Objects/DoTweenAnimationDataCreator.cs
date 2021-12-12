using UnityEngine;

public abstract class DoTweenAnimationDataCreator<T> : ScriptableObject where T : struct
{
    [SerializeField] private DoTweenAnimationData<T> _settings;
    public DoTweenAnimationData<T> Settings => _settings;
}
