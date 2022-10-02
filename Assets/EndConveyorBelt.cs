using UnityEngine;

public class EndConveyorBelt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sushi")
            Destroy(collision.gameObject);        
    }
}
