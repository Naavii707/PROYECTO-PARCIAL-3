using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LessonContainer : MonoBehaviour
{
    [Header ("GameObject Configuration")]
    public int Lection = 0;
    public int CurrentLession;
    public int TotalLessions = 0;
    public bool AreAllLessionsComplete = false;

    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;
    public string LessonName;

    void Start()
    {
        if (lessonContainer != null)
        {
            OnUpdateUI();
        }

        else
        {
            Debug.LogWarning("GameObject nulo, revisa las variables de tipo GameObject lesson container");
        }
    }


    // Actualiza la UI con los datos de la lección
    public void OnUpdateUI()
    {
        if (StageTitle != null || LessonStage != null) 
        {
            // Actualiza el título y el numero de la lección
            StageTitle.text = "Leccion " + Lection;
            LessonStage.text = "Leccion " + CurrentLession + " de " + TotalLessions;
        }

        else
        {
            Debug.LogWarning("GameObject nulo, revisa las variables del tipo TMP_Text");
        }
    }

    // Activa o desactiva el contenedor de la lección y actualiza la UI
    public void EnableWindow () 
    {
        OnUpdateUI();

        if(lessonContainer.activeSelf)
        {
            lessonContainer.SetActive(false);
        }

        else
        {
            lessonContainer.SetActive(true);
            MainScript.instance.SetSelectedLesson(LessonName);
        }
    }

    // Datos de la lección almacenados como Script.
    [Header("Lesson Data")]
    public ScriptableObject LessonData;
}
