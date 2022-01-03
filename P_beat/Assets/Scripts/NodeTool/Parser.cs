using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
/*
text파일에 string 데이터 쓰고 읽기
1. 파일을 저장할때는 쉼표단위로 저장하였다.
예) 1,sword,attack

2.읽을때는 한줄읽어 쉼표로 구분된 데이터를 추출한다.
- values 배열에 쉼표로 구분된 데이터가 저장된다.
*/


public class Parser : MonoBehaviour
{
    //불꽃 프리팹 연결
    public GameObject[] node;
    string m_strPath = "Assets/Resources/";

    List<int> listFireObjIdx = new List<int>();
    List<float> listFireShotTime = new List<float>();

    float currentTime = 0.0f;
    int shotCnt = 0;

    void Start()
    {


        Parse();
    }
    // Use this for initialization

    


    public void Parse()
    {
        TextAsset data = Resources.Load("Data", typeof(TextAsset)) as TextAsset;
        StringReader sr = new StringReader(data.text);
        // 먼저 한줄을 읽는다. 
        string source = sr.ReadLine();
        string[] values;                // 쉼표로 구분된 데이터들을 저장할 배열 (values[0]이면 첫번째 데이터 )

        while (source != null)
        {
            values = source.Split(',');  // 쉼표로 구분한다. 저장시에 쉼표로 구분하여 저장하였다.
            if (values.Length == 0)
            {
                sr.Close();
                return;
            }
            source = sr.ReadLine();    // 한줄 읽는다.
            listFireObjIdx.Add(Convert.ToInt32(values[0]));
            listFireShotTime.Add((float)(Convert.ToDouble(values[1])- MusicManager.instance.tempTime));

        }

    }


    public GameObject[] nodePos;

    private void FixedUpdate()
    {
        if(listFireObjIdx.Count > 0  && listFireShotTime.Count > 0)
        {
            if (listFireObjIdx.Count > shotCnt)
            {
                currentTime += Time.fixedDeltaTime;
                if (currentTime > listFireShotTime[shotCnt])
                {
                    int idx = listFireObjIdx[shotCnt];
                    GameObject rndNodePos = nodePos[Random.Range(0, nodePos.Length)];
                    GameObject nodeObj = Instantiate(node[idx]);
                    nodeObj.transform.position = rndNodePos.transform.position;
                    nodeObj.transform.rotation = rndNodePos.transform.rotation;

                  print("오브젝트인덱스:" + listFireObjIdx[shotCnt] + " 경과시간: " + listFireShotTime[shotCnt]);
                  
                    //파티클 이펙트 자동파괴
                    Destroy(nodeObj, 1.5f);
                    shotCnt++;

                }
            }
        }
    }

}