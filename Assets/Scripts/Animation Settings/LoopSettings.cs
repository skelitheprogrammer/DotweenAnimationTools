using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class LoopSettings
{
    [Min(-1)]
    [SerializeField] private bool _loop;
    [SerializeField] private int _loopCount;
    [SerializeField] private LoopType _loopType;

    public bool Loop => _loop;
    public int LoopCount => _loopCount;
    public LoopType LoopType => _loopType;
}