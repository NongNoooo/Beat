using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnd : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    string[] lights =
    {
        "Light_D",
        "Light_F",
        "Light_G",
        "Light_H",
        "Light_J",
        "Light_K",
    };

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //전체 자식의 리스트 받아옴
        Transform[] allChild = animator.gameObject.GetComponentsInChildren<Transform>();

        //위에서 받은 리스트에서 반복
        foreach (Transform child in allChild)
        {
            //해당 string을 포함한 오브젝트를 찾으면 디버그
            if (child.name == "Light")
            {
                GameObject g = child.GetChild(0).gameObject;
                Debug.Log(g);

                g.SetActive(true);

                return;
            }
        }
    }

    NodeClearActive nca;

    //애니메이션이 끝날때
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nca = animator.transform.root.GetComponent<NodeClearActive>();

        //전체 자식의 리스트 받아옴
        Transform[] allChild = animator.gameObject.GetComponentsInChildren<Transform>();

        //위에서 받은 리스트에서 반복
        foreach(Transform child in allChild)
        {
            //해당 string을 포함한 오브젝트를 찾으면 디버그
            if(child.name == "Light")
            {
                GameObject g = child.GetChild(0).gameObject;
                Debug.Log(g);

                nca.DummyColor_Black(g.name);


                g.SetActive(false);

                return;
            }
        }
    }
}
