using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public KeyCode InteractKey;
    public Sushi CurrentSushi;
    public float Speed = 0.5f;
    public float Weight = 0.5f; // Each sushi

    Rigidbody2D rigidbody2D;
    Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

            // Add weight
            Weight += CurrentSushi.Weight;
            Debug.Log(Weight);

            // If we're near a sushi, interact with it
            CurrentSushi.Interact();
        }
    }

    void ManageSpriteFlipping(float horizontalAxis, float verticalAxis)
    {
        if (horizontalAxis != 0 || verticalAxis != 0)
        {
            animator.SetBool("IsWalking", true);

            if (horizontalAxis < 0) // If moving left, flip sprite
                GetComponent<SpriteRenderer>().flipX = true;
            if (horizontalAxis > 0)
                GetComponent<SpriteRenderer>().flipX = false;
        }

        else
            animator.SetBool("IsWalking", false);
    }
}
