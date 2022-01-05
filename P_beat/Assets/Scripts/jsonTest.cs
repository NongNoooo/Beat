//���̺귯�� ����Ʈ 
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
//��������

public class jsonTest : MonoBehaviour
{
     public List<Mydata> myData = new List<Mydata>();
    void Start()
    {
        //������ �ֱ�
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

    public void DoWrite() // 2. JSON string �����
    {
        string json = JsonConvert.SerializeObject(myData.ToArray());   // Json���Ϸ� �о�ֱ�
        File.WriteAllText(Application.dataPath + "/Resources/test.json", json);  // ���Ϸ� �����
        print(json); // �׽�Ʈ
    }


    public void DoRead()
    {
        string json = File.ReadAllText(Application.dataPath + "/Resources/test.json");
        myData = JsonConvert.DeserializeObject<List<Mydata>>(json);
        for (int i = 0; i < myData.Count; i++)
        {
            print("����" + myData[i].age + "�̸�" + myData[i].name);
        }
    }
}