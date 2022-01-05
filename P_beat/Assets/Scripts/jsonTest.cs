//라이브러리 임포트 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public struct Mydata
{
    public int age;
    public string name;
}
//변수선언

public class jsonTest : MonoBehaviour
{
     public List<Mydata> myData = new List<Mydata>();
    void Start()
    {
        //데이터 넣기
        for (int i = 0; i < myData.Count; i++)
        {
            Mydata data;
            data.age = 10 + i;
            data.name = "kim" + i;

            myData.Add(data);
        }
        //DoWrite();
        DoRead();
    }

    public void DoWrite() // 2. JSON string 만들기
    {
        string json = JsonConvert.SerializeObject(myData.ToArray());   // Json파일로 밀어넣기
        File.WriteAllText(Application.dataPath + "/Resources/test.json", json);  // 파일로 만들기
        print(json); // 테스트
    }


    public void DoRead()
    {
        string json = File.ReadAllText(Application.dataPath + "/Resources/test.json");
        myData = JsonConvert.DeserializeObject<List<Mydata>>(json);
        for (int i = 0; i < myData.Count; i++)
        {
            print("나이" + myData[i].age + "이름" + myData[i].name);
        }
    }
}