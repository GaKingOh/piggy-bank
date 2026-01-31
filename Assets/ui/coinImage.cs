using UnityEngine;
using UnityEngine.UI;
public class coinImage : MonoBehaviour
{
    [Header("Frames (0..n-1)")]
    public Sprite[] frames;

    [Header("Playback")]
    [Min(1f)] public float fps = 12f;
    public bool playOnEnable = true;

    private Image img;
    private int index;
    private float timer;
    private bool playing;

    void Awake()
    {
        img = GetComponent<Image>();
    }

    void OnEnable()
    {
        if (playOnEnable) Play(true);
    }

    void Update()
    {
        if (!playing || frames == null || frames.Length == 0) return;

        timer += Time.unscaledDeltaTime; // UI는 보통 unscaled가 편함
        float frameTime = 1f / fps;

        while (timer >= frameTime)
        {
            timer -= frameTime;
            index = (index + 1) % frames.Length;
            img.sprite = frames[index];
        }
    }

    public void Play(bool restart = false)
    {
        playing = true;
        if (restart)
        {
            index = 0;
            timer = 0f;
            if (frames != null && frames.Length > 0) img.sprite = frames[0];
        }
    }

    public void Stop(bool resetToFirst = false)
    {
        playing = false;
        if (resetToFirst && frames != null && frames.Length > 0)
            img.sprite = frames[0];
    }
}
