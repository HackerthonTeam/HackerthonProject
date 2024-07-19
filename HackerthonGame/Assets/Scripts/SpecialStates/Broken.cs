using UnityEngine;

public class Broken : SpecialState
{
    private Vector3 prePos;
    public Broken()
    {
        prePos = player.transform.position;
        duration = 200;
        name = "Broken bone";
        description = "got bone broken. lowwer movement speed,lowwer stemina";
    }
    public override void OnAdded()
    {
        base.OnAdded();

        player.PlayerData.MoveSpeed *= 0.7f;
        player.PlayerData.Stemina *= 0.5f;
    }
    public override void OnUpdated()
    {
        base.OnUpdated();
        if(player.transform.position!=prePos){
            player.PlayerData.Health-=0.2f;
            prePos = player.transform.position;
        }
    }
    public override void OnRemoved()
    {
        player.PlayerData.MoveSpeed /= 0.7f;
        player.PlayerData.Stemina /= 0.5f;
    }

}
