using DG.Tweening;
using UnityEngine;

public class KenanganManager : MonoBehaviour
{
    [SerializeField] RectTransform Viewport;
    CanvasGroup cg;
    private void OnEnable()
    {
        cg = GetComponent<CanvasGroup>();
        Transition();
    }

    void Transition()
    {
        cg.DOFade(1, 1).OnComplete(() =>
        { 
            cg.DOFade(1, 1).OnComplete(() =>
            {
                Viewport.DOScale(1, 3).SetEase(Ease.InOutCubic);
            });
        });
    }
}
