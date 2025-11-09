using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class ImageObject : MonoBehaviour
{
    [SerializeField] Sprite ImageSource;
    [SerializeField] Image TargetGraphic;
    RectTransform tgr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    [ContextMenu("Apply")]
    public void Apply()
    {
        tgr = TargetGraphic.GetComponent<RectTransform>();
        TargetGraphic.sprite = ImageSource;
        TargetGraphic.SetNativeSize();
        float mul = 310 - tgr.sizeDelta.y;
        tgr.sizeDelta += new Vector2(mul, mul);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
