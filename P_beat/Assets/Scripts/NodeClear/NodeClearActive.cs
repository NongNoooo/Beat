using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeClearActive : MonoBehaviour
{
    public GameObject d_key;
    public GameObject f_key;
    public GameObject g_key;
    public GameObject h_key;
    public GameObject j_key;
    public GameObject k_key;


    void Start()
    {
        d_key = transform.GetChild(0).gameObject;
        f_key = transform.GetChild(1).gameObject;
        g_key = transform.GetChild(2).gameObject;
        h_key = transform.GetChild(3).gameObject;
        j_key = transform.GetChild(4).gameObject;
        k_key = transform.GetChild(5).gameObject;

    }

    void Update()
    {
        ButtonActive();
    }

    void ButtonActive()
    {
        Dkey();
        Fkey();
        Gkey();
        Hkey();
        Jkey();
        Kkey();

    }

    void Dkey()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            d_key.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            d_key.SetActive(false);
        }
    }

    void Fkey()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            f_key.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            f_key.SetActive(false);
        }
    }

    void Gkey()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            g_key.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            g_key.SetActive(false);
        }

    }

    void Hkey()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            h_key.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            h_key.SetActive(false);
        }

    }

    void Jkey()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            j_key.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            j_key.SetActive(false);
        }

    }

    void Kkey()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            k_key.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            k_key.SetActive(false);
        }

    }
}
