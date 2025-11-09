using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MusicObject : MonoBehaviour
{
    public Image Cover;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Artist;
    public AudioClip Sound;
    public float BPM;
    public void Clicked()
    {
        MusicPlayer.Instance.SetMusic(GetComponent<MusicObject>());
    }
}
