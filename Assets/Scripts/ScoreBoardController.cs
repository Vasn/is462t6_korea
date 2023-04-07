using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardController : MonoBehaviour
{
    public TextMeshPro scoreText;
    public static int startPoints = 0;

    // For game timer
    private bool gameStarted = false;
    private bool gameEnded = false;
    public float timerDuration = 60.0f; // 60 seconds
    private float timeLeft;
    public TextMeshPro timeLeftText;
    public GameObject btn;
    public TextMeshPro btnText;

    // Mess Makers
    public List<GameObject> messMakerObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()    
    {
        scoreText.text = startPoints.ToString();
        timeLeft = timerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        // Timer
        if (gameStarted && !gameEnded)
        {
            timeLeft -= Time.deltaTime;
            timeLeftText.text = "Time Left: " + Mathf.Round(timeLeft).ToString() + "s";
            scoreText.text = "Score: " + startPoints.ToString();
        }

        if (timeLeft <= 0 && !gameEnded)
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        gameEnded = false;
        startPoints = 0;

        // Timer
        timeLeft = timerDuration;

        for (int i = 0; i < messMakerObjects.Count; i++)
        {
            messMakerObjects[i].GetComponent<MessMaker>().SpawnMess();
        }

        btn.SetActive(false);

        Debug.Log("Started");
    }

    public void EndGame()
    {
        scoreText.text = "Game Ended!\nYou scored: " + startPoints.ToString();
        gameEnded = true;
        gameStarted = false;

        for (int i = 0; i < messMakerObjects.Count; i++)
        {
            messMakerObjects[i].GetComponent<MessMaker>().DespawnMess();
        }

        btnText.text = "Restart!";
        btn.SetActive(true);
        Debug.Log("GAME IS OVER!");
    }
}
