public class RadiationExposure : SpecialState
{
    public RadiationExposure()
    {
        duration = 9999999;
        name = "Radiation Exposure";
        description = "Got Radiation Exposure. lowwer HP, lowwer Stemina, lowwer temperature durability, increase hunger";
    }

    public override void OnAdded()
    {
        base.OnAdded();
        player.PlayerData.Health*=0.7f;
        player.PlayerData.Stemina*=0.7f;
        player.PlayerData.Hunger*=0.7f;
    }
    public override void OnUpdated()
    {
        base.OnUpdated();
        player.PlayerData.Health -=0.2f;
        player.PlayerData.Hunger -=0.2f;
    }

    public override void OnRemoved()
    {
        player.PlayerData.Hunger /= 0.7f;
        player.PlayerData.Stemina/=0.7f;
        player.PlayerData.Health/=0.7f;
    }
}
