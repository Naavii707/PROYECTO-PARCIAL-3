using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string nombreDeLaEscena;

    // Método para cambiar de escena
    public void CambiarAEscena()
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}

