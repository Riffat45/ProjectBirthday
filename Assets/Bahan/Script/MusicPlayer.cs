using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance { get; private set; }
    public AudioClip clip;
    public AudioSource source;
    public bool Read;

    [SerializeField] Slider Time;
    public int playbackType;
    MusicObject currentMusicobj;

    [SerializeField] TextMeshProUGUI Nama;
    [SerializeField] TextMeshProUGUI Artis;
    [SerializeField] Image Cover;
    [SerializeField] PlayerButton[] Buttons;

    [SerializeField] Sprite[] PlaySprites;
    [SerializeField] Sprite[] PlaybackTypeSprites;
    [SerializeField]MusicList ml;

    bool musicwasplaying;

    bool avoidcheck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        avoidcheck = true;
    }
    private void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Read == true)
        {
            Time.value = source.time / source.clip.length;
        }
        if (source.isPlaying == false && musicwasplaying == true)
        {
            musicwasplaying = false;
            switch (playbackType)
            {
                case 0:
                    avoidcheck = false;
                    ml.musics[Random.Range(0, ml.musics.Length)].Clicked();
                    avoidcheck = true;
                    break;
                case 1:
                    RunCommand("Next");
                    break;
                case 2:
                    avoidcheck = false;
                    currentMusicobj.Clicked();
                    avoidcheck = true;
                    break;
            }
        }
    }

    public void SetMusic(MusicObject sender)
    {
        if (avoidcheck == true)
        {
            if (currentMusicobj != sender)
            {
                currentMusicobj = sender;
                Read = true;
                Cover.sprite = sender.Cover.sprite;
                Nama.text = sender.Name.text;
                Artis.text = sender.Artist.text;
                source.clip = sender.Sound;
                Play();
                source.GetComponent<BpmSender>().BPM = sender.BPM;
                source.GetComponent<BpmSender>().Send = true;
                source.GetComponent<BpmSender>().ReSync();
                musicwasplaying = true;
            }
        }
        else
        {
            currentMusicobj = sender;
            Read = true;
            Cover.sprite = sender.Cover.sprite;
            Nama.text = sender.Name.text;
            Artis.text = sender.Artist.text;
            source.clip = sender.Sound;
            Play();
            source.GetComponent<BpmSender>().BPM = sender.BPM;
            source.GetComponent<BpmSender>().Send = true;
            source.GetComponent<BpmSender>().ReSync();
            musicwasplaying = true;
        }
    }
    public void TimeSliderEvent(int type)
    {
        if (type == 0)
        {
            Read = false;
        }
        else if (type == 1)
        {
            source.time = Time.value * source.clip.length;
            Read = true;
        }
    }
    public void RunCommand(string command)
    {
            switch (command)
            {
                case "Play":
                    if (source.isPlaying == true)
                    {
                        Buttons[2].Image.sprite = PlaySprites[0];
                        source.Pause();
                    }
                    else if (source.isPlaying == false)
                    {
                        Buttons[2].Image.sprite = PlaySprites[1];
                        source.UnPause();
                    }
                    break;
                case "Next":
                if (int.Parse(currentMusicobj.name) == ml.musics.Length - 1)
                {
                    ml.musics[0].Clicked();
                }
                else
                {
                    ml.musics[int.Parse(currentMusicobj.name) + 1].Clicked();
                }
                break;
                case "Previous":
                if (int.Parse(currentMusicobj.name) == 0)
                {
                    ml.musics[ml.musics.Length - 1].Clicked();
                }
                else
                {
                    ml.musics[int.Parse(currentMusicobj.name) - 1].Clicked();
                }
                break;
                case "SetPlayback":
                    playbackType++;
                    if (playbackType > 2)
                    {
                        playbackType = 0;
                    }
                Buttons[0].Image.sprite = PlaybackTypeSprites[playbackType];
                break;
            }
    }

    void Play()
    {
        source.Play();
        Buttons[2].Image.sprite = PlaySprites[1];
    }
}
