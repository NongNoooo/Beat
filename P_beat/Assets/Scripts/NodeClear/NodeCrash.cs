using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCrash : MonoBehaviour
{
    public float currTime;
    public float endTime = 2.0f;

    GameManager gm;
    public GameObject gmobj;


    GradeText gt;
    public GameObject nodePerfectTextPos;


    public Material capMaterial;
    //public GameObject Slash;

    public float maxDistance;




    void Start()
    {
        gmobj = GameObject.FindGameObjectWithTag("GameManager");
        gm = gmobj.GetComponent<GameManager>();

        gt = nodePerfectTextPos.GetComponent<GradeText>();

    }

    void Update()
    {
        TimeCount();
        DeActive();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Node"))
        {
            //Debug.Log(currTime);
            if (currTime <= 0.5f)
            { //Ű�Է��� 0.5�� �̸��϶� ��带 Ŭ�����ϸ� ������Ʈ
                Debug.Log("Excellent");
                gm.CountScore("Excellent");
                gm.ComboPlus();

                gt.TextPopUp(gt.ex);
            }
            if (currTime > 0.5f && currTime <= 1.0f)
            { // 0.5 �ʰ� 1������ �϶� = �׷���Ʈ
                Debug.Log("Great");
                gm.CountScore("Great");
                gm.ComboPlus();

                gt.TextPopUp(gt.gt);
            }
            else if (currTime > 1.5f)
            {
                Debug.Log("fail");
                gm.CountScore("fail");
                gm.ComboBreak();

                gt.TextPopUp(gt.fail);
            }
            /*            else if(currTime > 1.0f && currTime <= 1.5f)
                        { // 1�� �ʰ� 1.5�� �����϶� ��
                            Debug.Log("Good");
                            gm.CountScore("Good");
                            gm.ComboPlus();

                            gt.TextPopUp(gt.gd);
                        }
            *//*            else if(currTime > 1.5f)
                        { //1.5�� �ʰ��� ����
                            Debug.Log("fail");
                            gm.CountScore("fail");
                            gm.ComboBreak();

                            gt.TextPopUp(gt.fail);
                        }
            */
            other.gameObject.tag = "Done";
        }
    }

    void TimeCount()
    {
        currTime += Time.deltaTime;
    }

    void DeActive()
    {
        if (currTime >= endTime)
        {
            this.gameObject.SetActive(false);
            currTime = 0.0f;
        }
    }

    public void GetkeyUp()
    {
        currTime = 0;
    }
}