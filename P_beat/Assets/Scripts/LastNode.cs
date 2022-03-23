using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastNode : MonoBehaviour
{
    public GameObject menu;
    GameObject _menu;

    public GameObject music;
    GameObject _music;

    AudioSource _as;

    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("EndMenu");
        _menu = menu.transform.GetChild(0).gameObject;

        music = GameObject.FindGameObjectWithTag("Music");
        _music = music.transform.GetChild(0).gameObject;
        _as = _music.GetComponent<AudioSource>();

        transform.gameObject.tag = "LastNode";
    }


    void Update()
    {
        Debug.Log("last");

    }

    float curTime = 0;

    void EndMenuActive()
    {
        curTime += Time.deltaTime;
        Time.timeScale = 1f;
        _menu.SetActive(true);

        if(curTime >= 1.0f)
        {
            _as.Pause();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NodeEnd"))
        {          
            EndMenuActive();
        }
    }

}
