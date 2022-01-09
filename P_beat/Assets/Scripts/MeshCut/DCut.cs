using UnityEngine;
using System.Collections;

public class DCut : MonoBehaviour {

	public Material capMaterial;
	//public GameObject Slash;

	public float maxDistance;
	// Use this for initialization
	void Start () {

		
	}
	
	void Update(){

			RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.D))
        {

			if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
			{
                GameObject victim = hit.collider.gameObject;

                /*                GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

                                if (!pieces[1].GetComponent<Rigidbody>())
                                    pieces[1].AddComponent<Rigidbody>();

                                Destroy(pieces[1], 1);
                */
                if (victim.CompareTag("test"))
                {

                    GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

                    if (!pieces[1].GetComponent<Rigidbody>())
                        pieces[1].AddComponent<Rigidbody>();

                    Destroy(pieces[1], 1);
                    //GameObject S = Instantiate(Slash);
                    //S.transform.position = transform.position;
                    //S.transform.rotation = transform.rotation;

                }
            }
        }

    }

	void OnDrawGizmosSelected() {

		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 5.0f);

		Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
		Gizmos.DrawLine(transform.position,  transform.position + -transform.up * 0.5f);

	}

}
