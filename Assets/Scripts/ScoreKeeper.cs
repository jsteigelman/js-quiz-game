using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int scoreNumber = 0;

    public void PlayerGuessedCorrectly() {
        scoreNumber += 15;
    }

    public void PlayerGuessedIncorrectly() {
        scoreNumber -= 5;
    }

    public int GetScore() {
        return scoreNumber;
    }
}
