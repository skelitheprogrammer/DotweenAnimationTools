using UnityEngine;

[System.Serializable]
public class CustomSequence
{
    [SerializeField] private bool _join;

    public TweenAnimation settings;

    public bool Join => _join;
}
