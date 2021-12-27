using UnityEngine;

[System.Serializable]
public class CustomSequence
{
    [SerializeField] private bool _join;

    [SerializeField] private TweenAnimation _tweenSettings;
    [SerializeField] private bool _useSavedSettings;
    [SerializeField] private TweenAnimationSO _tweenSettingsSO;


    public bool Join => _join;
    public TweenAnimation TweenSettings => _tweenSettings;
    public bool UseSavedSettings => _useSavedSettings;
    public TweenAnimationSO TweenSettingsSO => _tweenSettingsSO;
}
