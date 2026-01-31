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

    void Start()
    {
        animator.SetBool("iswalk", true);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isground)
        {
            animator.SetBool("isjump", false);
            animator.SetBool("iswalk", true);
            jumpCount = 0;
        }
        if(Keyboard.current.spaceKey.wasPressedThisFrame && jumpCount < maxJumpCount)
        {
            isground = false;
            animator.SetBool("isjump", true);
            animator.SetBool("iswalk", false);
            jumpCount++;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);    
        }
    }
}
