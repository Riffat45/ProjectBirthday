using UnityEngine;

[CreateAssetMenu(fileName = "Musik", menuName = "Riffat/Musik")]
public class Music : ScriptableObject
{
    public string Nama;
    public string Artis;
    public AudioClip Sound;
    public Sprite Cover;
    public float BPM;
}
