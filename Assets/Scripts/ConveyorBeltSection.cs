using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltSection : MonoBehaviour
{
    public float BeltForce = 100f;
    public GameObject NextSection;
    [SerializeField] private Rigidbody2D currentSushiRb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ConveyorBeltDetector")
        {
            currentSushiRb = collision.GetComponentInParent<Rigidbody2D>();
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (currentSushiRb == null)
            return;
        
        if (collision.gameObject == currentSushiRb.gameObject)
        {
            currentSushiRb = null;
        }
    }

    private void FixedUpdate()
    {
        if (currentSushiRb == null)
            return;
        
        Vector3 nextBeltDirection = NextSection.transform.position - currentSushiRb.transform.position;
        currentSushiRb.AddForce(nextBeltDirection.normalized * BeltForce);        
    }
}
