using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cold : SpecialState
{
    public Cold()
    {
        duration = 120;
        name = "����";
        description = "������ �� ���� ������ ����� �����մϴ�.";
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