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
            GameObject n = transform.GetChild(0).gameObject;
            Destroy(n);
        }

        GameObject tx = Instantiate(a, transform.position, transform.rotation);
        tx.transform.parent = transform;
        Destroy(tx, 2.0f);
    }
}
