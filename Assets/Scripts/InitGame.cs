using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.PlayerCharacter = FindObjectOfType<PlayerCharacter>();
        GameManager.Instance.ConveyorBeltSetup = FindObjectOfType<ConveyorBeltSetup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
