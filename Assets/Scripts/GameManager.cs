public class GameManager : GenericSingletonClass<GameManager>
{
    public PlayerCharacter PlayerCharacter;
    public ConveyorBeltSetup ConveyorBeltSetup;

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
}
