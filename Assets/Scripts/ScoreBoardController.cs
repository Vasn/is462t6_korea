using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardController : MonoBehaviour
{
    //public TextMeshPro scoreText;
    public GameObject scoreText;
    public static int startPoints = 0;
    public GameObject stampManagerObject;

    // For game timer
    private bool gameStarted = false;
    private bool gameEnded = false;
    public float timerDuration = 100.0f; // 60 seconds
    private float timeLeft;
    //public TextMeshPro timeLeftText;
    public GameObject timeLeftText;
    public GameObject btn;
    public GameObject popUpText;

    // Mess Makers
    public List<GameObject> messMakerObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()    
    {
        //scoreText.text = "Score: " + startPoints.ToString();
        timeLeft = timerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        // Timer
        if (gameStarted && !gameEnded)
        {
            timeLeft -= Time.deltaTime;
            //timeLeftText.text = "Time Left: " + Mathf.Round(timeLeft).ToString() + "s";
            //scoreText.text = "Score: " + startPoints.ToString();

            timeLeftText.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + Mathf.Round(timeLeft).ToString() + "s";
            scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + startPoints.ToString();
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
        popUpText.SetActive(true);

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
        //scoreText.text = "Game Ended! Score: " + startPoints.ToString();
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Final Score: " + startPoints.ToString();
        timeLeftText.GetComponent<UnityEngine.UI.Text>().text = "GAME OVER!";
        gameEnded = true;
        gameStarted = false;
        popUpText.SetActive(false);

        for (int i = 0; i < messMakerObjects.Count; i++)
        {
            messMakerObjects[i].GetComponent<MessMaker>().DespawnMess();
        }

        //btn.SetActive(true);
        startPoints+=1;
        // Debug.Log(Mathf.Min(startPoints/4,3));

        stampManagerObject.GetComponent<StampManager>().setStars(Mathf.Min(Mathf.Max(1,startPoints/4),3));
        Debug.Log("GAME IS OVER!");
    }
}
