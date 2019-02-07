/// <summary>
/// TimeTickable is the tickable responsible to handle the time evolution in
/// the game
/// </summary>
public class TimeTickable : ITickable {

    private Game game = Game.Instance;
    private int tickNb = 0;

    public void onTick() {
        if (++tickNb == game.Config.TickNbPerDay)
        {
            game.Data.GameDate.NextDay();
            tickNb = 0;
        }
    }

    public void Dispose() {

    }
}

