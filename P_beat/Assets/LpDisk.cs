using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LpDisk : MonoBehaviour
{

    public GameObject jukeBox;
    LpPlayer lp;

    public GameObject titleManager;
    TitleManager tm;

    public GameObject musicNamePos;

    public GameObject nameObj;

    public GameObject diskInPos;

    public GameObject mainP;
    public GameObject rightP;
    public GameObject leftP;

    public bool mainPos = false;
    public bool leftPos = false;
    public bool rightPos = false;

    void Start()
    {

        lp = jukeBox.GetComponent<LpPlayer>();
        tm = titleManager.GetComponent<TitleManager>();

    }


    void Update()
    {
        LpMove();

        LpMusic();

        test();
    }


    bool move = false;
    void LpMove()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (mainPos)
            {
                move = true;
            }
        }

        if (move)
        {
            transform.position = Vector3.Slerp(transform.position, diskInPos.transform.position, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, diskInPos.transform.rotation, 0.1f);
        }
    }

    void LpMusic(/*string a*/)
    {
        /*        if (a == "LP1")
                {
                    if (tm.jukeBoxMoveEnd)
                    {
                        GameObject n = Instantiate(nameObj);
                        n.transform.parent = musicNamePos.transform;
                        n.transform.position = musicNamePos.transform.position;
                        n.transform.rotation = musicNamePos.transform.rotation;
                    }
                    tm.jukeBoxMoveEnd = false;
                }*/
        if (tm.jukeBoxMoveEnd)
        {
            GameObject n = Instantiate(nameObj);
            n.transform.parent = musicNamePos.transform;
            n.transform.position = musicNamePos.transform.position;
            n.transform.rotation = musicNamePos.transform.rotation;
        }
        tm.jukeBoxMoveEnd = false;
    }



    //키입력시 디스크 움직이는거 확인
    public bool moveToRight = false;

    void test()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(mainPos == true)
            {
                moveToRight = true;
            }
        }

        if (moveToRight)
        {
            transform.position = Vector3.Slerp(transform.position, rightP.transform.position, 0.1f);
        }

    }
}
