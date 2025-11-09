using UnityEngine;
using UnityEngine.Playables;

public class SuratCloser : MonoBehaviour
{
    public static SuratCloser instance {  get; private set; }
    public SuratObject current;
    public CanvasGroup cg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }
    public void Clicked()
    {
        current.GetComponent<PlayableDirector>().Resume();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
