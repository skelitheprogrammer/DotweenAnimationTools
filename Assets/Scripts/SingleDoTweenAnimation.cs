using DG.Tweening;
using UnityEngine;

public class SingleDoTweenAnimation : MonoBehaviour
{
    public AnimationSettings animationSettings;
    public bool onAwake;

    private void Awake()
    {
        animationSettings.Setup(null);

        if (onAwake)
        {
            animationSettings.Tweener.Play();
        }
    }


}
