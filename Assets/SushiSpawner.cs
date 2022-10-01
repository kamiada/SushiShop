using UnityEngine;

public class SushiSpawner : MonoBehaviour
{
    public GameObject SushiPrefab;

    void Start()
    {
        Invoke("spawnSushi", 1f);
    }

    void spawnSushi()
    {
        GameObject spawnedSushi = Instantiate(SushiPrefab, transform.position, Quaternion.identity, transform);

        // Choose random sushi plate colour
        // TODO: Choose random sushi type too
        // TODO: Make random selection more scaleable
        int randVal = Random.Range(1, 4);

        switch (randVal)
        {
            case 1:
                spawnedSushi.GetComponent<Sushi>().SushiPlateColour = Sushi.PlateColour.Red;
                break;
            case 2:
                spawnedSushi.GetComponent<Sushi>().SushiPlateColour = Sushi.PlateColour.Blue;
                break;
            case 3:
                spawnedSushi.GetComponent<Sushi>().SushiPlateColour = Sushi.PlateColour.Green;
                break;
            default:
                break;
        }

        // Shoot out sushi
        spawnedSushi.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100f, 0f));
    }

    
}
