using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item currentItem;
    ItemManager manager;
    Player player;
    Item itemUiIndicates;
    public Image ui;

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

        UpdateUi();
    }

    void CheckItem()
    {
        itemUiIndicates = null;
        float closeDistance = float.MaxValue;
        foreach (var item in manager.items)
        {
            float distance = (item.transform.position - player.transform.position).magnitude;
            if (distance < item.acquireDistance && distance < closeDistance && item != currentItem)
            {
                itemUiIndicates = item;
                closeDistance = distance;
            }
        }
        foreach (var item in manager.items)
        {
            if(item == itemUiIndicates)
            {
                item.ui.SetActive(true);
                item.ui.transform.position = item.transform.position;
                item.ui.transform.position += (player.transform.position - item.transform.position).normalized * 0.3f;
            }
            else item.ui.SetActive(false);
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

    void UpdateUi()
    {
        if (currentItem)
        {
            ui.gameObject.SetActive(true);
            ui.sprite = currentItem.gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            ui.gameObject.SetActive(false);
        }
    }
}
