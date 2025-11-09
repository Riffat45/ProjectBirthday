using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SuratOpener : MonoBehaviour
{
    public static SuratOpener Instance { get; private set; }
    public List<Surat> ListSurat;
    public bool Read;
    public bool isReading;

    int currentIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        while (Read == true && isReading == false)
        {
            GameObject instance = Instantiate(ListSurat[currentIndex].PrefabTemplate.gameObject, transform);
            SuratCloser.instance.current = instance.GetComponent<SuratObject>();
            instance.GetComponent<SuratObject>().SetText(ListSurat[currentIndex].Paragraph.text);
            isReading = true;
        }

    }

    public void Delete()
    {
        Destroy(SuratCloser.instance.current.gameObject);
        currentIndex++;
        if (currentIndex == ListSurat.Count)
        {
            Read = false;
            MainUI.instance.Recover();
            currentIndex = 0;
        }
        isReading = false;
    }
}
