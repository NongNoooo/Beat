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

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Title")
        {
            dir = portalPos.transform.position - transform.position;
        }
        else
        {
            dir = oriPos.transform.position - transform.position;
            mag = (transform.position - oriPos.transform.position).magnitude;


            Move();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            Debug.Log("Ä· ¸ØÃã");
            for (int i = 0; i < lpd.Length; i++)
            {
                lp = lpd[i].GetComponent<LpDisk>();
                lp.move = false;
            }


            //Ä· À§Ä¡¿Í Æ÷Å» À§Ä¡ ±æÀÌ ¹Þ¾Æ¿À±â
            /*  float a = (transform.position - other.transform.position).magnitude;

              Debug.Log(a);*/

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



    bool moveFront = false;

    void moveTime()
    {
        _camMove = false;
        moveFront = true;
    }

    void Move()
    {
        if(SceneManager.GetActiveScene().name == "Title")
        {
            if (_camMove == true)
            {
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
        else
        {
            /*transform.position += dir.normalized * 20000 * Time.deltaTime;

            if(mag <= 2000)
            {
                camSpeed = 2000;
            }

            if(mag <= 1000)
            {
                camSpeed = 1000;
            }*/

            transform.position = Vector3.Slerp(transform.position, oriPos.transform.position, Time.deltaTime);

            if(mag <= 0.5f)
            {
                transform.position = oriPos.transform.position;
                transform.rotation = oriPos.transform.rotation;
            }
        }
    }
}
