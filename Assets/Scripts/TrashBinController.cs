using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinController : MonoBehaviour
{
    public GameObject bin;
    public AudioSource feedbackAudioSource;
    public AudioClip[] wrongFeedback;
    public AudioClip[] correctFeedback;
    public GameObject dmg;
    public GameObject aura;
    public AudioClip dmgSound;
    public AudioClip correctSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Types of waste: 
        //General Waste
        //Glass(i.e.Beer bottles)
        //Cans(i.e.aluminium or Iron)
        //Paper(i.e.printing paper, magazines, newspaper, boxes, cartons, etc.) //Paper Pack(i.e.juice packs, milk packs, etc)
        //Plastic(NOT including Toys, stationery pens, small candy wraps)
        //PET Bottles
        //Vinyl(i.e.snack bags, dessert wraps, etc)
        //Food Waste (!!egg shells, crustacean shells(Crab, Lobster, Shrimp, etc), clam shells, onion and garlic paper - like skin, animal bones(beef, pork, chicken, lamb, etc), tea bags or tea leaves.All of these are considered GENERAL WASTE.)

        if (other.gameObject.CompareTag(bin.tag)) // For Food Waste
        {
            // THE FOLLOWING ARE CONSIDERED GENERAL WASTE
            // egg shells, crustacean shells(Crab, Lobster, Shrimp, etc), clam shells, onion and garlic paper - like skin, animal bones(beef, pork, chicken, lamb, etc), tea bags or tea leaves

            Debug.Log("CORRECT!! You have placed '" + other.tag + "' in a '" + bin.tag + "' bin.");
            ScoreBoardController.startPoints += 1;
            //feedbackAudioSource.clip = correctSound;
            //feedbackAudioSource.Play();
            aura.GetComponent<ParticleSystem>().Play();
            feedbackAudioSource.clip = correctFeedback[Random.Range(0, correctFeedback.Length)];
            feedbackAudioSource.Play();

        }
        else if (other.gameObject.CompareTag("Food") || other.gameObject.CompareTag("General") || other.gameObject.CompareTag("Can") || other.gameObject.CompareTag("Glass") || other.gameObject.CompareTag("Paper"))
        {
            Debug.Log("WRONG!! You have placed '" + other.tag + "' in a '" + bin.tag + "' bin.");
            ScoreBoardController.startPoints -= 1;
            //feedbackAudioSource.clip = dmgSound;
            //feedbackAudioSource.Play();
            dmg.GetComponent<ParticleSystem>().Play();
            feedbackAudioSource.clip = wrongFeedback[Random.Range(0, wrongFeedback.Length)];
            feedbackAudioSource.Play();

            //ParticleSystem.MainModule main = aura.gameObject.GetComponent<ParticleSystem>().main;
            //main.startColor = Color.red;
        }

    }

    //IEnumerator ExampleCoroutine()
    //{
    //    //Print the time of when the function is first called.
    //    //Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //    //yield on a new YieldInstruction that waits for 5 seconds.
    //    yield return new WaitForSeconds(2);

    //    //After we have waited 5 seconds print the time again.
    //    //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    //}
}
