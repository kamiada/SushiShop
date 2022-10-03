using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Sushi : MonoBehaviour
{


    public enum PlateColour
    {
        Red = 0,
        Blue,
        Green,
    }
    public PlateColour SushiPlateColour;
    public float WeightValue = 0.5f;
    public float EnergyValue = 25f;
    public int PointsValue = 15;

    private bool playerInRadius = false;



    public PlayerCharacter Player;
    private IEnumerator coroutine;
    public bool startMiniGame = false;

    public Sprite[] PlateSprites;
    public Sprite[] SushiSprites;


    private void Start()
    {
        SpriteRenderer plateSpriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        SpriteRenderer sushiSpriteRenderer = GetComponent<SpriteRenderer>();

        int randSushi = UnityEngine.Random.Range(0, 3);

        // Manage the colour of the sushi plate (to start different minigames)
        switch (SushiPlateColour)
        {
            case PlateColour.Red:
                plateSpriteRenderer.sprite = PlateSprites[0];
                sushiSpriteRenderer.sprite = SushiSprites[randSushi];
                PointsValue = 15;
                break;
            case PlateColour.Blue:
                plateSpriteRenderer.sprite = PlateSprites[1];
                sushiSpriteRenderer.sprite = SushiSprites[3 + randSushi];
                PointsValue = 25;
                break;
            case PlateColour.Green:
                plateSpriteRenderer.sprite = PlateSprites[2];
                sushiSpriteRenderer.sprite = SushiSprites[6 + randSushi];
                PointsValue = 50;
                break;
            default:
                break;
        }
    }

    public void Update()
    {

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRadius = true;
            if (collision.GetComponent<PlayerCharacter>() != null)
                collision.GetComponent<PlayerCharacter>().CurrentSushi = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRadius = false;
            if (collision.GetComponent<PlayerCharacter>() != null)
                collision.GetComponent<PlayerCharacter>().CurrentSushi = null;
        }
    }

    public void Interact()
    {
        // Temporarily adding weight and energy to test balance, as if winning minigame
        //GameManager.Instance.PlayerCharacter.Energy += EnergyValue;
        //GameManager.Instance.PlayerCharacter.Weight += WeightValue;
        //GameManager.Instance.AddScore(PointsValue);
        //Destroy(gameObject);

        if (playerInRadius)
        {
            Debug.Log("Minigame: mash correct buttons and delicious sushi!");
            //every 2 seconds print different keys, if player hits correctly add points, otherwise remove them
            startMiniGame = true;
            // Make Panel Appear
            GameManager.Instance.MinigamePanel.SetActive(true);
        }
    }
}
