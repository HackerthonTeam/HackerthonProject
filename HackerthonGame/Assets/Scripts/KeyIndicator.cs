using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyIndicator : MonoBehaviour
{
    public Text text;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            text.gameObject.SetActive(text.IsActive() ? false : true);
        }
    }
}
