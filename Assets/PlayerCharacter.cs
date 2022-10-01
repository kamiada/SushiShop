using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public KeyCode InteractKey;
    public Sushi CurrentSushi;
    public float Speed = 0.5f;
    public float Weight = 0.5f; // Each sushi

    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move the character on a 2D plane
        // Must be in FixedUpdate as uses Rigidbodies
        rigidbody2D.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * (Speed / Weight));
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
}