using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnOFF : MonoBehaviour
{
    public GameObject title;

    void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        title.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        title.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        title.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        title.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        title.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        title.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        title.SetActive(false);
        yield return new WaitForSeconds(1f);
        title.SetActive(true);

    }
}
