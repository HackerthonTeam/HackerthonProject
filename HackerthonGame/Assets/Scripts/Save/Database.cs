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


    public PlayerData playerData;

    //�ʱⰪ ����
    public Database()
    {
        count = 0; 
        playerData = new();
    }
}
