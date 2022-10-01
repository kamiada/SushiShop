using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public KeyCode InteractKey;
    public KeyCode AttackKey;
    public Sushi CurrentSushi;
    public float Speed = 0.5f;
    public float Weight = 0.5f; // Each sushi
    public float AttackForce = 50f;

    Rigidbody2D rigidbody2D;
    Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        // Move the character on a 2D plane
        // Must be in FixedUpdate as uses Rigidbodies
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        rigidbody2D.AddForce(new Vector2(horizontalAxis, verticalAxis) * (Speed / Weight));

        ManageSpriteFlipping(horizontalAxis, verticalAxis);
    }

    private void Update()
    {
        HandleControls();
    }

    private void HandleControls()
    {
        if (Input.GetKeyDown(InteractKey))
        {
            // Are we near a sushi?
            if (CurrentSushi == null)
                return;

            // Add weight and manage fatness sprite
            Weight += CurrentSushi.Weight;
            switch (Weight)
            {
                case 1.0f:
                    animator.SetLayerWeight(1, 1.0f);
                    break;
                case 2.0f:
                    animator.SetLayerWeight(2, 1.0f);
                    break;
                default:
                    break;
            }

            // If we're near a sushi, interact with it
            CurrentSushi.Interact();     

        }

        if (Input.GetKeyDown(AttackKey))
        {
            animator.SetTrigger("Attack");
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2f);

            foreach (var hit in hits)
            {
                if (hit.GetComponent<Sushi>() != null)
                {
                    Vector2 attackForce = hit.transform.position - transform.position;
                    hit.GetComponent<Rigidbody2D>().AddForce(attackForce.normalized * AttackForce);
                }
            }
        }
    }

    void ManageSpriteFlipping(float horizontalAxis, float verticalAxis)
    {
        if (horizontalAxis != 0 || verticalAxis != 0)
        {
            animator.SetBool("IsWalking", true);

            if (horizontalAxis < 0) // If moving left, flip sprite
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            if (horizontalAxis > 0)
                GetComponentInChildren<SpriteRenderer>().flipX = false;
        }

        else
            animator.SetBool("IsWalking", false);
    }
}
