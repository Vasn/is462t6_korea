using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedPlayback : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    void Start()
    {
        // Wait for audioSource1 to finish playing before playing audioSource2

        // audioSource2
        audioSource2.volume = 0.01f;
        StartCoroutine(WaitForAudioSource1ToFinishPlaying());
    }

    IEnumerator WaitForAudioSource1ToFinishPlaying()
    {
        while (audioSource1.isPlaying)
        {
            yield return null;
        }
        audioSource2.volume= 0.2f;
    }
}
