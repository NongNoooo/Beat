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
        //타이틀 화면에서 포탈과 카메라 방향 구하기
        if(SceneManager.GetActiveScene().name == "Title")
        {
            dir = portalPos.transform.position - transform.position;
        }
        else if(SceneManager.GetActiveScene().name == "GamMain")
        {
            //게임화면에서 카메라 이동하는 방향 및 거리구하기
            dir = oriPos.transform.position - transform.position;
            mag = (transform.position - oriPos.transform.position).magnitude;


            Move();
        }
        else
        {
            //메뉴씬
            if(_camMove == false && moveFront == false)
            {
                //메뉴씬이 처음 로딩됬을땐 camMove가 false라 cammove를 사용해서 작동시킴
                //포탈에서 빠져나오는 연출을 위해
                //원래 위치에서 카메라 위치를 빼서 방향 구함
                dir = oriPos.transform.position - transform.position;
                mag = (transform.position - oriPos.transform.position).magnitude;

                //원래 위치로 이동
                Move();

                //메뉴씬이 켜짐을 뜻하는 bool
                if (mm.sceneLoaded)
                {
                    if(mag <= 0.1f)
                    {
                        //위에서 구한 거리가 만족될때
                        //로딩 완료bool값 true로 변경
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
            Debug.Log("캠 멈춤");
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
                //캠이 뒤로 움직임

                //1초후에 뒤로 움직이는거 멈추고 앞으로 ㄱ
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
            //메뉴 씬에서 작동

            if(_camMove == false)
            {
                transform.position += dir.normalized * 100 * Time.deltaTime;
            }

            if(mag <= 0.5f && moveFront == false)
            {
                //포탈에서 빠져나와 카메라가 뒤로 이동할때 위에서 구한 거리가 충족되고 moveFornt가 false일때 카메라 위치 고정
                transform.position = oriPos.transform.position;
            }

            if (_camMove && moveFront == false)
            {
                //스페이스바를 눌러 lp디스크를 lp플레이어로 위치시킨후 포탈이 열린뒤
                //캠이 뒤로 이동하며 회전
                Invoke("moveTime", 1.0f);
                //cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(new Vector3(12, 1, 6)), 0.1f);
                transform.localPosition += Vector3.back * 5 * Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -10), 2 * Time.deltaTime);

            }
            if (moveFront)
            {
                //인보크를 통해 실행시킨 moveTime에서 활성화된 moveFront를 이용해서 카메라를 포탈쪽으로 이동
                transform.position += dir.normalized * 100 * Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 2 * Time.deltaTime);
            }

        }
    }
}
