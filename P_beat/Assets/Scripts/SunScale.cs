using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public struct nData
{
    public int index;
    public float time;
}



public class SunScale : MonoBehaviour
{
    public List<nData> nd = new List<nData>();

    List<int> listFireObjIdx = new List<int>();
    List<float> listFireShotTime = new List<float>();

    float currentTime = 0.0f;
    int shotCnt = 0;


    // Start is called before the first frame update
    void Start()
    {
        Parse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Parse()
    {
        //제이슨 파서
        //경로의 파일 불러옴
        string json = File.ReadAllText(Application.dataPath + "/Resources/Data.json");
        //제이슨파일 직렬화 해제
        nd = JsonConvert.DeserializeObject<List<nData>>(json);
        //반복문을 돌면서 해당 데이터 계속 읽어옴
        for (int i = 0; i < nd.Count; i++)
        {
            //제이슨파일에 인덱스 호출
            listFireObjIdx.Add(Convert.ToInt32(nd[i].index));
            //제이슨파일에 타임 호출
            listFireShotTime.Add((float)(Convert.ToDouble(nd[i].time) - MusicManager.instance.tempTime));
        }

    }
}
