using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalxyMove : MonoBehaviour
{

    public float rotSpeed = 2.0f;

    public Transform to;

    public GameObject manager;

    TitleManager tm;


    Vector3 closeScale = new Vector3(2, 2, 5);

    void Start()
    {
        tm = manager.GetComponent<TitleManager>();
    }


    void Update()
    {
        if (tm.nowMove == false)
        {
            if (CompareTag("JukeBox"))
            {
                transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
            }
            else
            {
                transform.Rotate(new Vector3(0, -rotSpeed * Time.deltaTime, 0));
            }
        }
        if (tm.nowMove)
        {
            if(CompareTag("JukeBox"))
            //���ʹϾ��� �̿��� ȸ�� ����
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(-100, 180, 0)), 3.0f*Time.deltaTime);
            //                                                          ��ó�� ���Ƿ� ���ϴ� ���Ⱚ�� �ְ����
            //                                                          ��� ���ʹϾ� �տ� �ٿ��ߵ�

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(-450,-360,0)), 1.0f);


            //ȸ���� �������� Ȯ��
            /*float angle = Quaternion.Angle(transform.rotation, Quaternion.Euler(new Vector3(-80, -180, 0)));
            if (angle <= 0)
            {
                tm.nowMove = false;
            }*/
        }
    }
}
