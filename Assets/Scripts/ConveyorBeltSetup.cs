using UnityEngine;

public class ConveyorBeltSetup : MonoBehaviour
{
    delegate void Action(int i);
    private float speed;
    public float Speed = 9f;

    void Start()
    {
        IterateOverConveyorBelts(SetNextConveyorBeltSection);
    }

    void IterateOverConveyorBelts(Action action)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<ConveyorBeltSection>() == null)
                return;

            // Go through them and do something
            action(i);
        }
    }

    void SetNextConveyorBeltSection(int i)
    {
        // Go through conveyor belts and set the "Next Section" field to the next one down
        transform.GetChild(i).GetComponent<ConveyorBeltSection>().NextSection = transform.GetChild(i + 1).gameObject;
    }

    void SetConveyorBeltSpeed(int i)
    {
        // Go through conveyor belts and set the speed
        transform.GetChild(i).GetComponent<ConveyorBeltSection>().BeltForce = Speed;
    }

    public void SetAllConveyorBeltsSpeed(float speed)
    {
        Speed = speed;
        IterateOverConveyorBelts(SetConveyorBeltSpeed);
    }

    private void Update()
    {
        // TODO: REMOVE AS FOR TESTING
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetAllConveyorBeltsSpeed(Speed + 5f);
        }
    }
}
