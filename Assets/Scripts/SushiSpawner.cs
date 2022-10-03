using System.Collections;
using UnityEngine;

public class SushiSpawner : MonoBehaviour
{
    public GameObject SushiPrefab;
    public float SpawnDelay = 2f;

    public FMODUnity.EventReference sound;

    void Start()
    {
        //InvokeRepeating("spawnSushi", 1f, SpawnDelay);
        StartCoroutine("SushiSpawnCoroutine");
        GameManager.Instance.SushiSpawner = this;
    }

    void spawnSushi()
    {
        GameObject spawnedSushi = Instantiate(SushiPrefab, transform.position, Quaternion.identity, transform);

        // Choose random sushi plate colour
        // TODO: Choose random sushi type too
        // TODO: Make random selection more scaleable
        int randPlate = Random.Range(1, 4);

        switch (randPlate)
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
        spawnedSushi.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200f, 0f));

        FMODUnity.RuntimeManager.PlayOneShot(sound);
    }  


    IEnumerator SushiSpawnCoroutine()
    {
        spawnSushi();
        yield return new WaitForSeconds(SpawnDelay);
        StartCoroutine("SushiSpawnCoroutine");
    }
}
