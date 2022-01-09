using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshCutTest : MonoBehaviour
{

    public Material capMaterial;
    //public GameObject Slash;

    public float maxDistance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeshCut();   
    }

    void MeshCut()
    {
        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            GameObject victim = hit.collider.gameObject;

            if (victim.CompareTag("Node"))
            {
                GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

                if (!pieces[1].GetComponent<Rigidbody>())
                    pieces[1].AddComponent<Rigidbody>();

                Rigidbody rigiR = pieces[1].GetComponent<Rigidbody>();
                Rigidbody rigiL = pieces[0].GetComponent<Rigidbody>();

                rigiR.useGravity = false;
                rigiL.useGravity = false;

                rigiL.AddForce(-transform.right * 30);
                rigiR.AddForce(transform.right * 30);

                pieces[0].tag = "test";
                pieces[1].tag = "test";
                //Destroy(pieces[1], 1);
            }
        }
    }

}
