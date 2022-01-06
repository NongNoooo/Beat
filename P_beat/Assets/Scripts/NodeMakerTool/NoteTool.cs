﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
/*
text파일에 string 데이터 쓰고 읽기
1. 파일을 저장할때는 쉼표단위로 저장하였다.
예) 1,sword,attack

2.읽을때는 한줄읽어 쉼표로 구분된 데이터를 추출한다.
- values 배열에 쉼표로 구분된 데이터가 저장된다.
*/


//json파일로 만들기 위한 변수
public struct NodeData
{
    public int index;
    public float time;
}


public class NoteTool : MonoBehaviour
{
    //스트럭트 NodeData를 배열로 인스턴스화
    public List<NodeData> noteData = new List<NodeData>();


    float currentTime = 0.0f;

    AudioSource aus;
    bool isStart = false;
    string m_strPath = "Assets/Resource/";
    FileStream fs;
    StreamWriter sw;
    public float tempTime=0.3f;
    void Start()
    {
        //텍스트 파일로 파일을 생성 및 작성
        //fs = new FileStream(m_strPath+"Data.txt", FileMode.Create, FileAccess.Write);

        //제이슨 파일로 파일을 생성 및 작성
        fs = new FileStream(m_strPath + "Data.json", FileMode.Create, FileAccess.Write);

        //파일을 읽음 (위의 제이슨파일을 유니코드로)
        sw = new StreamWriter(fs, System.Text.Encoding.Unicode);


        
        
        aus = GetComponent<AudioSource>();
    }

    public void StartMusic()
    {
        currentTime = 0.0f;
        isStart = true;
        aus.Play();
    }

    public void NoteSave()
    {
        
        //sw.WriteLine("{0},{1}",0,(currentTime- tempTime));
        //print("0, " + (currentTime- tempTime));

        //노드 데이터 값 저장
        NodeData nd;
        nd.index = 0;
        nd.time = (currentTime - tempTime);

        //배열 noteData에 위의 값을 추가
        noteData.Add(nd);
    }

    public void DoWrite() // 2. JSON string 만들기
    {
        //직렬화 -> 제이슨파일로 배열 넣음
        string json = JsonConvert.SerializeObject(noteData.ToArray());   // Json파일로 밀어넣기

        //경로에 파일 생성
        File.WriteAllText(Application.dataPath + "/Resource/Data.json", json);  // 파일로 만들기
        print(json); // 테스트
    }



    public void EndMusic()
    {
        currentTime = 0.0f;
        aus.Stop();

        //제이슨파일 경로를 한번 사용했으면 close로 닫아주고 사용해야함
        sw.Close();
        DoWrite();
    }


    private void FixedUpdate()
    {
        if(isStart == true)
        {
            currentTime += Time.fixedDeltaTime;
        }
    }

}