using UnityEngine;

public class GameManager : GenericSingletonClass<GameManager>
{
    public PlayerCharacter PlayerCharacter;
    public ConveyorBeltSetup ConveyorBeltSetup;
    public GameObject GameOverPanel;
    public bool GameEnded = false;

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
        // Disable player controller

        // Show Game Over UI
        Instantiate(GameOverPanel, FindObjectOfType<Canvas>().transform);
    }
}
