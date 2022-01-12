using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject startButton;

    ButtonOn bo;

    public GameObject[] moveFrontobj;

    public GameObject jukeBox;

    public GameObject cam;

    public float moveSpeed = 2.0f;

    public bool nowMove = false;


    public float jukeBoxRotFix = 300.0f;

    public float menuObjEnlarge = 128.0f;

    public float objStopMove = 80.0f;

    Vector3 dir;

    LpPlayer lp;

    public bool jukeBoxMoveEnd = false;

    void Start()
    {
        bo = startButton.GetComponent<ButtonOn>();
        lp = jukeBox.GetComponent<LpPlayer>();
    }

    void Update()
    {
        dir = cam.transform.position - jukeBox.transform.position;

        if (bo.click)
        {
            Move();
        }
    }

    void Move()
    {
        for (int i = 0; i < moveFrontobj.Length; i++)
        {
            if (moveFrontobj[i].CompareTag("JukeBox"))
            {
                moveFrontobj[i].transform.position += dir.normalized * moveSpeed * 10 * Time.deltaTime;

                if(Vector3.Distance(cam.transform.position, jukeBox.transform.position) <= jukeBoxRotFix)
                {
                    nowMove = true;

                    if(Vector3.Distance(cam.transform.position, jukeBox.transform.position) <= menuObjEnlarge)
                    {
                        lp.closeEnough = true;
                    }

                    if (Vector3.Distance(cam.transform.position, jukeBox.transform.position) <= objStopMove)
                    {
                        bo.click = false;
                        jukeBoxMoveEnd = true;
                    }
                }
            }
            else if (moveFrontobj[i].CompareTag("Galaxy"))
            {
                moveFrontobj[i].transform.position += -Vector3.forward * moveSpeed * 100 * Time.deltaTime;
            }
            else if (moveFrontobj[i].CompareTag("Planet"))
            {
                moveFrontobj[i].transform.position += -Vector3.forward * moveSpeed * 100 * Time.deltaTime;
            }
            else if (moveFrontobj[i].CompareTag("Button"))
            {
                moveFrontobj[i].transform.position += -Vector3.forward * moveSpeed * 0.7f * Time.deltaTime;
            }
            else
            {
                moveFrontobj[i].transform.position += -Vector3.forward * moveSpeed * Time.deltaTime;
            }
        }
    }
}
