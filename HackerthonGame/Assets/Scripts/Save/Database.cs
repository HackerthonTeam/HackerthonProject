using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Database
{
    //���� ����
    public int count;
    public TestClass testClass;

    public List<Item> items;

    public PlayerData playerData;

    //�ʱⰪ ����
    public Database()
    {
        count = 0; 
        items = new List<Item>();
        playerData = new();
    }
}
