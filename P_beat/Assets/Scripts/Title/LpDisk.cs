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

    public GameObject portalControl;

    Knife.Portal.PortalControlByKey pc;

    public GameObject cam;

    CamMove cm;


    //LP1 = blindlight
    public GameObject musicObj;



    void Start()
    {
        lp = jukeBox.GetComponent<LpPlayer>();
        tm = titleManager.GetComponent<TitleManager>();
        pc = portalControl.GetComponent<Knife.Portal.PortalControlByKey>();
        cm = cam.GetComponent<CamMove>();
        
    }


    void Update()
    {
        LpMove();

        LpMusic();

        LpChage();

        PortalOpen();
    }


    public bool move = false;
    public bool turning = false;

    public GameObject portal;
    public GameObject portalPos;


    void LpMove()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (mainPos)
            {
                move = true;

                GameObject m = Instantiate(musicObj);
                DontDestroyOnLoad(m);
            }
        }

        if (move)
        {
            transform.position = Vector3.Slerp(transform.position, diskInPos.transform.position, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, diskInPos.transform.rotation, 0.1f);

            if (Vector3.Distance(transform.position, diskInPos.transform.position) <= 0.1f)
            {
                turning = true;
            }
        }
    }

    void PortalOpen()
    {
        if (turning == true)
        {
            portal.transform.position = portalPos.transform.position;

            Open();

            cm._camMove = true;
            cm.CamMoveInvoke();
            turning = false;
        }
    }

    void Open()
    {
        //포탈컨트롤 스크립트의 open을 true로 변경
        pc.open = true;
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
            if(musicNamePos.transform.childCount == 0)
            {
                Debug.Log("work");
                GameObject n = Instantiate(nameObj);
                n.transform.parent = musicNamePos.transform;
                n.transform.position = musicNamePos.transform.position;
                n.transform.rotation = musicNamePos.transform.rotation;
            }
        }
        //tm.jukeBoxMoveEnd = false;
    }



    //키입력시 디스크 움직이는거 확인
    public bool moveToRight = false;

    void LpChage()
    {
        //키가 입력된후 디스크가 계속 돌아가게 하기위해 불값을 변경
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveToRight = true;
        }

        //아래 메서드 실행
        //DiskMove();
        if (moveToRight)
        {
            test();
        }
    }

    void DiskMove()
    {
        DiskMove(ref leftPos, ref mainPos, mainP);
        DiskMove(ref mainPos, ref rightPos, rightP);
        DiskMove(ref rightPos, ref leftPos, leftP);

    }

    //           현제위치 불값, 버튼입력시 이동할 위치 불값, 이동할 위치 오브젝트
    void DiskMove(ref bool firstPos, ref bool nextPos, GameObject nextPosObj)
    {
        //키입력시 변경된 불값으로 인해 키입력이 사라져도 디스크가 계속 이동
        if (moveToRight)
        {
            if (firstPos == true)
            {
                transform.position = Vector3.Slerp(transform.position, nextPosObj.transform.position, 0.1f);

                //디스크 이동을 멈추고 위치에 맞는 불값을 활성화
                if (Vector3.Distance(transform.position, nextPosObj.transform.position) < 0.1f)
                {
                    moveToRight = false;
                    firstPos = false;
                    nextPos = true;
                }
            }
        }
    }

    void test()
    {
        if (mainPos == true && rightPos == false && leftPos == false)
        {
            transform.position = Vector3.Slerp(transform.position, rightP.transform.position, 0.1f);

            if (Vector3.Distance(transform.position, rightP.transform.position) < 0.1f)
            {
                moveToRight = false;
                mainPos = false;
                leftPos = false;
                rightPos = true;
            }
        }
        else if (rightPos == true && mainPos == false && leftPos == false)
        {
            transform.position = Vector3.Slerp(transform.position, leftP.transform.position, 0.1f);

            if (Vector3.Distance(transform.position, leftP.transform.position) < 0.1f)
            {
                moveToRight = false;
                mainPos = false;
                rightPos = false;
                leftPos = true;
            }
        }
        else if(leftPos == true && mainPos == false && rightPos == false)
        {
            transform.position = Vector3.Slerp(transform.position, mainP.transform.position, 0.1f);

            if (Vector3.Distance(transform.position, mainP.transform.position) < 0.1f)
            {
                moveToRight = false;
                leftPos = false;
                rightPos = false;
                mainPos = true;
            }
        }
    }
}
