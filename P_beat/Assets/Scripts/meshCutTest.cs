using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshCutTest : MonoBehaviour
{
    public Material capMaterial;

    public float maxDistance;

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
                rigiR.AddForce(-transform.forward * 300);

                pieces[0].gameObject.name = "L";
                pieces[1].gameObject.name = "R";
                    
                Destroy(pieces[0], 1);
                Destroy(pieces[1], 1);
            }
        }
    }

}
