using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish1Item : Item
{
    public override void OnUsed()
    {
        base.OnUsed();

        player.PlayerData.Hunger += 2;
    }
}
