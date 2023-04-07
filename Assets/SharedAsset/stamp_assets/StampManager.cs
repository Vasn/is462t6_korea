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

    [Tooltip("This is the stamp for scn 1")]
    public RawImage stamp1;

    [Tooltip("This is the stamp for scn 2")]
    public RawImage stamp2;

    [Tooltip("This is the stamp for scn 3")]
    public RawImage stamp3;

    [Tooltip("This is the stamp for scn 4")]
    public RawImage stamp4;

    [Tooltip("This is the stamps rawimage objects on the scoreboard canvas")]
    private RawImage[] stamp_holders;

    [Tooltip("This is the background for each scene")]
    public Texture[] scene_backgrounds;
    
    [Tooltip("This is the no. of seconds for 3 stars")]
    public float threestartime;

    [Tooltip("This is the no. of seconds for 2 stars")]
    public float twostartime;
    
    public TextMeshProUGUI clocktext;

    public bool completed;

    public float time;
    private float minutes;
    private float seconds;

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
        Debug.Log("Current scene index: " + currentSceneIndex);

        // If score array is empty, initialise it
        if(scores == null){
            scores = new int[scenePaths.Length];
        }

        // if scores_placeholder has elements inside, assign static scores with this value
        // if(scores_placeholder.Count > 0){
        //     scores = scores_placeholder;
        // }

        // initialise image list to be all the images for the different stars
        // stamps = new Texture[]{one_star, two_star, three_star};
        stamp_holders = new RawImage[]{stamp1, stamp2, stamp3, stamp4};
        // disable scoreboard and all the stars
        scoreboard.SetActive(false);
        completed=false;
        Scene_no = currentSceneIndex;

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

            // Detach scoreboard from player
            // scoreboard.transform.SetParent(null, true);

            // change the background to the current scene background
            scoreboard.GetComponent<Renderer>().material.mainTexture = scene_backgrounds[Scene_no];
            
            // Update the score array
            // int new_score = time<threestartime?3:time<twostartime?2:1;
            // for(int i = Scene_no - scores.Count+1; i > 0; i--)
            // {
            //     scores.Add(new_score);
            // }

            // enable stars based on time
            for (int i = 0; i < stamp_holders.Length; i++)
            {
                if(i <= Scene_no)
                {
                    stamp_holders[i].enabled = true;
                    // Debug.Log("score: " + scores[i] + " Scene_no: " + Scene_no);
                    // change the stamp_holder texture to the correct texture depending on the score
                    if(scores[i] == 3){
                        stamp_holders[i].texture = stamps[2];

                    }
                    else if(scores[i] == 2){
                        stamp_holders[i].texture = stamps[1];
                    }
                    else{
                        stamp_holders[i].texture = stamps[0];
                    }
                }else{
                    stamp_holders[i].enabled = false;
                }
                if (Scene_no+1 < stamp_holders.Length){
                    // Set texture to black 
                    stamp_holders[Scene_no+1].color = new Color(0,0,0,0.8f);
                    stamp_holders[Scene_no+1].enabled = true;
                }
            }
            
            
        }else{StopWatchCalc();}

        // FOR TESTING: REPLACE WITH YOUR WIN CONDITION
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     completed = true;
        // }
        
    }

    public void setComplete(){
        int new_score = time<threestartime?3:time<twostartime?2:1;
        scores[Scene_no] = new_score;
        completed = true;
    }

    void StopWatchCalc(){
        if(!completed){
            time+=Time.deltaTime;
        seconds = (int)(time % 60);
        minutes = (int)(time / 60) % 60;
        clocktext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

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

    public void LoadNextScene()
    {
        if (currentSceneIndex < scenePaths.Length - 1)
        {
            currentSceneIndex++;
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            Debug.Log("No more next scenes to load");
        }
    }

    public void LoadPreviousScene()
    {
        if (currentSceneIndex > 0)
        {
            currentSceneIndex--;
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            Debug.Log("No more previous scenes to load");
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadSceneFromButton(GameObject button)
    {
        // Get button Name
        string buttonName = button.name;
        int sceneIndex = int.Parse(buttonName.Substring(buttonName.Length - 1)) -1;
        SceneManager.LoadScene(sceneIndex);
    }

    public void goToCreditScene()
    {
        LoadNextScene();
    }

    // Unity event to listen to when the player presses the menu button

    // IEnumerator TransitionToNextScene()
    // {
    //     yield return new WaitForSeconds(5);
    //     LoadNextScene();
    // }

}


