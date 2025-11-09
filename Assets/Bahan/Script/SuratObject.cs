using UnityEngine;
using TMPro;
public class SuratObject : MonoBehaviour
{
    public TextMeshPro paragraphText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void SetText(string text)
    {
        paragraphText.text = text;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Complete()
    {
        SuratOpener.Instance.Delete();
    }
    public void EnableHitbox()
    {
        SuratCloser.instance.cg.alpha = 1;
        SuratCloser.instance.cg.blocksRaycasts = true;
    }
    public void DisableHitbox()
    {
        SuratCloser.instance.cg.alpha = 0;
        SuratCloser.instance.cg.blocksRaycasts = false;
    }
}
