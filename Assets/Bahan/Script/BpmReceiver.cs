using DG.Tweening;
using UnityEngine;

public class BpmReceiver : MonoBehaviour
{
    ParticleSystem _particleSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeat()
    {
        Debug.Log("kon");
        DOTween.Complete(this);
        transform.localScale = new Vector3(8,8,8);
        transform.DOScale(new Vector3(10, 10, 10), .2f).OnComplete(() =>
        {
            DOTween.Complete(this);
        });
    }
    
}
