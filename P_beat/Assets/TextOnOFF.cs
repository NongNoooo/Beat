using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnOFF : MonoBehaviour
{
    public GameObject title;

    //bool working = true;

    //float rnd;

    void Start()
    {
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        //rnd = Random.Range(0.2f, 1.0f);
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


        //StartCoroutine(Blink());
    }
}
