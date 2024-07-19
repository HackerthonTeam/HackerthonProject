using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Slider slider;
    private float time;

    void Start()
    {
        time = 0f; // time ������ �ʱ�ȭ�մϴ�.
        StartCoroutine(LoadAsyncSceneCoroutine());
    }

    IEnumerator LoadAsyncSceneCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // Time.deltaTime�� ����Ͽ� ������ ���� �ð��� ���մϴ�.
            time += Time.deltaTime;

            // �����̴� ���� ������Ʈ�մϴ�.
            slider.value = time / 5f;

            // 10�ʰ� ������ ���� Ȱ��ȭ�մϴ�.
            if (time > 5f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
