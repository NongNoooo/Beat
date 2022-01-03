using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Threading.Tasks;
/*
text파일에 string 데이터 쓰고 읽기
1. 파일을 저장할때는 쉼표단위로 저장하였다.
예) 1,sword,attack

2.읽을때는 한줄읽어 쉼표로 구분된 데이터를 추출한다.
- values 배열에 쉼표로 구분된 데이터가 저장된다.
*/


public class NoteTool : MonoBehaviour
{
    float currentTime = 0.0f;


    
    AudioSource aus;
    bool isStart = false;
    string m_strPath = "Assets/Resources/";
    FileStream fs;
    StreamWriter sw;
    public float tempTime=0.3f;
    void Start()
    {

        fs = new FileStream(m_strPath+"Data.txt", FileMode.Create, FileAccess.Write);
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
        
        sw.WriteLine("{0},{1}",0,(currentTime- tempTime));
        print("0, " + (currentTime- tempTime));
        
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