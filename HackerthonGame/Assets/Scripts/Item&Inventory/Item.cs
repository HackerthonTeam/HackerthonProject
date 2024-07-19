using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class ItemData
{
    public float acquireDistance;
    public GameObject ui;
    public Vector2 itemPos;
}

public class Item : MonoBehaviour, ISavable
{
    public ItemData itemData = new();
    protected Player player;
    private void Start()
    {
        itemData.ui = transform.Find("Ui").gameObject;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        ItemManager.Instance.items.Add(this);
    }
    public virtual void OnAcquired()
    {

    }

    public virtual void OnUsed()
    {

    }

    public void LoadData(Database data)
    {
        var thisData = data.itemsData.Find(a => a == itemData);
        if(thisData != null)
        {
            itemData.acquireDistance = thisData.acquireDistance;
            itemData.ui = thisData.ui;
            transform.position = thisData.itemPos;
        }
    }

    public void SaveData(ref Database data)
    {
        var thisData = data.itemsData.Find(a => a == itemData);
        thisData.acquireDistance = itemData.acquireDistance;
        thisData.ui = itemData.ui;
        thisData.itemPos = transform.position;
    }
}

