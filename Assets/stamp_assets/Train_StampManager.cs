using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Train_StampManager : MonoBehaviour
{
    // access the StampManager class, get the time variable from this script
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
        StartCoroutine(PlayAnnouncement());
        
    }

    // Update is called once per frame
    void Update()
    {
        // if not playing, set the time variable in StampManager to the time variable in this script
        if (!train_announcer.isPlaying)
        {
            stampManager.time = 0;
        }
    }
    //  play announcements corouting loops through the train_announcements array and plays them with a 5 second gap between each clip
    IEnumerator PlayAnnouncement()
    {
        while(!stampManager.completed){
            for (int i = 0; i < train_announcements.Length; i++)
            {
                stampManager.time=0;
                Debug.Log("====Playing announcement====");
                Debug.Log(train_announcements[i].name);
                train_announcer.clip = train_announcements[i];
                train_announcer.Play();
                // wait until the audio clip is finished playing
                yield return new WaitForSeconds(train_announcer.clip.length+10);
                
            }
        }
    }

    void OnTriggerEnter(Collider other){
        // if the object of this script collides with box with "scoreZone" tag, stop timer and change "completed" in StampManager to true
        if(other.gameObject.tag == "scoreZone"){
            Debug.Log($"This is the clip: {train_announcer.clip.name}");
            // if the audio clip playing currently is the 2nd one, the scene is completed
            if(train_announcer.clip == train_announcements[1]){
                stampManager.completed = true;
            }else{
                Debug.Log("This is not the right stop bro");
            }
        }

    }

    void OnCollisionEnter(Collision other){
        // IF other is tagged "zombie", add 10s to stampManager.time
        if(other.gameObject.tag == "Zombie"){
            stampManager.time += 10;
        }
    }


}
