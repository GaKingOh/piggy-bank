using Unity.VisualScripting;
using UnityEngine;

public class rocketController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Animator animator;
    public float speed = 1f;
    [SerializeField]
    private GameObject explosionPrefab;
    GameObject player;
    GameObject playerAudio;
    float lifeTime = 15;
    Vector3 dir;
    void Start()
    {
        player = GameObject.Find("player");
        playerAudio = GameObject.Find("playerAudio");
        Launch(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;
    }

    public void Launch(Vector3 targetPos)
    {
        dir = (targetPos - transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 180f);

        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            animator.SetBool("isexplosion", true);
            playerAudio.GetComponent<audioController>().Explode();
            player.GetComponent<playerHpController>().getDamage();
            Instantiate(explosionPrefab,player.transform.position,Quaternion.identity,player.transform);
            Destroy(gameObject);
        }
    }
}
