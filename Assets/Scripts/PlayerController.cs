using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Referencias:")]
    [SerializeField] private Animator animator;
    
    private Rigidbody2D rigidbody2D;
    private float forceJump = 10;
    private bool isGround = true;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.G)) // SOLO PARA PROBAR EMPEZAR A CORRER
        {
            animator.SetBool("IsRunning", true);
        }

        if (Input.GetKeyUp(KeyCode.F)) // SOLO PARA PROBAR CAERSE
        {
            animator.SetBool("DidFall", true);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGround)
        {
            isGround = false;
            rigidbody2D.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGround = true;
            animator.SetBool("IsJumping", false);
        }
    }
}
