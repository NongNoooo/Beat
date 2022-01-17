using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    public GameObject[] lps;

    void Start()
    {
        lp = jukeBox.GetComponent<LpPlayer>();
        tm = titleManager.GetComponent<TitleManager>();
        pc = portalControl.GetComponent<Knife.Portal.PortalControlByKey>();
        cm = cam.GetComponent<CamMove>();


        if (SceneManager.GetActiveScene().name == "Menu")
        {
            mm = menuManager.GetComponent<MenuManager>();
        }

        if(SceneManager.GetActiveScene().name == "Title")
        {
            diskReturn = false;
        }
    }


    void Update()
    {
        LpMove();

        LpMusic();

        LpChage();

        PortalOpen();


        MenuScene();

    }

    public GameObject menuManager;
    MenuManager mm;

    bool sceneLoad = false;

    void MenuScene()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (mainPos)
            {
                if (mm.sceneLoaded)
                {
                    LpdiskAlreadyIn = true; // 수정

                    sceneLoad = true;

                    transform.position = diskInPos.transform.position;
                    transform.rotation = diskInPos.transform.rotation;

                    Open();
                }
                else
                {
                    if (pc.open == false)
                    {
                        if (diskReturn)
                        {
                            Invoke("afteroneScencd", 0.5f);
                        }

                    }
                }
            }
        }
    }

    public bool diskReturn = true;

    void afteroneScencd()
    {
        transform.position = Vector3.Slerp(transform.position, mainP.transform.position, 2*Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, mainP.transform.rotation, 2*Time.deltaTime);

        if(Vector3.Distance(transform.position,mainP.transform.position) <= 0.1f)
        {
            transform.rotation = mainP.transform.rotation;
            LpdiskAlreadyIn = false; // 수정

            for (int i = 0; i < lps.Length; i++)
            {
                LpDisk ld = lps[i].GetComponent<LpDisk>();

                ld.diskReturn = false;
                sceneLoad = false;
            }
        }
    }


    public bool move = false;
    public bool turning = false;

    public GameObject portal;
    public GameObject portalPos;


    public bool LpdiskAlreadyIn = false;
    void LpMove()
    {
        //스페이스바를 계속 눌러 musicObj를 중복 생성하지못하게 만듬
        if(diskReturn == false)
        {
            if(LpdiskAlreadyIn == false)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    LpdiskAlreadyIn = true;
                    if (mainPos)
                    {
                        move = true;

                        Instantiate(musicObj);
                        //LpdiskAlreadyIn = false;
                    }
                }
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

    


    void LpMusic()
    {
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
    }



    //키입력시 디스크 움직이는거 확인
    public bool moveToRight = false;
    public bool moveToLeft = false;

    void LpChage()
    {
        //디스크가 옆으로 이동중에 코드가 중복실행되서 순서가 엉키는걸 막기위해 moveToRight이 false일때만 키를 입력할수 있게 만듬
        if (diskReturn == false)
        {
            if(LpdiskAlreadyIn == false)
            {
                if(moveToRight == false && moveToLeft == false)
                {
                    if(turning == false || sceneLoad == false)
                    {
                        if (Input.GetKeyUp(KeyCode.D))
                        {
                            moveToRight = true;
                        }
                    }
                }
                if(moveToLeft == false && moveToRight == false)
                {
                    if(turning == false || sceneLoad == false)
                    {
                        if (Input.GetKeyUp(KeyCode.S))
                        {
                            moveToLeft = true;
                        }
                    }
                }
            }
        }

        //아래 메서드 실행
        //DiskMove();
        if (moveToRight)
        {
            MoveRight();
            //DiskMove();
        }
        if (moveToLeft)
        {
            MoveLeft();
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

    void MoveRight()
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

    void MoveLeft()
    {
        if (mainPos == true && rightPos == false && leftPos == false)
        {
            transform.position = Vector3.Slerp(transform.position, leftP.transform.position, 0.1f);

            if (Vector3.Distance(transform.position, leftP.transform.position) < 0.1f)
            {
                moveToLeft = false;
                mainPos = false;
                leftPos = true;
                rightPos = false;
            }
        }
        else if (rightPos == true && mainPos == false && leftPos == false)
        {
            transform.position = Vector3.Slerp(transform.position, mainP.transform.position, 0.1f);

            if (Vector3.Distance(transform.position, mainP.transform.position) < 0.1f)
            {
                moveToLeft = false;
                mainPos = true;
                rightPos = false;
                leftPos = false;
            }
        }
        else if (leftPos == true && mainPos == false && rightPos == false)
        {
            transform.position = Vector3.Slerp(transform.position, rightP.transform.position, 0.1f);

            if (Vector3.Distance(transform.position, rightP.transform.position) < 0.1f)
            {
                moveToLeft = false;
                leftPos = false;
                rightPos = true;
                mainPos = false;
            }
        }
    }

}

