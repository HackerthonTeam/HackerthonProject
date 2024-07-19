using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<SoundManager>
{
    public GameObject Player;
    public GameObject one,two,tre;
    public GameObject one1,two1,tr1e;
    public GameObject onon,toto,trtr;
    //�� 3���� �ۺ������� �޾ƿ�

    float curTime = 0;
    void Start()
    {
        one.SetActive(true);
        one1.SetActive(true);
        onon.SetActive(true);
    }
    bool a = false, b = false;
    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime > 240 && !a)
        {
            a = true;
            one.SetActive(false);
            one1.SetActive(false);
            onon.SetActive(false);
            two.SetActive(true);
            two1.SetActive(true);
            toto.SetActive(true);
            //2�ܰ� ��
        }
        else if(curTime > 500 && !b)
        {
            b = true;
            two.SetActive(false);
            two1.SetActive(false);
            toto.SetActive(false);
            tre.SetActive(true);
            tr1e.SetActive(true);
            trtr.SetActive(true);
            //3�ܰ� ��
        }
    }
}
