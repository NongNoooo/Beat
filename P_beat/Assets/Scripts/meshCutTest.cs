using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshCutTest : MonoBehaviour
{
    public Material capMaterial;

    public float maxDistance;

    int lineNum = 0;

    private void Start()
    {
        GetLineNum();
    }

    void GetLineNum()
    {
        if (gameObject.name.Contains("1"))
        {
            lineNum = 1;
        }
        else if (gameObject.name.Contains("2"))
        {
            lineNum = 2;
        }
        else if (gameObject.name.Contains("3"))
        {
            lineNum = 3;
        }
        else if (gameObject.name.Contains("4"))
        {
            lineNum = 4;
        }
        else if (gameObject.name.Contains("5"))
        {
            lineNum = 5;
        }
        else if (gameObject.name.Contains("6"))
        {
            lineNum = 6;
        }
    }

    void MaterialColorChange()
    {
        if (lineNum == 1)
        {
            capMaterial.SetVector("_EmissionColor", Color.green * 2.4169f);
        }
        else if (lineNum == 2)
        {
            capMaterial.SetVector("_EmissionColor", Color.yellow * 2.4169f);
        }
        else if (lineNum == 3)
        {
            capMaterial.SetVector("_EmissionColor", Color.cyan * 2.4169f);
        }
        else if (lineNum == 4)
        {
            capMaterial.SetVector("_EmissionColor", Color.white * 2.4169f);
        }
        else if (lineNum == 5)
        {
            capMaterial.SetVector("_EmissionColor", Color.red * 2.4169f);
        }
        else if (lineNum == 6)
        {
            capMaterial.SetVector("_EmissionColor", Color.blue * 2.4169f);
        }
    }

    void Update()
    {
        MeshCut();   
    }

    public GameObject[] pieces;

    void MeshCut()
    {
        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            GameObject victim = hit.collider.gameObject;

            if (victim.CompareTag("Done"))
            {
                MaterialColorChange();

                pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

                if (!pieces[1].GetComponent<Rigidbody>())
                    pieces[1].AddComponent<Rigidbody>();
                if (!pieces[0].GetComponent<Rigidbody>())
                    pieces[0].AddComponent<Rigidbody>();

                Rigidbody rigiR = pieces[1].GetComponent<Rigidbody>();
                Rigidbody rigiL = pieces[0].GetComponent<Rigidbody>();

                
                rigiR.useGravity = false;
                rigiL.useGravity = false;

                rigiL.AddForce(-transform.right * 30);
                rigiR.AddForce(transform.right * 300);
                rigiR.AddForce(-transform.forward * 800);

                pieces[0].gameObject.name = "L";
                pieces[1].gameObject.name = "R";
                    
                Destroy(pieces[0], 1);
                Destroy(pieces[1], 1);
            }
        }
    }

}
