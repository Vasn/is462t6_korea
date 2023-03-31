using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip welcomeSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = welcomeSound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
