using System.Collections;
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
    public List<NodeData> noteData = new List<NodeData>();


    float currentTime = 0.0f;

    AudioSource aus;
    bool isStart = false;
    string m_strPath = "Assets/Resources/";
    FileStream fs;
    StreamWriter sw;
    public float tempTime=0.3f;
    void Start()
    {

        //fs = new FileStream(m_strPath+"Data.txt", FileMode.Create, FileAccess.Write);
        fs = new FileStream(m_strPath + "J_Data.json", FileMode.Create, FileAccess.Write);
        sw = new StreamWriter(fs, System.Text.Encoding.Unicode);


        
        
        aus = GetComponent<AudioSource>();
    }
    // Use this for initialization

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

        NodeData nd;
        nd.index = 0;
        nd.time = (currentTime - tempTime);

        noteData.Add(nd);

        DoWrite();
    }

    public void DoWrite() // 2. JSON string 만들기
    {
        string json = JsonConvert.SerializeObject(noteData.ToArray());   // Json파일로 밀어넣기
        File.WriteAllText(Application.dataPath + "/Resources/J_Data.json", json);  // 파일로 만들기
        print(json); // 테스트
    }



    public void EndMusic()
    {
        currentTime = 0.0f;
        aus.Stop();
        sw.Close();
    }


    private void FixedUpdate()
    {
        if(isStart == true)
        {
            currentTime += Time.fixedDeltaTime;
        }
    }

}