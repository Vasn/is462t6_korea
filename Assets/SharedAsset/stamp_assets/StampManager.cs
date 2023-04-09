using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
// using BNG;

public class StampManager : MonoBehaviour
{
    [Tooltip("Array of scores for each scene. 1 means 1 star and so on")]
    public List<int> scores_placeholder;
    public static int[] scores;

    [Tooltip("This is the screen that pops up when the scene is done object")]
    public GameObject scoreboard;

    [Tooltip("List of all the stamps")]
    public Texture[] stamps;

    [Tooltip("This is the scene number that the player is on. E.g. Intro = 0, Train=1, Store=2, BBQ=3, trash=4")]
    private int Scene_no;

    [Tooltip("This is the stamps rawimage objects on the scoreboard canvas")]
    public RawImage[] stamp_holders;

    [Tooltip("This is the button for each scene")]
    public Button[] scene_buttons;
    
    [Tooltip("This is the no. of seconds for 3 stars")]
    public float threestartime;

    [Tooltip("This is the no. of seconds for 2 stars")]
    public float twostartime;
    
    public TextMeshProUGUI clocktext;

    public bool completed;

    public float time;
    private float minutes;
    private float seconds;

    private bool started = false;

    //filepaths for scene management - we will load from build settings in same sequence
    private string[] scenePaths;
    private static int currentSceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        // initialise scene paths and set index
        scenePaths = new string[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < scenePaths.Length; i++)
        {
            scenePaths[i] = SceneUtility.GetScenePathByBuildIndex(i);
        }
        LogAllScenes();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Debug.Log("Current scene index: " + currentSceneIndex);

        // If score array is empty, initialise it
        if(scores == null){
            scores = new int[scenePaths.Length];
        }

        // initialise image list to be all the images for the different stars
        // stamps = new Texture[]{one_star, two_star, three_star};
        // stamp_holders = new RawImage[]{stamp1, stamp2, stamp3, stamp4};
        // disable scoreboard and all the stars
        scoreboard.SetActive(false);
        completed=false;
        Scene_no = currentSceneIndex;
        Debug.Log("Scene_no: " + Scene_no);
        LogAllScenes();
        // For testing purposes
        // Coroutine to wait 5 seconds and transition to next scene
        // StartCoroutine(TransitionToNextScene());

    }

    // Update is called once per frame
    void Update()
    {
        if(completed){
            // enable scoreboard
            scoreboard.SetActive(true);
            displayOptions();
        }
        else
        {
            if(started){
                StopWatchCalc();
            }
        }        
    }

    public void setComplete(){
        int new_score = time<threestartime?3:time<twostartime?2:1;
        scores[Scene_no] = new_score;
        Debug.Log("Scene_no: " + Scene_no + " new_score: " + new_score);
        completed = true;
        started = false;
    }

    public void StopWatchCalc(){
        if(!completed){
            time+=Time.deltaTime;
        seconds = (int)(time % 60);
        minutes = (int)(time / 60) % 60;
        clocktext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void startStopWatch(){
        started = true;
    }

    public void setStars(int stars){
        scores[Scene_no] = stars;
        completed = true;
    }

    void LogAllScenes()
    {
        Debug.Log("All scenes in build:");
        for (int i = 0; i < scenePaths.Length; i++)
        {
            Debug.Log(scenePaths[i]);
        }
    }

    public void LoadSceneFromButton(GameObject button)
    {
        // Get button Name
        string buttonName = button.name;
        int sceneIndex = int.Parse(buttonName.Substring(buttonName.Length - 1));
        SceneManager.LoadScene(sceneIndex);
    }

    public void goToCreditScene()
    {
        SceneManager.LoadScene(scenePaths.Length - 1);
    }

    public void displayOptions()
    {
        setStamps();
        for (int i = 0; i < scores.Length; i++)
        {
            Debug.Log("scores[" + i + "]: " + scores[i]);
        }
        // Based on scene number, display the correct options
        for (int i = 0; i < scene_buttons.Length; i++)
        {
            if (i <= Scene_no || scores[i+1] > 0)
            {
                // Get Scene Button GameObject
                GameObject scene_button = scene_buttons[i].gameObject;
                // Disable Scene Button
                scene_button.SetActive(true);
            }
            else
            {
                // Get Scene Button GameObject
                GameObject scene_button = scene_buttons[i].gameObject;
                // Disable Scene Button
                scene_button.SetActive(false);
            }

        }
    }

    public void setStamps()
    {
        // Based on scores array, set the stamps
        for (int i = 0; i < stamp_holders.Length; i++)
        {
            GameObject stampHolder = stamp_holders[i].gameObject;
            stampHolder.SetActive(true);
            if (scores[i+1] > 0)
            {
                // GameObject stamp = stamp_holders[i].gameObject;
                stamp_holders[i].texture = stamps[scores[i+1]-1];
            }
            else
            {
                stampHolder.SetActive(false);

            }
        }
    }

    // Unity event to listen to when the player presses the menu button

    // IEnumerator TransitionToNextScene()
    // {
    //     yield return new WaitForSeconds(5);
    //     LoadNextScene();
    // }

}


