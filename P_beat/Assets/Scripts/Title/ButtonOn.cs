using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOn : MonoBehaviour
{
    public GameObject buttonText;

    public bool click = false;

    public float moveSpeed = 2.0f;

    public GameObject manager;

    //버튼 텍스트 활성화
    public void TextOn()
    {
        buttonText.SetActive(true);
    }

    //버튼 텍스트 비활성화
    public void TextOff()
    {
        buttonText.SetActive(false);
    }

    public void StartClick()
    {
        click = true;
    }
}
