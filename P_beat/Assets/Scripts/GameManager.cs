using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject node;


    public GameObject[] nodeSpawnPos;

    public GameObject[] nodeEndPos;

    NodeMove nm;

    void Awake()
    {
        node = Resources.Load<GameObject>("Prefabs/Cube");

    }


    void Update()
    {
        NodeCreat();
    }

    void NodeCreat()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject _node = Instantiate(node,nodeSpawnPos[1].transform.position,nodeSpawnPos[1].transform.rotation);

            nm = _node.GetComponent<NodeMove>();

            nm._dir = nodeEndPos[1].transform.position - _node.transform.position;

        }
    }
}
