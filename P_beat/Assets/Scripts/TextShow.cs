using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShow : MonoBehaviour
{
    GameManager gm;

    public Text txt;

    void Start()
    {
        GameObject gmobj = GameObject.FindGameObjectWithTag("GameManager");
        gm = gmobj.GetComponent<GameManager>();

        if (gameObject.CompareTag("Score"))
        {
            ScoreText();

        }
        else
        {
           ComboText();
        }
    }

    public void ScoreText()
    {
        txt.text = "Score : " + gm.score;
    }

    public void ComboText()
    {
        txt.text = gm.combo + " : Combo";
    }
}
