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
                    LpdiskAlreadyIn = true; // ????

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
            LpdiskAlreadyIn = false; // ????

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
        //lp?? lp?????? mainPos? ??? ?? ????? true
        if(diskReturn == false)
        {
            //lp?? Lp????? ????? ?? true
            if(LpdiskAlreadyIn == false)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    LpdiskAlreadyIn = true;
                    if (mainPos)
                    {
                        move = true;

                        Instantiate(musicObj);
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
        //?????????? ?????????? open?? true?? ????
        pc.open = true;
    }

    


    void LpMusic()
    {
        if (tm.jukeBoxMoveEnd)
        {
            if(musicNamePos.transform.childCount == 0)
            {
                GameObject n = Instantiate(nameObj);
                n.transform.parent = musicNamePos.transform;
                n.transform.position = musicNamePos.transform.position;
                n.transform.rotation = musicNamePos.transform.rotation;
            }
        }
    }



    public bool moveToRight = false;
    public bool moveToLeft = false;

    void LpChage()
    {
        if (diskReturn == false)
        {
            //LpdiskAlreadyIn(lp?? ??? ????? ???? ??? ?? true ????? false)
            if(LpdiskAlreadyIn == false)
            {
                //moveToRight, moveToLeft(lp?? ??? ?? ???? ???? ?? true ???? false)
                if(moveToRight == false && moveToLeft == false)
                {
                    //turning(lp?? ??? ??? lp??????? ???? ??? ?? true ???? false), sceneLoad(??? ?? true ? ??? )
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

        if (moveToRight)
        {
            MoveRight();
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

    void DiskMove(ref bool firstPos, ref bool nextPos, GameObject nextPosObj)
    {
        //???????? ?????? ???????? ???? ???????? ???????? ???????? ???? ????
        if (moveToRight)
        {
            if (firstPos == true)
            {
                transform.position = Vector3.Slerp(transform.position, nextPosObj.transform.position, 0.1f);

                //?????? ?????? ?????? ?????? ???? ?????? ??????
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

