using System.Security.Cryptography;
using UnityEngine;

public class TransformClamp : MonoBehaviour
{
    [SerializeField] Vector3 MinScale;
    [SerializeField] Vector3 MaxScale;
    [SerializeField] Vector3 MinPos;
    [SerializeField] Vector3 MaxPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, MinPos.x * transform.localScale.x, MaxPos.x * transform.localScale.x), Mathf.Clamp(transform.localPosition.y, MinPos.y * transform.localScale.x, MaxPos.y * transform.localScale.x),Mathf.Clamp(transform.localPosition.z,MinPos.z * transform.localScale.x,MaxPos.z * transform.localScale.x));
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, MinScale.x, MaxScale.x), Mathf.Clamp(transform.localScale.y, MinScale.y, MaxScale.y), Mathf.Clamp(transform.localScale.z, MinScale.z, MaxScale.z));
    }
}
