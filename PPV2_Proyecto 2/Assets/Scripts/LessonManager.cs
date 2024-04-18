using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class LessonManager : MonoBehaviour
{
    // Instancia para acceder al LessonManager 
    public static LessonManager Instance;

    // Datos del nivel actual
    [Header("Level Data")]
    public SubjectContainer subject;

    [Header("User Interface")]
    public TMP_Text QuestionTxt;
    public TMP_Text livesTxt;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;
    public List<OptionBtm> Options;
    public TMP_Text message;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer = 9;
    public int lives = 3;

    [Header("Current Lesson")]
    public Leccion currentLesson;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        subject = SaveSystems.instance.subject;
        // Establece la cantidad de preguntas en la lección
        questionAmount = subject.leccionList.Count;
        // Cargar la primera pregunta
        LoadQuestion();

        CheckPlayerState();
    }

    // Método para cargar la siguiente pregunta
    private void LoadQuestion()
    {
        // Aseguramos que la pregunta actual está dentro de los límites
        if (currentQuestion < questionAmount)
        {
            // Establecemos la lección actual
            currentLesson = subject.leccionList[currentQuestion];
            // Establecemos la pregunta
            question = currentLesson.lessons;
            // Establecemos la respuesta correcta
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];
            // Establecemos la pregunta en UI
            QuestionTxt.text = question;


            // Configura los botones de opción en la UI
            for (int i = 0; i < currentLesson.options.Count; i++)
            {
                Options[i].GetComponent<OptionBtm>().OptionName = currentLesson.options[i];
                Options[i].GetComponent<OptionBtm>().OptionID = i;
                Options[i].GetComponent<OptionBtm>().UpdateText();
            }
        }
        else
        {
            // Si llegamos al final de las preguntas
            Debug.Log("Fin de las preguntas");
            SceneManager.LoadScene("main");
        }
    }

    // Método que maneja la lógica de la siguiente pregunta
    public void NextQuestion()
    {
        bool isCorrect = false;

        if (CheckPlayerState())
        {
            // Comprueba si la respuesta del jugador es correcta
            isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

            // Muestra el contenedor de la respuesta
            AnswerContainer.SetActive(true);


            // Actualiza el color del contenedor de respuesta según si la respuesta es correcta o incorrecta
            if (isCorrect)
            {

                AnswerContainer.GetComponent<Image>().color = Green;
                message.text = "Respuesta correcta. " + ": " + correctAnswer;
                
            }
            else
            {
                // Reduce una vida si la respuesta es incorrecta
                lives--; 
                AnswerContainer.GetComponent<Image>().color = Red;
                message.text = "Respuesta incorrecta. " + ": " + correctAnswer;
            }
        }

        // Actualiza el texto de las vidas restantes en la UI
        livesTxt.text = lives.ToString();

        // Incrementa el número de la pregunta
        currentQuestion++;

        if (lives == 0)
        {
            SceneManager.LoadScene("main");
        }

        // Inicia una corrutina para mostrar el resultado y cargar la siguiente pregunta
        StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

        // Restablece la respuesta del jugador
        answerFromPlayer = 9;
    }


    // Corrutina para mostrar el resultado y cargar la siguiente pregunta
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        // Espera 2.5 segundos
        yield return new WaitForSeconds(2.5f);

        // Oculta el contenedor de la respuesta
        AnswerContainer.SetActive(false);

        // Carga la siguiente pregunta
        LoadQuestion();

        CheckPlayerState();
    }

    // Método para establecer la respuesta del jugador
    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    public bool CheckPlayerState()
    {
        if (answerFromPlayer != 9)
        {
            // Habilita el botón de comprobación si se ha seleccionado una respuesta
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            // Deshabilita el botón de comprobación si no se ha seleccionado ninguna respuesta
            CheckButton.GetComponent<Button>().interactable = false;
            CheckButton.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }
}
