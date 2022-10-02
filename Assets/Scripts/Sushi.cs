using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Sushi : MonoBehaviour
{ 
    int randomIndex1;
    int randomIndex2;
    Random random = new Random();

    public enum PlateColour
    {
        Red = 0,
        Blue,
        Green,
    }
    public PlateColour SushiPlateColour;
    public float WeightValue = 0.5f;
    public float EnergyValue = 25f;

    private bool playerInRadius = false;

    //mini game vars 
    public float AreYouWinningSon = 0.0f;
    public float points = 15.0f;
    float timer = 4.0f;
    static string[] keyNames = new string[] { "space", "q", "e", "b", "c", "f", "g", "h", "l", "k", "m", "n","x", "z", "v", "r", "t", "p", "i"};

    public string key1;
    public string key2;
    public PlayerCharacter Player;
    private IEnumerator coroutine;
    public bool startMiniGame = false;


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

    public void Update()
    {
        if(startMiniGame) {
            timer -= Time.deltaTime;
        }
        if(timer <= 0.0f) {
            startMiniGame = false;
            timer = 4.0f;
        }

    }

    public void StartMiniGameCoroutine ()
    {
        StartCoroutine(WaitAndPrint());
        IEnumerator WaitAndPrint()
        {
            while (startMiniGame)
            {
                yield return new WaitForSecondsRealtime(2);
                randomIndex1 = random.Next(1, keyNames.Length);
                randomIndex2 = random.Next(1, keyNames.Length);
                key1 = keyNames[randomIndex1];
                key2 = keyNames[randomIndex2];
                Debug.Log("Smash " + key1 + " and " + key2);
            }
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
        // Temporarily adding weight and energy to test balance, as if winning minigame
        GameManager.Instance.PlayerCharacter.Energy += EnergyValue;
        GameManager.Instance.PlayerCharacter.Weight += WeightValue;

        if (playerInRadius)
        {
            Debug.Log("Minigame: mash correct buttons and delicious sushi!");
            //every 2 seconds print different keys, if player hits correctly add points, otherwise remove them
            startMiniGame = true;
            StartMiniGameCoroutine();
            Debug.Log("Players points " + AreYouWinningSon);
            Debug.Log("In interact the keys is " + key1);
            if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2)) {
                Debug.Log("winning");
                AreYouWinningSon += 20.0f;
            } else {
                Debug.Log("loosing");
                AreYouWinningSon -= 15.0f;
            }
            Debug.Log("What time is it? " + timer);
            if(timer <= 0.0f) {
                if (AreYouWinningSon >= 100.0f) {
                    Player.Weight += WeightValue;
                    Debug.Log("lost the minigame");
                    Destroy(gameObject);
                    //Customer will leave somewhere here
                }
                startMiniGame = false;
            }
        }
    }
}
