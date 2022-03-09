using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Newtonsoft.Json;
/*
text파일에 string 데이터 쓰고 읽기
1. 파일을 저장할때는 쉼표단위로 저장하였다.
예) 1,sword,attack

2.읽을때는 한줄읽어 쉼표로 구분된 데이터를 추출한다.
- values 배열에 쉼표로 구분된 데이터가 저장된다.
*/

//제이슨 파일을 파싱해서 파일내 변수를 받아올 구조체
public struct Data
{
    public int index;
    public float time;
}

public class Parser : MonoBehaviour
{
    //위의 구조체를 인스턴스
    public List<Data> data = new List<Data>();

    public GameObject[] node;
    string m_strPath = "Assets/Resources/";
    string json;

    List<int> listFireObjIdx = new List<int>();
    List<float> listFireShotTime = new List<float>();

    float currentTime = 0.0f;
    int shotCnt = 0;


    public GameObject[] nodeEndPos;

    public GameObject music;

    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");

        Parse();       
    }
    
    public void Parse()
    {
        //제이슨 파서
        //경로의 파일을 불러와 모든 텍스트를 문자열로 읽은 후 파일을 닫음
        if (music.name.Contains("Blinding_Light_Music"))
        {
            json = File.ReadAllText(Application.dataPath + "/Resources/blinding_lights.json");  
        }
        if (music.name.Contains("Everything_Black"))
        {
            json = File.ReadAllText(Application.dataPath + "/Resources/Everything_Black.json");
        }
        if (music.name.Contains("I_Feel_It_Coming"))
        {
            json = File.ReadAllText(Application.dataPath + "/Resources/I_Feel_It_Coming.json");
        }


        //제이슨파일 직렬화 해제
        data = JsonConvert.DeserializeObject<List<Data>>(json);
        //반복문을 돌면서 해당 데이터 계속 읽어옴
        for (int i = 0; i < data.Count; i++)
        {
            //제이슨파일에 인덱스 호출
            listFireObjIdx.Add(Convert.ToInt32(data[i].index));
            //제이슨파일에 타임 호출
            listFireShotTime.Add((float)(Convert.ToDouble(data[i].time) - MusicManager.instance.tempTime));
        }
    }

    public GameObject[] nodePos;

    int idx;

    private void FixedUpdate()
    {

        if (listFireObjIdx.Count > 0  && listFireShotTime.Count > 0)
        {
            if (listFireObjIdx.Count > shotCnt)
            {
                Debug.Log(listFireObjIdx.Count);
                currentTime += Time.fixedDeltaTime;
                if (currentTime > listFireShotTime[shotCnt])
                {
                    Debug.Log(shotCnt);
                    int a = shotCnt + 1;
                    if (listFireObjIdx.Count == a)
                    {
                        idx = listFireObjIdx[shotCnt];

                        int rndnum = Random.Range(0, nodePos.Length);

                        GameObject rndNodePos = nodePos[rndnum];

                        Debug.Log("last");
                        GameObject nodeObj = Instantiate(node[idx]);

                        LastNode ln = nodeObj.AddComponent<LastNode>();

                        NodeMove nm = nodeObj.GetComponent<NodeMove>();

                        nm._dir = nodeEndPos[rndnum].transform.position - nodeObj.transform.position;


                        nodeObj.transform.position = rndNodePos.transform.position;
                    }
                    else
                    {
                        idx = listFireObjIdx[shotCnt];

                        int rndnum = Random.Range(0, nodePos.Length);

                        GameObject rndNodePos = nodePos[rndnum];

                        GameObject nodeObj = Instantiate(node[idx]);

                        NodeMove nm = nodeObj.GetComponent<NodeMove>();

                        nm._dir = nodeEndPos[rndnum].transform.position - nodeObj.transform.position;


                        nodeObj.transform.position = rndNodePos.transform.position;
                    }

                    sunSizeDown = true;

                    SunMove();

                    shotCnt++;
                }
            }
        }
    }

    public GameObject sun;


    bool sunSizeDown = false;

    void SunMove()
    {
        StartCoroutine(SunSacle());
    }

    IEnumerator SunSacle()
    {
        if (sunSizeDown)
        {
            Vector3 orPos = new Vector3(1, 1, 1);

            float sunSizeUpCount = 1;

            while(sunSizeUpCount < 1.05f)
            {
                sunSizeUpCount += 0.01f;
                yield return new WaitForSeconds(0.01f);
                sun.transform.localScale = new Vector3(sunSizeUpCount, sunSizeUpCount, 1);
            }
            while (sunSizeUpCount > 0.95)
            {
                sunSizeUpCount -= 0.01f;
                yield return new WaitForSeconds(0.01f);
                sun.transform.localScale = new Vector3(sunSizeUpCount, sunSizeUpCount, 1);
            }

            sun.transform.localScale = orPos;
            sunSizeUpCount = 1;
            sunSizeDown = false;
        }
    }
}