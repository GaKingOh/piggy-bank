using UnityEngine;

public class footChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject player;
    float radius = 0.05f;
    bool foot_obstacle = false;
    [SerializeField] private LayerMask obstacle;

    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool FootAndObstacle()
    {
        return foot_obstacle;
    }
    public void SetFootAndObstacle()
    {
        foot_obstacle = false;
    }
    void OnTriggerEnter2D(Collider2D collision) // 충돌 순간
    {
        if(collision.CompareTag("Ground"))
        {
            player.GetComponent<runController>().isground = true;
        }
        if ((obstacle & (1 << collision.gameObject.layer)) != 0)
        {
            foot_obstacle = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision) // 충돌 끝났을 때
    {
        if (collision.CompareTag("Ground"))
        {
            player.GetComponent<runController>().isground = false;
        }
        foot_obstacle = false;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
