using UnityEngine;
using UnityEditor;
using System;
using System.IO;
public class MusicListCreator : EditorWindow
{
    AudioClip clip;
    Sprite Cover;
    string Name;
    string Artist;
    float BPM;

    [SerializeField]GameObject prefab;
    [SerializeField]Transform parentTransform;

    [MenuItem("Tools/Ripat/Tambah Musik")]
    public static void BuatMusikasdaw()
    {
        GetWindow<MusicListCreator>("Tambah Musik");
    }

    void OnGUI()
    {
        GUILayout.Label("Tambahkan musik ke dalam playlist", EditorStyles.boldLabel);
        clip = (AudioClip)EditorGUILayout.ObjectField("Sound Lagu", clip, typeof(AudioClip),false);
        Cover = (Sprite)EditorGUILayout.ObjectField("Gambar Cover",Cover, typeof(Sprite),false);
        Name = EditorGUILayout.TextField("Nama Lagu",Name);
        Artist = EditorGUILayout.TextField("Nama Artis", Artist);
        BPM = EditorGUILayout.FloatField("BPM", BPM);
        if (GUILayout.Button("Buat"))
        {
            CreateDataAsset();
        }
    }

    void CreateDataAsset()
    {
        // Make sure the folder exists
        string folderPath = "Assets/Bahan/Scriptable/MusicList";
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Create the asset
        Music asset = ScriptableObject.CreateInstance<Music>();
        asset.Nama = Name;
        asset.Artis = Artist;
        asset.Cover = Cover;
        asset.Sound = clip;
        asset.BPM = BPM;
        string assetPath = $"{folderPath}/{Name}.asset";
        AssetDatabase.CreateAsset(asset, assetPath);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

        Debug.Log($"Created ScriptableObject at {assetPath}");
    }

    void SpawnPrefab()
    {
        parentTransform = GameObject.Find("Content").transform;
        if (prefab == null)
        {
            Debug.LogWarning("No prefab assigned!");
            return;
        }

        // Create the prefab instance in the scene
        GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);

        if (parentTransform != null)
        {
            instance.transform.SetParent(parentTransform);
            instance.transform.localPosition = Vector3.zero;
            instance.transform.localRotation = Quaternion.identity;
            instance.transform.localScale = Vector3.one;
        }

        // Register undo so it can be undone with Ctrl+Z
        Undo.RegisterCreatedObjectUndo(instance, "Spawn Prefab");

        // Select the newly created object
        Selection.activeObject = instance;

        Debug.Log($"Spawned prefab '{prefab.name}' under '{(parentTransform ? parentTransform.name : "Scene Root")}'");
    }
}

