using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    float speed = 50.0f;

    public Vector3 _dir;


    void Start()
    {

    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += _dir.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NodeEnd"))
        {
            Debug.Log("³ëµå »ç¶óÁü");
            Destroy(gameObject);
        }
    }
}
