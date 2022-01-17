using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeText : MonoBehaviour
{
    public GameObject ex;
    public GameObject gt;
    public GameObject fail;


    public void TextPopUp(GameObject a)
    {
        if (transform.childCount != 0)
        {
            //센터 텍스트에 텍스트가 중복생성 안되게
            //센터 텍스트에 자식으로 생성되었던 오브젝트들을 전부 삭제
            for(int i = 0; i < transform.childCount; i++)
            {
                GameObject n = transform.GetChild(0).gameObject;
                Destroy(n);
            }
        }

        GameObject tx = Instantiate(a, transform.position, transform.rotation);
        tx.transform.parent = transform;
        Destroy(tx, 2.0f);
    }
}
