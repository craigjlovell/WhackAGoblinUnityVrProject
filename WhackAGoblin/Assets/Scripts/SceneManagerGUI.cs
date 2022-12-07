using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerGUI : MonoBehaviour
{
    Canvas canvas = null;

    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        Time.timeScale = 0;
        canvas = GetComponentInParent<Canvas>();
        canvas.enabled = false;
        canvas = GameObject.FindGameObjectWithTag("Menu").GetComponent<Canvas>();
        canvas.enabled = true;
    }

    public void Play()
    {
        SceneManager.LoadScene("WhacAGoblin");
        
    }
    public void Test()
    {
        SceneManager.LoadScene("CraigsTest");

    }
    public void Scoreboard()
    {
        SceneManager.LoadScene("ScoreboardScene");

    }

}
