using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
[ExecuteAlways]
public class MusicListGenerator : MonoBehaviour
{
    RectTransform rect;
    public Music[] musics;
    [SerializeField] GameObject prefab;
    MusicList ml;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        rect = GetComponent<RectTransform>();
        ml = GetComponent<MusicList>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("Generate ulang isi musik di UI")]
    public void Refresh()
    {
        //proses menghapus button musik sebelumnya agar bersih
        MusicObject[] queueddestroy = GetComponentsInChildren<MusicObject>();
        foreach(MusicObject mobj in queueddestroy)
        {
            DestroyImmediate(mobj.gameObject);
        }
        ml.musics = new MusicObject[musics.Length];
        //mengkalkulasi lebar viewport & generate button musik
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, ((musics.Length * 100) + (musics.Length * 20)));
        for(int i = 0; i < musics.Length; i++)
        {
            

            GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
            RectTransform robj = obj.GetComponent<RectTransform>();
            robj.anchoredPosition = new Vector2(0, -50 - (120 * i));
            obj.name = i.ToString();
            MusicObject mobj = obj.GetComponent<MusicObject>();
            mobj.Cover.sprite = musics[i].Cover;
            mobj.Name.text = musics[i].Nama;
            mobj.Artist.text = musics[i].Artis;
            mobj.Sound = musics[i].Sound;
            mobj.BPM = musics[i].BPM;

            ml.musics[i] = mobj;
        }
    }


}
