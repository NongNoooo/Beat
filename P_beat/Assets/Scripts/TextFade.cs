using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public GameObject txtobj;

    Text text;

    void Awake()
    {
        text = txtobj.GetComponent<Text>();
    }


    void Update()
    {
        StartCoroutine("FadeTextToZero");
    }

    public IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
    }
}
