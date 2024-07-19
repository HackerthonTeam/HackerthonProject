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
        time = 0f; // time 변수를 초기화합니다.
        StartCoroutine(LoadAsyncSceneCoroutine());
    }

    IEnumerator LoadAsyncSceneCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // Time.deltaTime을 사용하여 프레임 간의 시간을 더합니다.
            time += Time.deltaTime;

            // 슬라이더 값을 업데이트합니다.
            slider.value = time / 5f;

            // 10초가 지나면 씬을 활성화합니다.
            if (time > 5f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
