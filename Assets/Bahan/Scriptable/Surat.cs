using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Surat", menuName = "Riffat/Surat")]
public class Surat : ScriptableObject
{
    public TextAsset Paragraph;
    public SuratObject PrefabTemplate;
}
