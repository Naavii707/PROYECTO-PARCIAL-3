using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Subject", menuName = "ScriptableObjects/New Lesson", order = 1)]

public class Subject : ScriptableObject
{
    // Declaración de una variable que se utilizará para almacenar el número de la lección.
    [Header("GameObject Configuration")]
    public int Lesson = 0;

    // Declaración de una lista.
    // La clase Leccion está definida en otro script.
    [Header("Lession Quest Configuration")]
    public List<Leccion> leccionList;

}
