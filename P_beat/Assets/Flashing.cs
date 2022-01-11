using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashing : MonoBehaviour
{

    public GameObject haveMaterialObj;


    TextMeshPro tmp;

    Material m;

    Renderer r;

    Color orgColor;

    void Start()
    {
        //tmp = haveMaterialObj.GetComponent<TextMeshPro>();

        tmp = GetComponent<TextMeshPro>();

        r = haveMaterialObj.GetComponent<Renderer>();

        m = r.GetComponent<Material>();

        orgColor = new Color(164 / 255, 13 / 255, 191 / 255);
    }


    void Update()
    {
        //tmp.faceColor(orgColor * 2);

        m.SetColor("m_faceColor", orgColor * 2);

        
    }
}
