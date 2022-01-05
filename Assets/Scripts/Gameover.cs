using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameover : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFinalScore() {
        if (scoreKeeper.GetScore() > 0) {
            finalScoreText.text = "You scored " + scoreKeeper.GetScore() + " points. Way to go!";
        } else {
            finalScoreText.text = "You scored " + scoreKeeper.GetScore() + " points. Better luck next time!";
        }
    }
}
