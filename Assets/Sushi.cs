using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Sushi : MonoBehaviour
{ 
    public int randomIndex1;
    public int randomIndex2;

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
    public string[] keyNames = { "space", "q", "w", "e", "a", "b", "c", "d", "f", "g", "h", "l", "k", "m", "n","x", "z", "v", "r", "t", "p", "i"};
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
        coroutine = WaitAndPrint(2.0f);
        StartCoroutine(coroutine);
        IEnumerator WaitAndPrint(float waitTime)
        {
            Debug.Log("start mini game bool" + startMiniGame);
            while (startMiniGame)
            {
                yield return new WaitForSeconds(waitTime);
                randomIndex1 = Random.Range(0, keyNames.Length); 
                randomIndex2 = Random.Range(0, keyNames.Length); 
                key1 = keyNames[randomIndex1];
                key2 = keyNames[randomIndex2];
                Debug.Log(key1 + " " + key2);
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
        if (playerInRadius)
        {
            // Debug.Log("Start minigame... Destroy for now");
            // Destroy(gameObject);
            Debug.Log("Minigame: mash correct buttons and delicious sushi!");
            startMiniGame = true;
            timer -= Time.deltaTime;
            Debug.Log("Current Time" + timer);

            //every 2 seconds print different keys, if player hits correctly add points, otherwise remove them
            
            if(Input.GetKeyDown(key1) && Input.GetKeyDown(key2)) {
                AreYouWinningSon += 20.0f;
            } else {
                AreYouWinningSon -= 15.0f;
            }

            if(timer <= 0.0f) {
                if (AreYouWinningSon >= 100.0f) {
                    Player.Weight += Weight;
                    Destroy(gameObject);
                    //Customer will leave somewhere here
                }
            }
        }
    }
}
