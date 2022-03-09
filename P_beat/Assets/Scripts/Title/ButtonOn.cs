using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOn : MonoBehaviour
{
    public GameObject buttonText;

    public bool click = false;

    public float moveSpeed = 2.0f;

    public GameObject manager;

    public void TextOn()
    {
        buttonText.SetActive(true);
    }

    public void TextOff()
    {
        buttonText.SetActive(false);
    }     

    public void StartClick()
    {
        click = true;
    }
}
