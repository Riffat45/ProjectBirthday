using System.Collections;
using UnityEngine;

public class FireworksSpawner : MonoBehaviour
{
    [SerializeField] Vector3 Space;
    [SerializeField] float MinSpawnTime;
    [SerializeField] float MaxSpawnTime;
    [SerializeField] GameObject Firework;
    private void OnEnable()
    {
        StartCoroutine(StartSpawning());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator StartSpawning()
    {
        while (gameObject.activeSelf == true)
        {
            yield return new WaitForSeconds(Random.Range(MinSpawnTime, MaxSpawnTime));
            Instantiate(Firework,new Vector3(Random.Range(-Space.x,Space.x), Random.Range(-Space.y, Space.y), Random.Range(-Space.z, Space.z)),Quaternion.identity,transform);
        }
    }
}
