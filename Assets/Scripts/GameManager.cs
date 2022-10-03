using UnityEngine;

public class GameManager : GenericSingletonClass<GameManager>
{
    public PlayerCharacter PlayerCharacter;
    public ConveyorBeltSetup ConveyorBeltSetup;
    public SushiSpawner SushiSpawner;
    public GameObject GameOverPanel;
    public GameObject WinPanel;
    public bool GameEnded = false;
    public TMPro.TextMeshProUGUI ScoreText;
    public GameObject MinigamePanel;

    public int Score { get; private set; }
    public int WinScore = 500;
    public int Level1Score = 100;
    public int Level2Score = 250;
    public int Level3Score = 400;
    public float WeightDefeatValue = 10.0f;

    public float GetPlayerStat(string stat)
    {
        switch (stat)
        {
            case "Weight":
                return PlayerCharacter.Weight;
            case "Energy":
                return PlayerCharacter.Energy;
            default:
                return 0f;
        }
    }

    public void GameOver()
    {
        GameEnded = true;
        // Set death animation

        // Show Game Over UI
        Instantiate(GameOverPanel, FindObjectOfType<Canvas>().transform);
    }

    void WinGame()
    {
        Destroy(PlayerCharacter);

        Instantiate(WinPanel, FindObjectOfType<Canvas>().transform);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        ScoreText.text = "Score: " + Score;

        if (Score >= WinScore )
        {
            WinGame();
        }
        else if (Score >= Level3Score)
        {
            SetDifficulty(20f, 0.5f);
        }
        else if( Score >= Level2Score)
        {
            SetDifficulty(15f, 1.0f);
        }
        else if(Score >= Level1Score)
        {
            SetDifficulty(12f, 1.5f);
        }
    }

    public void ResetGame()
    {
        Score = 0;
        GameEnded = false;
    }

    void SetDifficulty(float beltSpeed, float sushiSpawnDelay)
    {
        ConveyorBeltSetup.SetAllConveyorBeltsSpeed(beltSpeed);
        SushiSpawner.SpawnDelay = sushiSpawnDelay;
    }
}
