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
        //���̽� �ļ�
        //����� ���� �ҷ���
        string json = File.ReadAllText(Application.dataPath + "/Resources/Data.json");
        //���̽����� ����ȭ ����
        nd = JsonConvert.DeserializeObject<List<nData>>(json);
        //�ݺ����� ���鼭 �ش� ������ ��� �о��
        for (int i = 0; i < nd.Count; i++)
        {
            //���̽����Ͽ� �ε��� ȣ��
            listFireObjIdx.Add(Convert.ToInt32(nd[i].index));
            //���̽����Ͽ� Ÿ�� ȣ��
            listFireShotTime.Add((float)(Convert.ToDouble(nd[i].time) - MusicManager.instance.tempTime));
        }

    }
}
