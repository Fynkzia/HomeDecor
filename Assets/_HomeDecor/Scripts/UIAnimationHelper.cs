using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public static class UIAnimationHelper
{
    public static void DoPopIn(this Transform transform, float duration = 0.3f, float overshoot = 1.2f)
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, duration).SetEase(Ease.OutBack).SetEase(Ease.OutBack, overshoot);
    }

    public static void DoPopOut(this Transform transform, float duration = 0.2f)
    {
        transform.DOScale(0f, duration).SetEase(Ease.InBack).OnComplete(() => transform.gameObject.SetActive(false));
    }

    public static void DoClickEffect(this Transform transform, float punch = 0.1f, float duration = 0.2f)
    {
        transform.DOKill();
        transform.DOPunchScale(Vector3.one * punch, duration, 10, 1);
    }

}

