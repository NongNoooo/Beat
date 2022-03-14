using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MeshAfterImage : AfterImageBase
{
    private MeshFilter[] TargetMeshFilterArray { get; set; }

    protected override void Init()
    {
        //메쉬필터 가져옴 
        if (_containChildrenMeshes)
        {
            TargetMeshFilterArray = GetComponentsInChildren<MeshFilter>();
        }
        else
        {
            TargetMeshFilterArray = new[] { GetComponent<MeshFilter>() };
        }

        //큐 생성
        FaderWaitQueue = new Queue<AfterImageFaderBase>();
        FaderRunningQueue = new Queue<AfterImageFaderBase>();

        // 3. Container
        _faderContainer = new GameObject($"{gameObject.name} AfterImage Container");
        //setpositionandrotation으로 포지션과 로테이션 한번에 수정
        _faderContainer.transform.SetPositionAndRotation(default, default);
        _faderContainer.transform.localScale = transform.localScale;

        _data.Mat = _afterImageMaterial;
    }

    protected override void SetupFader(out AfterImageFaderBase fader)
    {
        GameObject faderGo = new GameObject($"{gameObject.name} AfterImage");
        faderGo.transform.SetParent(_faderContainer.transform);

        fader = faderGo.AddComponent<MeshAfterImageFader>();
        fader.Setup(TargetMeshFilterArray, _data, this);
    }
}