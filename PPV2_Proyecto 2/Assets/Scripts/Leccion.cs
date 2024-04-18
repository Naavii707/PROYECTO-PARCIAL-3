using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Esto indica que la clase es serializable, lo que significa que toda la informacion se puede convertir en 
// una especie de formato para sel almacenada y transmitida.
[System.Serializable]

public class Leccion
{
    // Declaraci�n de variables que guardar�n informaci�n.
    public int ID;
    public string lessons;
    public List<string> options;
    public int correctAnswer;
}
