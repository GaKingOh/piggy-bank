using UnityEngine;

public class musicPlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip bgm;
    [SerializeField] private AudioClip gameOver;


    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        audioSource.clip = bgm;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void GameOver()
    {
        audioSource.clip = gameOver;
        audioSource.loop = false;
        audioSource.Play();
    }
}
