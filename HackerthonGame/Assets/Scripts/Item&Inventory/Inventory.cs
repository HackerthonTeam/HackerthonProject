using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    public Item currentItem;
    ItemManager manager;
    Player player;
    Item itemUiIndicates;

    private void Start()
    {
        manager = ItemManager.Instance;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        CheckItem();
        if (Input.GetKeyDown(KeyCode.W) && currentItem == null) AcquireItem();
        if (Input.GetKeyDown(KeyCode.E) && currentItem != null) UseItem();
        if (Input.GetKeyDown(KeyCode.Q) && currentItem != null) DropItem();
    }

    void CheckItem()
    {
        itemUiIndicates = null;
        float closeDistance = float.MaxValue;
        foreach (var item in manager.items)
        {
            float distance = (item.transform.position - player.transform.position).magnitude;
            if (distance < item.itemData.acquireDistance && distance < closeDistance && item != currentItem)
            {
                itemUiIndicates = item;
                closeDistance = distance;
            }
        }
        foreach (var item in manager.items)
        {
            if(item == itemUiIndicates)
            {
                item.itemData.ui.SetActive(true);
            }
            else item.itemData.ui.SetActive(false);
        }
    }

    void AcquireItem()
    {
        currentItem = itemUiIndicates;
        currentItem.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        currentItem.transform.position = new Vector3(9999, 9999, 0);
        currentItem.OnAcquired();
    }

    void UseItem()
    {
        currentItem.OnUsed();
        currentItem.gameObject.SetActive(false); //풀메니저 리무브 풀
        currentItem = null;
    }

    void DropItem()
    {
        currentItem.transform.position = transform.position;
        currentItem.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        currentItem = null;
    }
}
