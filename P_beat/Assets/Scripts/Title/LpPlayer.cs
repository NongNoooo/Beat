using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LpPlayer : MonoBehaviour
{
    
    public bool closeEnough = false;

    public GameObject lpArm;

    Vector3 playArmRot = new Vector3(0, 0, 0);

    Vector3 playLPRot = new Vector3(0, 0, 0);
    Vector3 PlayLPPos = new Vector3(0.28f, -0.023f, -0.075f);

    Vector3 lpPlayerScale = new Vector3(1.0441f, 1.0441f, 1.0441f);

    public GameObject mainLpPos;
    public GameObject LeftLpPos;
    public GameObject RightLpPos;
    public GameObject lpInPos;
    public GameObject lpPlayer;
    public GameObject lpPlayerPos;
    public GameObject glass;

    public GameObject lp1;
    public GameObject lp2;
    public GameObject lp3;

    public GameObject Dome;


    LpDisk ld;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Close();
        LPPosition();
    }

    float x = 1;
    float y = 1;
    float z = 1;

    void Close()
    {
        if (closeEnough)
        {
            if (x <= 3)
            {
                x += 7f * Time.deltaTime;
            }
            if(y <= 3)
            {
                y += 7f * Time.deltaTime;
            }
            if(z <= 5)
            {
                z += 22f*Time.deltaTime;
            }
            Dome.transform.localScale = new Vector3(x,y,z);
        }
    }

    void LPPosition()
    {
        if (closeEnough)
        {
            glass.SetActive(false);
            LpPos(lp1);
            LpPos(lp2);
            LpPos(lp3);

            closeEnough = false;
        }
    }

    void LpPos(GameObject a)
    {
        //메뉴씬이 아닐때만 첫위치로 이동하도록
        if(SceneManager.GetActiveScene().name != "Menu")
        {
            ld = a.GetComponent<LpDisk>();

            if (a.CompareTag("LP1"))
            {
                a.transform.position = mainLpPos.transform.position;
                ld.mainPos = true;

            }
            else if (a.CompareTag("LP2"))
            {
                a.transform.position = LeftLpPos.transform.position;
                ld.leftPos = true;
            }
            else if (a.CompareTag("LP3"))
            {
                a.transform.position = RightLpPos.transform.position;
                ld.rightPos = true;
            }
        }
    }

    /*    void LpChange()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {

            }
        }
    */
}
