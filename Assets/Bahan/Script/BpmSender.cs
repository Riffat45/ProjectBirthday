using UnityEngine;

public class BpmSender : MonoBehaviour
{
    public float BPM;
    float SPB;
    float nextBeatTime;
    public bool Send;

    [SerializeField]BpmReceiver[] receivers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SPB = 60f / BPM;
    }

    public void ReSync()
    {
        SPB = 60f / BPM;
        nextBeatTime = Time.time + SPB;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Send)
        {
            if (Time.time >= nextBeatTime)
            {
                foreach (BpmReceiver rcv in receivers)
                {
                    rcv.OnBeat(); // panggil metode saat beat terjadi
                }
                // Hitung waktu beat berikutnya
                nextBeatTime += SPB;
            }
        }
    }

}
