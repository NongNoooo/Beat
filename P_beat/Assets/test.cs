using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
/*        iTween.MoveTo(gameObject, iTween.Hash("time", 5, "path", iTweenPath.GetPath("diskPath"), "easetype",
            iTween.EaseType.easeInOutQuad));
*/    }

    // Update is called once per frame
    void Update()
    {
        //iTween.MoveTo(this.gameObject, iTween.Hash("time",2, "path", iTweenPath.GetPath("diskPath"), "easeType",iTween.EaseType.easeInOutQuad));
        iTween.MoveTo(gameObject, iTween.Hash("time", 5, "path", iTweenPath.GetPath("diskPath"), "easetype",
    iTween.EaseType.easeInOutQuad));

    }
}
