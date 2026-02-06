using UnityEngine;

public class mainSong : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioClip mainMusic;
    private void Awake()
    {
        gameObject.GetComponent<AudioSource>().clip = mainMusic;
    }
    void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
