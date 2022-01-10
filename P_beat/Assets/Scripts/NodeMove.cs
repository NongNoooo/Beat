using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    float speed = 50.0f;

    public Vector3 _dir;

    GameManager gm;

    float currTime = 0;
    
    void Start()
    {
        GameObject gmobj = GameObject.FindGameObjectWithTag("GameManager");
        gm = gmobj.GetComponent<GameManager>();
    }


    void FixedUpdate()
    {
        Move();

        currTime += Time.deltaTime;
    }

    void Move()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NodeEnd"))
        {
            if (!gameObject.CompareTag("Done"))
            {
                Debug.Log("³ëµå »ç¶óÁü");
                //Debug.Log(currTime);


                gm.ComboBreak();

/*                GradeText gt = other.GetComponent<GradeText>();
                gt.TextPopUp(gt.fail);
*/

                Destroy(gameObject);
            }
        }
    }
}
