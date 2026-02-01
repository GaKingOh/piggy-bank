using UnityEngine;
using UnityEngine.InputSystem;

public class fallController : MonoBehaviour
{
    [SerializeField] float FallSpeed = 0f;
    public Animator animator;
    Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<runController>().isground && Keyboard.current.vKey.wasPressedThisFrame)
        {
            Debug.Log("¾ÈµÊ");
            animator.SetBool("isjump", false);
            animator.SetBool("isfall", true);
            Debug.Log(animator.GetBool("isfall"));
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
