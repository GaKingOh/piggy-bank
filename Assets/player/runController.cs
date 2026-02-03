using UnityEngine;
using UnityEngine.InputSystem;

public class runController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator;
    Rigidbody2D rb;
    float jumpPower = 7.0f; 
    public bool isground = true; // 땅에 붙어있는지 확인
    [SerializeField] private int maxJumpCount = 2; // 연속 점프 횟수
    private int jumpCount = 0;


    GameObject playerAudio; // 플레이어 점프 소리
    Vector3 init;
    private void Awake()
    {
        init = transform.position;
    }
    void Start()
    {
        animator.SetBool("iswalk", true);
        rb = GetComponent<Rigidbody2D>();
        playerAudio = GameObject.Find("playerAudio");
    }

    // Update is called once per frame
    void Update()
    {
        if(init.y > transform.position.y) transform.position = init;
        if (isground)
        {
            animator.SetBool("isjump", false);
            animator.SetBool("iswalk", true);
            jumpCount = 0;
        }
        if(Keyboard.current.spaceKey.wasPressedThisFrame && jumpCount < maxJumpCount) // jump
        {
            isground = false;
            animator.SetBool("isjump", true);
            animator.SetBool("iswalk", false);
            jumpCount++;
            playerAudio.GetComponent<audioController>().Jump(); // 점프 소리 출력
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);    
        }
    }
}
