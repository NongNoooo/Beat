using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastNode : MonoBehaviour
{
    public GameObject menu;
    GameObject _menu;

    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("EndMenu");
        _menu = menu.transform.GetChild(0).gameObject;

        transform.gameObject.tag = "LastNode";
    }


    void Update()
    {
        Debug.Log("last");

    }

    void EndMenuActive()
    {
        Time.timeScale = 1f;
        _menu.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NodeEnd"))
        {
            
            EndMenuActive();
        }
    }

}
