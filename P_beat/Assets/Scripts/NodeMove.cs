using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    float speed = 50.0f;

    public Vector3 _dir;

    GameManager gm;

    void Start()
    {
        GameObject gmobj = GameObject.FindGameObjectWithTag("GameManager");
        gm = gmobj.GetComponent<GameManager>();
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NodeEnd"))
        {
            Debug.Log("³ëµå »ç¶óÁü");
            gm.ComboBreak();
            Destroy(gameObject);
        }
    }
}
