using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<SoundManager>
{
    public GameObject Player;
    //�� 3���� �ۺ����� �޾ƿ�

    float curTime = 0;
    void Start()
    {
        
    }
    bool a = false, b = false;
    void Update()
    {
        curTime += Time.deltaTime;

        if(curTime > 240 && !a)
        {
            a = true;
            //2�ܰ� ��
        }
        else if(curTime > 500 && !b)
        {
            b = true;
            //3�ܰ� ��
        }
    }
}
