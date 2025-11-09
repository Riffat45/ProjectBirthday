using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SuratOpener : MonoBehaviour
{
    public List<Surat> ListSurat;
    public bool Read;
    public bool isReading;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while(Read == true && isReading == false)
        {
            Instantiate(ListSurat[0], transform);
            isReading = true;
        }

    }

    public void Delete()
    {
        ListSurat.Remove(ListSurat[0]);
        isReading = false;
    }
}
