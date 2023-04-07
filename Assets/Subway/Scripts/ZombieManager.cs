using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public AudioClip zombieSound;
    public AudioClip hitSound;
    public float minSoundInterval = 1f;
    public float maxSoundInterval = 3f;
    
    private AudioSource audioSource;
    private float nextSoundTime;

    // Start is called before the first frame update
    void Start(){
        audioSource = GetComponent<AudioSource>();
        nextSoundTime = Time.time + Random.Range(minSoundInterval, maxSoundInterval);
    }

    void Update () {
        if (Time.time >= nextSoundTime) {
            audioSource.PlayOneShot(zombieSound);
            SetNextSoundTime();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Hand")) {
            audioSource.PlayOneShot(hitSound);
        }
    }

    void SetNextSoundTime() {
        nextSoundTime = Time.time + Random.Range(minSoundInterval, maxSoundInterval);
    }
}
