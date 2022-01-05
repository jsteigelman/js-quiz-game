using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{

    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();

    // [SerializeField] QuestionSO currentQuestion;
    QuestionSO currentQuestion;


    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Answer Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite incorrectAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreNumber;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    public bool isGameover;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    void Update() {
        timerImage.fillAmount = timer.fillFraction;

        if (timer.loadNextQuestion) {

           if (progressBar.value == progressBar.maxValue) {
                isGameover = true;
                return;
            }

            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        } else if (!hasAnsweredEarly && !timer.isAnsweringQuestion) {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    void DisplayAnswer(int index) {
        Image correctButtonImage;
        Image incorrectButtonImage;

        if (index == currentQuestion.GetCorrectAnswerIndex()) {
            questionText.text = "Great job! That's correct.";
            correctButtonImage = answerButtons[index].GetComponent<Image>();
            correctButtonImage.sprite = correctAnswerSprite;
            scoreKeeper.PlayerGuessedCorrectly();
        } else {
            int correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            questionText.text = "Sorry! That's incorrect.";
            correctButtonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            correctButtonImage.sprite = correctAnswerSprite;
            // scoreKeeper.PlayerGuessedIncorrectly();
            if (index >= 0) {
                incorrectButtonImage = answerButtons[index].GetComponent<Image>();
                incorrectButtonImage.sprite = incorrectAnswerSprite;
                scoreKeeper.PlayerGuessedIncorrectly();
            }
        }
    }

    public void OnAnswerSelected(int index) {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        int currentScore = scoreKeeper.GetScore();
        scoreNumber.text = currentScore.ToString();
        progressBar.value += 1;
    }

    void GetNextQuestion() {
        if (questions.Count > 0) {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            // progressBar.value += 1;
        }
    }

    void GetRandomQuestion() {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if (questions.Contains(currentQuestion)) {
            questions.Remove(currentQuestion);
        }
    }

    void DisplayQuestion() {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++) {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    void SetButtonState(bool state) {
        for (int i = 0; i < answerButtons.Length; i++) {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites() {
        for (int i = 0; i < answerButtons.Length; i++) {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }


}
