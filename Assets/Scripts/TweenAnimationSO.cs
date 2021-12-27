using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/DoTween/Create tween animation settings")]
public class TweenAnimationSO : ScriptableObject
{
    [SerializeField] private TweenAnimation _animation;

    public TweenAnimation Animation => _animation;
}
