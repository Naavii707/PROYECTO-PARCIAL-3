using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionBtm : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    // Método para actualizar el texto de la opción
    public void UpdateText()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }


    public void SelectOption()
    {
        // Establece la respuesta del jugador a la ID de esta opción
        LessonManager.Instance.SetPlayerAnswer(OptionID);
        LessonManager.Instance.CheckPlayerState();
    }
}
