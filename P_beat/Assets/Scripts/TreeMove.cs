using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMove : MonoBehaviour
{
    public float speed = 2.0f;

    public Transform fPos;


    void Start()
    {
        
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        if (CompareTag("Tree"))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ePos"))
        {
            //Debug.Log("???? ???? ????");
            transform.position = fPos.position;

        }
    }
}
