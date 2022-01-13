using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camPos : MonoBehaviour
{

    Canvas c;
    
    void Start()
    {
        c = GetComponent<Canvas>();
    }


    void Update()
    {
        c.worldCamera = Camera.main;
    }
}
