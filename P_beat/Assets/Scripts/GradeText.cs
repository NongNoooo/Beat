using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeText : MonoBehaviour
{
    public GameObject ex;
    public GameObject gt;
    public GameObject fail;

    GameObject[] txt;

    public void TextPopUp(GameObject a)
    {
        txt = GameObject.FindGameObjectsWithTag("Grade");

        for(int i = 0; i < txt.Length; i++)
        {
            Destroy(txt[i]);
        }

        GameObject tx = Instantiate(a, transform.position, transform.rotation);
        tx.transform.parent = transform;
        Destroy(tx, 2.0f);
    }
}
