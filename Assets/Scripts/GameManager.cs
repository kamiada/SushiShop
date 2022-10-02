using UnityEngine;

public class GameManager : GenericSingletonClass<GameManager>
{
    public PlayerCharacter PlayerCharacter;
    public ConveyorBeltSetup ConveyorBeltSetup;
    public GameObject GameOverPanel;
    public GameObject WinPanel;
    public bool GameEnded = false;
    public TMPro.TextMeshProUGUI ScoreText;

    public int Score { get; private set; }
    public int WinScore = 100;

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
    }

    public void ResetGame()
    {
        Score = 0;
        GameEnded = false;
    }
}
