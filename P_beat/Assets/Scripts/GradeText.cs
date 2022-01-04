using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeText : MonoBehaviour
{
    public GameObject ex;
    public GameObject gt;
    public GameObject gd;
    public GameObject fail;


    public void TextPopUp(GameObject a)
    {
        Debug.Log("work");
        GameObject tx = Instantiate(a, transform.position, transform.rotation);
        Destroy(tx, 2.0f);
    }
}
