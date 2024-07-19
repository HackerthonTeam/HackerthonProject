using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cold : SpecialState
{
    public Cold()
    {
        duration = 120;
        name = "cold";
        description = "got cold. lowwer temperature durability, lowwer stemina";
    }

    public override void OnAdded()
    {
        base.OnAdded();
        player.PlayerData.Stemina *= 0.5f;
    }

    public override void OnRemoved()
    {
        player.PlayerData.Stemina /= 0.5f;
    }
}
