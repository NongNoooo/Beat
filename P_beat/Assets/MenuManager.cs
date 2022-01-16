using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject previousMusic;

    public GameObject[] LP;

    public LpDisk[] lp;

    public bool sceneLoaded = false;

    public GameObject potal;

    public BoxCollider bc;

    public GameObject[] musics;

    private void Awake()
    {
        portalTemp();
    }

    void portalTemp()
    {
        bc = potal.GetComponent<BoxCollider>();

        bc.enabled = false;
    }
    void Start()
    {
        previousMusic = GameObject.FindGameObjectWithTag("Music");

        lp = new LpDisk[3]; 
        for (int i = 0; i < 3; i++) 
        {
            lp[i] = LP[i].GetComponent<LpDisk>();
        }

        sceneLoaded = true;

/*        musics = GameObject.FindGameObjectsWithTag("Music");

        for(int i = 0; i < musics.Length; i++)
        {
            Destroy(musics[i]);
        }
*/    }


    void Update()
    {
        LpArray();
    }

void LpArray()
    {
        Debug.Log("Work");

        if (sceneLoaded)
        {
            if (previousMusic.name.Contains("Blinding_Light_Music"))
            {
                lp[0].mainPos = true;
                lp[0].rightPos = false;
                lp[0].leftPos = false;

                lp[1].mainPos = false;
                lp[1].rightPos = false;
                lp[1].leftPos = true;

                lp[2].mainPos = false;
                lp[2].rightPos = true;
                lp[2].leftPos = false;

                Debug.Log("Wokr");

                //lp[0].transform.position = lp[0].mainP.transform.position;
                lp[1].transform.position = lp[1].leftP.transform.position;
                lp[2].transform.position = lp[2].rightP.transform.position;
            }
            else if (previousMusic.name.Contains("Everything_Black"))
            {
                lp[0].mainPos = false;
                lp[0].rightPos = false;
                lp[0].leftPos = true;

                lp[1].mainPos = false;
                lp[1].rightPos = true;
                lp[1].leftPos = false;

                lp[2].mainPos = true;
                lp[2].rightPos = false;
                lp[2].leftPos = false;

                lp[0].transform.position = lp[0].leftP.transform.position;
                lp[1].transform.position = lp[1].rightP.transform.position;
                //lp[2].transform.position = lp[2].mainP.transform.position;


            }
            else if (previousMusic.name.Contains("I_Feel_It_Coming"))
            {
                lp[0].mainPos = false;
                lp[0].rightPos = true;
                lp[0].leftPos = false;

                lp[1].mainPos = true;
                lp[1].rightPos = false;
                lp[1].leftPos = false;

                lp[2].mainPos = false;
                lp[2].rightPos = false;
                lp[2].leftPos = true;

                lp[0].transform.position = lp[0].rightP.transform.position;
                //lp[1].transform.position = lp[1].mainP.transform.position;
                lp[2].transform.position = lp[2].leftP.transform.position;

            }
        }
        else
        {
            Destroy(previousMusic);
        }
    }
}
