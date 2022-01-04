using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerindex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite incorrectAnswerSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++) {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index) {

        // Image buttonImage;
        Image correctButtonImage;
        Image incorrectButtonImage;

        if (index == question.GetCorrectAnswerIndex()) {
            questionText.text = "Correct!";
            correctButtonImage = answerButtons[index].GetComponent<Image>();
            correctButtonImage.sprite = correctAnswerSprite;
        } else {
            int correctAnswerIndex = question.GetCorrectAnswerIndex();
            // string correctAnswer = question.GetAnswer(correctAnswerindex);
            questionText.text = "Sorry! That's incorrect.";

            correctButtonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            correctButtonImage.sprite = correctAnswerSprite;
            // questionText.text = "Try again!";
            incorrectButtonImage = answerButtons[index].GetComponent<Image>();
            incorrectButtonImage.sprite = incorrectAnswerSprite;
        }
    }
}
