using DG.Tweening;
using UnityEngine;

public class KenanganManager : MonoBehaviour
{
    [SerializeField] RectTransform Viewport;
    CanvasGroup cg;
    private void OnEnable()
    {
        cg = GetComponent<CanvasGroup>();
        print("watehel");
        Transition();
    }

    void Transition()
    {
        cg.DOFade(1, 1).OnComplete(() =>
        {
            print("watehel23235");
            cg.DOFade(1, 1).OnComplete(() =>
            {
                Viewport.DOScale(1, 2).SetEase(Ease.InOutCubic);
            });
        });
    }
}
