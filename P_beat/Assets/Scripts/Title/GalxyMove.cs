using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalxyMove : MonoBehaviour
{
    public float rotSpeed = 2.0f;

    public Transform to;

    public GameObject manager;

    TitleManager tm;

    void Start()
    {
        tm = manager.GetComponent<TitleManager>();
    }

    void Update()
    {
        //???? ?? ??? ????
        if (tm.nowMove == false)
        {
            //???? ??
            if (CompareTag("JukeBox"))
            {
                transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
            }
            //???? ?? ???? ??
            else
            {
                transform.Rotate(new Vector3(0, -rotSpeed * Time.deltaTime, 0));
            }
        }
        //???? ??
        if (tm.nowMove)
        {
            //????? ??? ????? ????
            if (CompareTag("JukeBox"))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(-100, 180, 0)), 3.0f*Time.deltaTime);
            }
        }
    }
}
