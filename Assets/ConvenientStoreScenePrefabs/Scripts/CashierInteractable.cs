using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEditor.Animations;

public class CashierInteractable : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CashierDialogue;
    public GameObject Cashier;
    protected Animator CashierAnimator;
    private bool started = false;

    [SerializeField]
    private RuntimeAnimatorController CashierIdle;
    [SerializeField]
    private RuntimeAnimatorController CashierTalk;

    // Add cashier's audio here
    [SerializeField]
    private AudioClip[] CashierAudio;

    // Audio Source
    public AudioSource audioSource;

    public GameObject BGMAudioSource;
    private AudioSource BAudioSource;


    void Start()
    {
        CashierDialogue.SetActive(false);
        // Set Cashier Animator to Idle
        CashierAnimator = Cashier.GetComponent<Animator>();
        CashierAnimator.runtimeAnimatorController = CashierIdle as RuntimeAnimatorController;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CashierDialogue.SetActive(true);
            CashierAnimator.runtimeAnimatorController = CashierTalk as RuntimeAnimatorController;
            if (!started)
            {
                CashierDialogue.GetComponent<DialogManager>().DisplayNextSentence();
                started = true;
            }
            else
            {
                CashierDialogue.GetComponent<DialogManager>().DisplayCurrentSentence();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!CashierDialogue.GetComponent<DialogManager>().checkIfComplete())
            {
                CashierDialogue.GetComponent<DialogManager>().pickUpBasket();
            }
            // CashierDialogue.GetComponent<DialogManager>().Reset();
            CashierDialogue.SetActive(false);
            CashierAnimator.runtimeAnimatorController = CashierIdle as RuntimeAnimatorController;
            
        }
    }

    public void playAudio(int index)
    {
        // Initialize audio source
        Debug.Log("playAudio");
        Debug.Log("index: " + index);
        audioSource.clip = CashierAudio[index];

        // Get BGM Audio Source
        BAudioSource = BGMAudioSource.GetComponent<AudioSource>() as AudioSource;
        Debug.Log("BAudioSource: " + BAudioSource);
        // Pause BGM
        BAudioSource.enabled = false;
        // Play Cashier Audio Once
        audioSource.PlayOneShot(audioSource.clip);
        // Resume BGM
        BAudioSource.enabled = true;
    }
}
