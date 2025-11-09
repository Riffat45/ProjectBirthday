using UnityEngine;

public class Pemutar : MonoBehaviour
{
    [SerializeField] Vector3 Rotasi;
    void FixedUpdate()
    {
        transform.Rotate(Rotasi);
    }
}
