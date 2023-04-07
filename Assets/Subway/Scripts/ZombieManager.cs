using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public AudioClip backgroundSound;
    public AudioClip collisionSound;
    public float minBackgroundInterval = 3f;
    public float maxBackgroundInterval = 10f;

    private AudioSource audioSource;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundSound;
        audioSource.loop = true;
        audioSource.Play();
        StartCoroutine(PlayBackgroundSound());
    }

    IEnumerator PlayBackgroundSound() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minBackgroundInterval, maxBackgroundInterval));
            audioSource.Play();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Head")) {
            Debug.Log("collide in head");
            StopCoroutine("PlayBackgroundSound");
            audioSource.Stop();
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
