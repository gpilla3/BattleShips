
//Used to manage the AI and user turns
public class TurnManager : Singleton<TurnManager>
{
    private bool AIturn = false;

    public bool AIturn1 { get => AIturn; set => AIturn = value; }
}
