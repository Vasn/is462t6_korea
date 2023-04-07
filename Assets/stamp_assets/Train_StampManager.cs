using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Train_StampManager : MonoBehaviour
{
    // access the StampManager class, get the time variable from this script
    private bool gameStart = false;
    private bool trainMoving = false;
    private bool exitTrain = false;

    // private string hitObject;
    
    private Vector3 initialPosition;
    private GameObject spawn;
    private GameObject playerControl;

    private GameObject innerLeft;
    private GameObject innerRight;
    private GameObject outerLeft;
    private GameObject outerRight;

    public StampManager stampManager;

    public AudioClip trainMoveSound;

    [Tooltip("This holds the audioSource for the train announcements")]
    public AudioSource train_announcer;
    [Tooltip("This holds the announcement MP3 files")]
    public AudioClip[] train_announcements;
    
    // Start is called before the first frame update
    void Start()
    {
        // call on the function "PlayAnnouncement". Call when done until stampManager.completed becomes true
        innerLeft = GameObject.Find("/Subway/Mutable/Subway/TriggerLeft");
        innerRight = GameObject.Find("/Subway/Mutable/Subway/TriggerRight");
        outerLeft = GameObject.Find("/TrainStationDoor/OpenDoor/TriggerLeft");
        outerRight = GameObject.Find("/TrainStationDoor/OpenDoor/TriggerRight");
        spawn = GameObject.Find("Spawn");
        playerControl = GameObject.Find("/XR Rig Advanced/PlayerController");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart){
            if (GameObject.Find("FloorTwo").activeInHierarchy == true){
                StartCoroutine(PlayAnnouncement());
                gameStart = true;
                stampManager.time=0;
            } else {
                Debug.Log("Game has not started");
            }
        }
    }
    //  play announcements corouting loops through the train_announcements array and plays them with a 5 second gap between each clip
    IEnumerator PlayAnnouncement()
    {
        while(!exitTrain){
            for (int i = 0; i < train_announcements.Length; i++)
            {
                trainMoving = true;
                if (trainMoving){
                    train_announcer.clip = trainMoveSound;
                    train_announcer.Play();
                    SetDoorManagerComponentsEnabled(false);
                    Debug.Log("====Train Moving====");
                    yield return new WaitForSeconds (5);
                }
                Debug.Log("====Playing announcement====");
                Debug.Log(train_announcements[i].name);
                train_announcer.clip = train_announcements[i];
                train_announcer.Play();
                trainMoving = false;
                SetDoorManagerComponentsEnabled(true);
                // wait until the audio clip is finished playing
                yield return new WaitForSeconds(train_announcer.clip.length+5);
            }
            if (exitTrain){
                break;
            }
        }

    }

    IEnumerator Delay()
    {
        stampManager.time += 10;
        yield return new WaitForSeconds(2);
        Debug.Log("Time added 10.");
    }

    void OnTriggerEnter(Collider other){
        // if the object of this script collides with box with "scoreZone" tag, stop timer and change "completed" in StampManager to true
        // hitObject = other.gameObject.tag;
        // Debug.Log(hitObject);        
        if(other.gameObject.CompareTag("scoreZone")){
            Debug.Log("Reached scorezone, filter to next stage.");
            stampManager.completed = true;
        }
        if(other.gameObject.CompareTag("Exit")){
            exitTrain = true;
            SetDoorManagerComponentsEnabled(false);
            Debug.Log($"This is the clip: {train_announcer.clip.name}");

            if(train_announcer.clip != train_announcements[1]){
                Debug.Log("Incorrect station, add 10 seconds to timer.");
                Vector3 position = spawn.transform.position;
                Debug.Log(position);
                playerControl.transform.position = position;
                StartCoroutine(Delay());
            } else {
                Debug.Log("Correct station, proceed with caution.");
                train_announcer.Stop();
            }            
        }    
    }

    void OnCollisionEnter(Collision other){
    // IF other is tagged "zombie", add 10s to stampManager.time
    // hitObject = other.gameObject.tag;
    // Debug.Log(hitObject);
        if(other.gameObject.tag == "zombie"){
            // train_announcer.clip = monsterTrigger;
            // train_announcer.Play();
            Debug.Log("Hit by zombie.");
            StartCoroutine(Delay());
        }
    }

    private void SetDoorManagerComponentsEnabled(bool isEnabled)
    {
        innerLeft.GetComponent<DoorManager>().enabled = isEnabled;
        innerRight.GetComponent<DoorManager>().enabled = isEnabled;
        outerLeft.GetComponent<DoorManager>().enabled = isEnabled;
        outerRight.GetComponent<DoorManager>().enabled = isEnabled;
    }
}