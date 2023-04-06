using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StampManager : MonoBehaviour
{
    [Tooltip("Array of scores for each scene. 1 means 1 star and so on")]
    public List<int> scores_placeholder;
    public static List<int> scores;

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
    
    // Start is called before the first frame update
    void Start()
    {

        // if scores_placeholder has elements inside, assign static scores with this value
        if(scores_placeholder.Count > 0){
            scores = scores_placeholder;
            Debug.Log("Stored scores");
        }

        Debug.Log("Start function called");
        Debug.Log("scores_placeholder count: " + scores_placeholder.Count);
        // initialise image list to be all the images for the different stars
        // stamps = new Texture[]{one_star, two_star, three_star};
        stamp_holders = new RawImage[]{stamp1, stamp2, stamp3, stamp4};
        // disable scoreboard and all the stars
        scoreboard.SetActive(false);
        completed=false;
        Scene_no = scores.Count;

    }

    // Update is called once per frame
    void Update()
    {
        if(completed){
            // enable scoreboard
            scoreboard.SetActive(true);
            // change the background to the current scene background
            scoreboard.GetComponent<Renderer>().material.mainTexture = scene_backgrounds[Scene_no];
            
            // Update the score array
            int new_score = time<threestartime?3:time<twostartime?2:1;
            for(int i = Scene_no - scores.Count+1; i > 0; i--)
            {
                scores.Add(new_score);
            }
            // enable stars based on time
            for (int i = 0; i < stamp_holders.Length; i++)
            {
                // if(Scene_no==0){
                //     stamp_holders[i].enabled = false;
                // }
                if(i <= Scene_no)
                {
                    stamp_holders[i].enabled = true;
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
            }
            
            
        }else{StopWatchCalc();}

        // FOR TESTING: REPLACE WITH YOUR WIN CONDITION
        if (Input.GetKeyDown(KeyCode.Space))
        {
            completed = true;
        }
        
    }

    void StopWatchCalc(){
        if(!completed){
            time+=Time.deltaTime;
        seconds = (int)(time % 60);
        minutes = (int)(time / 60) % 60;
        clocktext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

    }
}
