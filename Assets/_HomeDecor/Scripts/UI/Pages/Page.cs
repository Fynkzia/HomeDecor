using DG.Tweening;
using HomeDecor.Core;
using UnityEngine;

namespace HomeDecor.Pages
{
    public abstract class Page : MonoBehaviour
    {
        public abstract void Init(AppState state);

        public virtual void Show()
        {
            gameObject.SetActive(true);
            AnimateIn();
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
            AnimateOut();
        }

        protected virtual void AnimateIn()
        {
            RectTransform rect = GetComponent<RectTransform>();
            rect.localScale = Vector3.one * 0.9f;
            rect.anchoredPosition = new Vector2(0, -100f); // немного ниже
            rect.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
            rect.DOAnchorPosY(0, 0.3f).SetEase(Ease.OutCubic);
        }

        protected virtual void AnimateOut()
        {
            RectTransform rect = GetComponent<RectTransform>();
            rect.DOScale(0.95f, 0.2f).SetEase(Ease.InBack);
            rect.DOAnchorPosY(-100f, 0.2f).SetEase(Ease.InCubic).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
}
