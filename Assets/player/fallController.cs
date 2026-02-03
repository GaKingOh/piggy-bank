using UnityEngine;
using UnityEngine.InputSystem;

public class fallController : MonoBehaviour
{
    [SerializeField] float FallSpeed = 0f;
    public Animator animator;
    Rigidbody2D rb;
    GameObject playerAudio;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAudio = GameObject.Find("playerAudio");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<runController>().isground && Keyboard.current.vKey.wasPressedThisFrame)
        {
            animator.SetBool("isjump", false);
            animator.SetBool("isfall", true);
            playerAudio.GetComponent<audioController>().Fart(); // 방귀 소리 출력
            rb.linearVelocity = new Vector2(0f, -FallSpeed);
        }
        else if(gameObject.GetComponent<runController>().isground)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("isfall", false);
            animator.SetBool("iswalk", true);
        }
    }
}
