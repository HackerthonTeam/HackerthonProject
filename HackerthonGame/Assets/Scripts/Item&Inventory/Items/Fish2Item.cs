using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish2Item : Item
{
    public override void OnUsed()
    {
        base.OnUsed();

        player.PlayerData.Hunger += 25;
    }
}
