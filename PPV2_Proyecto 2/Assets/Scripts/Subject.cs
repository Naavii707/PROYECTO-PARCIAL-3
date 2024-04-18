using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Subject", menuName = "ScriptableObjects/New Lesson", order = 1)]

public class Subject : ScriptableObject
{
    // Declaraci�n de una variable que se utilizar� para almacenar el n�mero de la lecci�n.
    [Header("GameObject Configuration")]
    public int Lesson = 0;

    // Declaraci�n de una lista.
    // La clase Leccion est� definida en otro script.
    [Header("Lession Quest Configuration")]
    public List<Leccion> leccionList;

}
