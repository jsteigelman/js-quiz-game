using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    float timeToCompleteQuestion = 10f;
    float timeToShowCorrectAnswer = 1.5f;

    public bool loadNextQuestion;
    public float fillFraction;

    public bool isAnsweringQuestion;
    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer() {
        timerValue = 0;
    }

    void UpdateTimer() {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion) {
            if (timerValue > 0) {
                fillFraction = timerValue / timeToCompleteQuestion;
            } else {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        } else {
            if (timerValue > 0) {
                // fillFraction = timerValue / timeToShowCorrectAnswer;
                fillFraction = 0;
            } else {
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
        }
    }
}
