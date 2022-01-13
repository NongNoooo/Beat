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


    void Start()
    {
        lp = jukeBox.GetComponent<LpPlayer>();
        tm = titleManager.GetComponent<TitleManager>();
        pc = portalControl.GetComponent<Knife.Portal.PortalControlByKey>();
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
            }
        }

        if (move)
        {
            transform.position = Vector3.Slerp(transform.position, diskInPos.transform.position, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, diskInPos.transform.rotation, 0.1f);
        }

        if (Vector3.Distance(transform.position, diskInPos.transform.position) <= 0.1f)
        {
            turning = true;
        }

    }

    void PortalOpen()
    {
        if (turning == true)
        {
            portal.transform.position = portalPos.transform.position;

            Open();

            Invoke("CamMove", 2.0f);
        }
    }

    void Open()
    {
        //��Ż��Ʈ�� ��ũ��Ʈ�� open�� true�� ����
        pc.open = true;
    }


    public GameObject cam;
    void CamMove()
    {
        cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(new Vector3(12, 1, 6)), 0.1f);
        cam.transform.position += Vector3.forward * 2 * Time.deltaTime;
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



    //Ű�Է½� ��ũ �����̴°� Ȯ��
    public bool moveToRight = false;

    void LpChage()
    {
        //Ű�� �Էµ��� ��ũ�� ��� ���ư��� �ϱ����� �Ұ��� ����
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveToRight = true;
        }

        //�Ʒ� �޼��� ����
        DiskMove(ref leftPos, ref mainPos, mainP);
        DiskMove(ref mainPos, ref rightPos, rightP);
        DiskMove(ref rightPos, ref leftPos, leftP);
    }


    //           ������ġ �Ұ�, ��ư�Է½� �̵��� ��ġ �Ұ�, �̵��� ��ġ ������Ʈ
    void DiskMove(ref bool firstPos, ref bool nextPos, GameObject nextPosObj)
    {
        //Ű�Է½� ����� �Ұ����� ���� Ű�Է��� ������� ��ũ�� ��� �̵�
        if (moveToRight)
        {
            if (firstPos == true)
            {
                transform.position = Vector3.Slerp(transform.position, nextPosObj.transform.position, 0.1f);

                //��ũ �̵��� ���߰� ��ġ�� �´� �Ұ��� Ȱ��ȭ
                if (Vector3.Distance(transform.position, nextPosObj.transform.position) < 0.1f)
                {
                    moveToRight = false;
                    firstPos = false;
                    nextPos = true;
                }
            }
        }
    }
}
