using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
{
    public float acquireDistance;
    public GameObject ui;
    protected Player player;

    private void Start()
    {
        ui = transform.Find("Ui").gameObject;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    public virtual void OnAcquired()
    {

    }

    public virtual void OnUsed()
    {

    }
}

