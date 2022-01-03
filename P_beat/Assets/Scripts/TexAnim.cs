using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexAnim : MonoBehaviour
{
    public MeshRenderer[] mr;

    public enum TexAnimDir
    {
        AnimDown,
    };

    TexAnimDir tad;



    void Start()
    {
        tad = TexAnimDir.AnimDown;
    }

    void Update()
    {
        SetAnimDir();
        MoveAnim();
    }



    Vector2 dir;

    void SetAnimDir()
    {
        switch (tad)
        {
            case TexAnimDir.AnimDown:
                dir = Vector2.down;
                break;
        }
    }


    public float speed = 2.0f;
    
    void MoveAnim()
    {
        for (int i = 0; i < mr.Length; i++)
        {
            mr[i].material.mainTextureOffset += dir * speed * Time.deltaTime;
        }
    }
}
