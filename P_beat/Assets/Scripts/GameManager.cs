using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int combo;


    public GameObject scoreText;
    public GameObject comboText;

    public GameObject soundManager;

    TextShow ts;
    TextShow _ts;

    public float musicStartTime = 1.0f;

    private void Start()
    {
        ts = scoreText.GetComponent<TextShow>();
        _ts = comboText.GetComponent<TextShow>();
    }

    public void Update()
    {
        Invoke("MusicStart", musicStartTime);
    }

    void MusicStart()
    {
        soundManager.SetActive(true);
    }


public void ComboPlus()
    {
        combo += 1;
        _ts.ComboText();
    }

    public void ComboBreak()
    {
        combo = 0;
        _ts.ComboText();
    }

    public void CountScore(string a)
    {
        if(a == "Excellent")
        {
            score += 100;
        }
        else if(a == "Great")
        {
            score += 80;
        }
        else
        {
            score += 0;
        }

        ts.ScoreText();
    }
}
