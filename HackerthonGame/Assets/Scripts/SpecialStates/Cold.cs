using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cold : SpecialState
{
    public Cold()
    {
        duration = 120;
        name = "감기";
        description = "추위를 더 많이 느끼고 기력이 감소합니다.";
    }

    public override void OnAdded()
    {
        base.OnAdded();

        player.PlayerData.TemperatureDurability *= 0.7f;
        player.PlayerData.Stemina *= 0.5f;
    }

    public override void OnRemoved()
    {
        player.PlayerData.TemperatureDurability /= 0.7f;
        player.PlayerData.Stemina /= 0.5f;
    }
}
