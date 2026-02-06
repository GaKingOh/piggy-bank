using UnityEngine;

public class audioController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip coin;
    [SerializeField] private AudioClip explosion;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip fart;
    [SerializeField] private AudioClip hit;
    void Start()
    {

    }

    // Update is called once per frame
    public void GetCoin() // 코인 먹을 때 소리
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(coin, 0.6f);
    }
    public void Explode() // 미사일 맞을 때 소리
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(explosion, 0.6f);
    }
    public void Jump() // 점프 소리
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(jump, 0.6f);
    }
    public void Fart()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(fart, 0.6f);
    }
    public void Hit()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(hit, 0.6f);
    }
    void Update()
    {

    }
}
