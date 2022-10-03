using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Minigame : MonoBehaviour
{
    public Sprite CurrentSushiSprite;
    public Button Button;
    public Slider Slider;
    public Animator KevinAnimator;
    //mini game vars 
    public float AreYouWinningSon = 0.0f;
    int randomIndex1;
    Random random = new Random();
    public Animator CustomerAnimator;
    float timer = 2f;

    private Image currentSushiImage;
    private Sushi minigameFocusedSushi;
    private bool miniGameStarted;
    static string[] keyNames = new string[] { "q", "b", "c", "f", "g", "h", "l", "k", "m", "n", "x", "z", "v", "r", "t", "p", "i" };
    public string key1;
    

    private void Awake()
    {        
        GameManager.Instance.MinigamePanel = gameObject;
        gameObject.SetActive(false);
    }
    private void Start()
    {
        currentSushiImage = transform.GetChild(1).GetComponent<Image>();
    }
    private void OnEnable()
    {
        miniGameStarted = true;
        randomIndex1 = random.Next(1, keyNames.Length);
        key1 = keyNames[randomIndex1];
        Button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = key1;
        minigameFocusedSushi = GameManager.Instance.PlayerCharacter.CurrentSushi;
        minigameFocusedSushi.GetComponent<Rigidbody2D>().simulated = false;
        Time.timeScale = 0.75f;        
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    public void UpdateMiniGame()
    {

        timer -= Time.deltaTime;
        if (Input.GetKeyDown(key1))
        {
            AreYouWinningSon = AreYouWinningSon + 20.0f;
            Slider.value += 0.2f;
            KevinAnimator.SetTrigger("Chomp");
        }
        //else if (!Input.GetKeyDown(key1))
        //{
        //    Debug.Log("loosing");
        //    AreYouWinningSon = AreYouWinningSon - 15.0f;
        //    Slider.value -= 0.1f;
        //    Debug.Log(AreYouWinningSon);
        //}

        if (AreYouWinningSon == 100.0f)
        {
            GameManager.Instance.PlayerCharacter.Weight += minigameFocusedSushi.WeightValue;
            GameManager.Instance.PlayerCharacter.Energy += minigameFocusedSushi.EnergyValue;
            GameManager.Instance.AddScore(minigameFocusedSushi.PointsValue);
            Destroy(minigameFocusedSushi.gameObject);
            CustomerAnimator.SetTrigger("Anger");
            endMinigame();

            //Customer will leave somewhere here
        }

    }

    private void Update()
    {
        if (miniGameStarted)
        {
            UpdateMiniGame();
        }
        if (timer <= 0.0f)
        {
            endMinigame();
        }
    }

    void endMinigame()
    {
        miniGameStarted = false;
        timer = 4.0f;
        Time.timeScale = 1f;
        GameManager.Instance.MinigamePanel.SetActive(false);
        AreYouWinningSon = 0f;
        KevinAnimator.transform.localScale = new Vector3(1f, 1f, 1f);
        Slider.value = 0f;
    }
}
