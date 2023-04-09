using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CreditManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject videoCanvas;
    // isPlaying
    private bool isPlaying = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(videoCanvas.GetComponent<VideoPlayer>().isPlaying == true)
        {
            isPlaying = true;
        }
        // When video reaches the end, load the main menu
        if (isPlaying && !videoCanvas.GetComponent<VideoPlayer>().isPlaying)
        {
            SceneManager.LoadScene(0);
        }
    }
}
