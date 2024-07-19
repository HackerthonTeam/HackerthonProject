using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Database
{
    //변수 설정
    public int count;
    public TestClass testClass;


    public PlayerData playerData;

    //초기값 설정
    public Database()
    {
        count = 0; 
        playerData = new();
    }
}
