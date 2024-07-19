using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialState
{
    public float duration;
    public string name;
    public string description;

    protected Player player;

    public virtual void OnAdded()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    public virtual void OnUpdated()
    {

    }
    public virtual void OnRemoved()
    {

    }
}
