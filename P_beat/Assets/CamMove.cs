using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamMove : MonoBehaviour
{
    public bool _camMove = false;

    public GameObject portalPos;

    public GameObject oriPos;

    public GameObject[] lpd;

    LpDisk lp;

    Vector3 dir;

    public GameObject light;

    float mag;

    MenuManager mm;

    GameObject menu;

    public GameObject portalcontrol;

    Knife.Portal.PortalControlByKey pc;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            menu = GameObject.FindGameObjectWithTag("MenuManager");

            mm = menu.GetComponent<MenuManager>();

            pc = portalcontrol.GetComponent<Knife.Portal.PortalControlByKey>();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        //Ÿ��Ʋ ȭ�鿡�� ��Ż�� ī�޶� ���� ���ϱ�
        if(SceneManager.GetActiveScene().name == "Title")
        {
            dir = portalPos.transform.position - transform.position;
        }
        else if(SceneManager.GetActiveScene().name == "GamMain")
        {
            //����ȭ�鿡�� ī�޶� �̵��ϴ� ���� �� �Ÿ����ϱ�
            dir = oriPos.transform.position - transform.position;
            mag = (transform.position - oriPos.transform.position).magnitude;


            Move();
        }
        else
        {
            //�޴���
            if(_camMove == false && moveFront == false)
            {
                //�޴����� ó�� �ε������� camMove�� false�� cammove�� ����ؼ� �۵���Ŵ
                //��Ż���� ���������� ������ ����
                //���� ��ġ���� ī�޶� ��ġ�� ���� ���� ����
                dir = oriPos.transform.position - transform.position;
                mag = (transform.position - oriPos.transform.position).magnitude;

                //���� ��ġ�� �̵�
                Move();

                //�޴����� ������ ���ϴ� bool
                if (mm.sceneLoaded)
                {
                    if(mag <= 0.1f)
                    {
                        //������ ���� �Ÿ��� �����ɶ�
                        //�ε� �Ϸ�bool�� true�� ����
                        mm.sceneLoaded = false;
                        //pc.open = false;
                        sceneLoadComple = true;
                    }
                }
                if(sceneLoadComple == true)
                {
                    //
                    pc.open = false;
                    sceneLoadComple = false;
                    mm.bc.enabled = true;
                }

            }
            if(moveFront == true/*_camMove == true*/)
            {
                dir = portalPos.transform.position - transform.position;

                Move();
            }
        }
    }

    bool sceneLoadComple = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            Debug.Log(other.name);
            Debug.Log("ķ ����");
            for (int i = 0; i < lpd.Length; i++)
            {
                lp = lpd[i].GetComponent<LpDisk>();
                lp.move = false;
            }

            SceneManager.LoadScene("GamMain");
        }
    }

    public void CamMoveInvoke()
    {
        Invoke("Move", 2.0f);
        Invoke("LightOff", 2.0f);
    }


    void LightOff()
    {
        light.SetActive(false);
    }



    public bool moveFront = false;

    void moveTime()
    {
        _camMove = false;
        moveFront = true;
    }

    void Move()
    {
        if(SceneManager.GetActiveScene().name == "Title")
        {
            if (_camMove == true && moveFront == false)
            {
                //ķ�� �ڷ� ������

                //1���Ŀ� �ڷ� �����̴°� ���߰� ������ ��
                Invoke("moveTime", 1.0f);
                //cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(new Vector3(12, 1, 6)), 0.1f);
                transform.localPosition += Vector3.back * 5 * Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,-10), 2*Time.deltaTime);
            }

            if (moveFront)
            {
                transform.position += dir.normalized * 100 * Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 2 * Time.deltaTime);
            }
        }
        else if(SceneManager.GetActiveScene().name == "GamMain")
        {

            transform.position = Vector3.Slerp(transform.position, oriPos.transform.position, Time.deltaTime);

            if(mag <= 0.5f && moveFront == false)
            {
                transform.position = oriPos.transform.position;
                transform.rotation = oriPos.transform.rotation;
            }
        }
        else
        {
            //�޴� ������ �۵�

            if(_camMove == false)
            {
                transform.position += dir.normalized * 100 * Time.deltaTime;
            }

            if(mag <= 0.5f && moveFront == false)
            {
                //��Ż���� �������� ī�޶� �ڷ� �̵��Ҷ� ������ ���� �Ÿ��� �����ǰ� moveFornt�� false�϶� ī�޶� ��ġ ����
                transform.position = oriPos.transform.position;
            }

            if (_camMove && moveFront == false)
            {
                //�����̽��ٸ� ���� lp��ũ�� lp�÷��̾�� ��ġ��Ų�� ��Ż�� ������
                //ķ�� �ڷ� �̵��ϸ� ȸ��
                Invoke("moveTime", 1.0f);
                //cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(new Vector3(12, 1, 6)), 0.1f);
                transform.localPosition += Vector3.back * 5 * Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -10), 2 * Time.deltaTime);

            }
            if (moveFront)
            {
                //�κ�ũ�� ���� �����Ų moveTime���� Ȱ��ȭ�� moveFront�� �̿��ؼ� ī�޶� ��Ż������ �̵�
                transform.position += dir.normalized * 100 * Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 2 * Time.deltaTime);
            }

        }
    }
}
