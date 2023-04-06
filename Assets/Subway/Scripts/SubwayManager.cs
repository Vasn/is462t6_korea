using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip goodluckSound;
    
    private GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("/Subway/Mutable/Subway/ButtonRound/GFX/InnerButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("attack");
            audioSource.clip = goodluckSound;
            audioSource.Play();
        }
    }
    
}
