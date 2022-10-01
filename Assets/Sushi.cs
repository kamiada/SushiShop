using UnityEngine;

public class Sushi : MonoBehaviour
{
    public enum PlateColour
    {
        Red = 0,
        Blue,
        Green,
    }
    public PlateColour SushiPlateColour;
    public float Weight = 0.5f;

    private bool playerInRadius = false;

    //mini game vars 
    public float AreYouWinningSon = 0.0f;
    public float points = 15.0f;
    float timer = 10.0f;
    public string[] keyNames;
    public string key = "";
    

    private void Start()
    {
        // Manage the colour of the sushi plate (to start different minigames)
        switch (SushiPlateColour)
        {
            case PlateColour.Red:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case PlateColour.Blue:
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case PlateColour.Green:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            default:
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRadius = true;
            collision.GetComponent<PlayerCharacter>().CurrentSushi = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRadius = false;
            collision.GetComponent<PlayerCharacter>().CurrentSushi = null;
        }
    }

    public void Interact()
    {
        if (playerInRadius)
        {
            // Debug.Log("Start minigame... Destroy for now");
            // Destroy(gameObject);
            Debug.Log("Minigame: mash correct buttons and delicious sushi!");
        }
    }
}
