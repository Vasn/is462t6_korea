using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class CashierInteractable : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CashierDialogue;
    public GameObject Cashier;
    protected Animator CashierAnimator;

    [SerializeField]
    private RuntimeAnimatorController CashierIdle;
    [SerializeField]
    private RuntimeAnimatorController CashierTalk;


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
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CashierDialogue.SetActive(false);
            CashierAnimator.runtimeAnimatorController = CashierIdle as RuntimeAnimatorController;
            
        }
    }
}
