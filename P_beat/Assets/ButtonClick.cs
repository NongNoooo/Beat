using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public GameObject music;

    public GameObject blind;
    public GameObject feel;
    public GameObject black;

    public GameObject gm;

    GameManager _gm;

    bool isBlind = false;
    bool isFeel = false;
    bool isBlack = false;

    void OnEnable()
    {
        music = GameObject.FindGameObjectWithTag("Music");
        _gm = gm.GetComponent<GameManager>();
    }

    public void GotoTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GotoMenu()
    {
        _gm.esc = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ReLoadScene()
    {
        if (music.name.Contains("Blinding_Light_Music"))
        {
            isBlind = true;
            Destroy(music);
            MusicLoad();
            Init();
        }
        if (music.name.Contains("Everything_Black"))
        {
            isBlack = true;
            Destroy(music);
            MusicLoad();
            Init();
        }
        if (music.name.Contains("I_Feel_It_Coming"))
        {
            isFeel = true;
            Destroy(music);
            MusicLoad();
            Init();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void MusicLoad()
    {
        if (isBlind)
        {
            Instantiate(blind);
        }
        else if (isBlack)
        {
            Instantiate(black);
        }
        else
        {
            Instantiate(feel);
        }
    }

    public void EndGame()
    {
        Application.Quit();
    }

    void Init()
    {
        isBlack = false;
        isBlind = false;
        isFeel = false;
    }
}
