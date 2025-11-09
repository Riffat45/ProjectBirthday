using UnityEngine;

public class FirstMusicStarter : MonoBehaviour
{
    MusicList musicList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicList = GetComponent<MusicList>();
    }
    public void StartMusic()
    {
        musicList.musics[0].Clicked();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
