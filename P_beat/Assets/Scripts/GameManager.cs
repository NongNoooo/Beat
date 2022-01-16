using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int combo;


    public GameObject scoreText;
    public GameObject comboText;

    public GameObject music;

    TextShow ts;
    TextShow _ts;

    public float musicStartTime = 1.0f;

    public GameObject menu;

    AudioSource _as;

    private void Start()
    {
        ts = scoreText.GetComponent<TextShow>();
        _ts = comboText.GetComponent<TextShow>();

        music = GameObject.FindGameObjectWithTag("Music").transform.GetChild(0).gameObject;
        _as = music.GetComponent<AudioSource>();
    }

    public void Update()
    {
        Invoke("MusicStart", musicStartTime);
        EscMenu();
    }

    void MusicStart()
    {
        music.SetActive(true);
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

    public bool esc = false;

    public void EscMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            esc = !esc;
            menu.SetActive(!menu.activeSelf);

            if (esc == false)
            {
                Time.timeScale = 1f;
                _as.Play();
            }
            else if (esc == true)
            {
                Time.timeScale = 0f;
                _as.Pause();
            }
        }
    }
}
