using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    float speed = 50.0f;

    public Vector3 _dir;

    GameManager gm;

    float currTime = 0;

    public GameObject fail;

    public GameObject ntp;

    void Start()
    {
        GameObject gmobj = GameObject.FindGameObjectWithTag("GameManager");
        gm = gmobj.GetComponent<GameManager>();
        ntp = GameObject.FindGameObjectWithTag("NodeTextPos");
    }


    void FixedUpdate()
    {
        Move();

        currTime += Time.deltaTime;
    }

    void Move()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
    }




    private void OnTriggerEnter(Collider other)
    {
        if(transform.tag == "Node")
        {
            if (other.CompareTag("NodeEnd"))
            {
                if (!gameObject.CompareTag("Done"))
                {
                    if (ntp.transform.childCount != 0)
                    {
                        for(int i = 0; i < ntp.transform.childCount; i++)
                        {
                            GameObject _n = ntp.transform.GetChild(0).gameObject;
                            Destroy(_n);
                        }
                    }

                    GameObject n = Instantiate(fail, ntp.transform.position, ntp.transform.rotation);
                    n.transform.parent = ntp.transform;
                    gm.ComboBreak();

                    Destroy(gameObject);
                }
            }

        }
    }
}
