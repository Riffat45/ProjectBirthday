using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;

public class FingerPrint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Clicked()
    {
        transform.DOScale(1.5f, .5f).OnComplete(() =>
        {
            GameObject.Find("Animator").GetComponent<PlayableDirector>().Resume();
        });
    }
}
