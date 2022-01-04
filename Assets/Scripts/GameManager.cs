using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    Quiz quiz;
    Gameover gameover;

    void Awake() {
        quiz = FindObjectOfType<Quiz>();
        gameover = FindObjectOfType<Gameover>();
    }

    // Start is called before the first frame update
    void Start()
    {
        quiz.gameObject.SetActive(true);
        gameover.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz.isGameover) {
            quiz.gameObject.SetActive(false);
            gameover.gameObject.SetActive(true);
            gameover.ShowFinalScore();
        } 
    }

    public void OnReplayLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
