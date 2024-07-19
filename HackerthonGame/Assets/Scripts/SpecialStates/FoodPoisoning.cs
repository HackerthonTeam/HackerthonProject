public class FoodPoisoning : SpecialState
{
    public FoodPoisoning()
    {
        duration = 120;
        name = "Food Poisoning";
        description = "Got food poisoning. increase hunger and lowwer HP";
    }

    public override void OnAdded()
    {
        base.OnAdded();
        player.PlayerData.MoveSpeed*=0.7f;
        player.PlayerData.Stemina*=0.7f;
    }
    public override void OnUpdated()
    {
        base.OnUpdated();
        player.PlayerData.Hunger -=0.2f;
    }

    public override void OnRemoved()
    {
        player.PlayerData.Hunger /= 0.7f;
        player.PlayerData.Stemina*=0.7f;
    }
}
