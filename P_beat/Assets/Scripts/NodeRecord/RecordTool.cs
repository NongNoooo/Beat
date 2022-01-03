using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Threading.Tasks;

public class RecordTool : MonoBehaviour
{
    float currentTime = 0.0f;

    AudioSource _as;
    bool isStart = false;

    string m_strPath = "Assets/Resources/";
    //경로 지정
    FileStream fs;

    StreamWriter sw;
    public float tempTime = 0.3f;

    private void Start()
    {
        sw = new StreamWriter(fs, System.Text.Encoding.Unicode);
        //텍스트 인코딩 방식  유니코드(표준문자)

        fs = new FileStream(m_strPath + "Data.txt", FileMode.Create, FileAccess.Write, FileShare.None);
        //경로        파일명             옵션              접근권한        파일엑세스 수준


        _as = GetComponent<AudioSource>();
    }
    // Use this for initialization

    public void MusicStart()
    {
        currentTime = 0.0f;
        isStart = true;
        _as.Play();
    }

    public void Record()
    {

        sw.WriteLine("{0},{1}", 0, (currentTime - tempTime));
        print("0, " + (currentTime - tempTime));

    }
    public void MusicStop()
    {
        currentTime = 0.0f;
        _as.Stop();
        sw.Close();
    }


    private void FixedUpdate()
    {
        if (isStart == true)
        {
            currentTime += Time.fixedDeltaTime;
        }
    }

}
