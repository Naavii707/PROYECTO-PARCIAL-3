using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public static MainScript instance;
    public string SelectedLesson = "dummy";

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        else
        {
            instance = this;
        }
    }

    public void SetSelectedLesson(string lesson)
    {
        SelectedLesson = lesson;
        PlayerPrefs.SetString("SelectedLesson", SelectedLesson);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("Lessons");
    }
}

// tiene menú contextual