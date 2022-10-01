using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // For each conveyor belt section, assign its Next Section to be the next child down in the hierarchy
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<ConveyorBeltSection>() == null)
                return;
            
            transform.GetChild(i).GetComponent<ConveyorBeltSection>().NextSection = transform.GetChild(i + 1).gameObject;
        }

        // Go through them and set the "Next Section" field to the next one down
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
