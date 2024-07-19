using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : Singleton<ItemManager>, ISavable
{
    public List<Item> items;

    public void LoadData(Database data)
    {
        items = data.items;
    }

    public void SaveData(ref Database data)
    {
        data.items = items;
    }
}
