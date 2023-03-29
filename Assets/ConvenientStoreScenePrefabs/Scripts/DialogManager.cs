using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject checkoutArea;
    private List<string> sentencesList = new List<string>();
    private int currentSentence = -1;
    // Start is called before the first frame update
    private bool inProgress = false;


    void Start()
    {
        // sentences = new Queue<string>();
        // Add sentences to the list
        sentencesList.Add("Good Morning! How may I help you?");
        sentencesList.Add("Do you need a plastic bag? It's 10 cents.");
        sentencesList.Add("The total is $10.50. Pay with cash or card?");
        sentencesList.Add("Thank you for shopping at our store!");
        Debug.Log("sentencesList.Count: " + sentencesList.Count);

    }

    public void goToNext(){
        Debug.Log("goToNext");
        DisplayNextSentence();
    }

    public void goToPrevious(){
        Debug.Log("goToPrevious");
        DisplayPreviousSentence();
    }

    public void DisplayNextSentence()
    {
        // string sentence = sentences.Dequeue();
        currentSentence++;
        if (currentSentence > sentencesList.Count - 1)
        {
            // Disable the dialog box
            this.gameObject.SetActive(false);
            // currentSentence = -1;
            return;
        }
        string sentence = sentencesList[currentSentence];
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayCurrentSentence()
    {
        // string sentence = sentences.Dequeue();
        string sentence = sentencesList[currentSentence];
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayPreviousSentence()
    {
        // string sentence = sentences.Dequeue();
        currentSentence--;
        string sentence = sentencesList[currentSentence];
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = sentence;
        dialogText.maxVisibleCharacters = 0;
        while (dialogText.maxVisibleCharacters < sentence.Length)
        {
            dialogText.maxVisibleCharacters += 1;
            Debug.Log("dialogText.maxVisibleCharacters: " + dialogText.maxVisibleCharacters);
            yield return new WaitForSeconds(0.05f);
        }
        inProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if this is active
        if (this.gameObject.activeSelf)
        {
            // Check if the index is -1
            if (currentSentence == -1 && !inProgress)
            {
                // Display the first sentence
                inProgress = true;
                // DisplayNextSentence();
            }
            // Check if the index is 0
            if (currentSentence == 0)
            {
                // Disable the left button
                LeftButton.SetActive(false);
                RightButton.SetActive(true);
            }
            else if (currentSentence == sentencesList.Count - 1)
            {
                // Disable the right button
                LeftButton.SetActive(false);
                RightButton.SetActive(false);
            }
            else
            {
                if (currentSentence >= 1 && !inProgress){
                    checkoutArea.GetComponent<CheckoutAreaManager>().placeBasket();
                }
                if (currentSentence >= 2 && !inProgress){
                    checkoutArea.GetComponent<CheckoutAreaManager>().clearItemsInBasket();
                } 
                if (currentSentence >= 3 && !inProgress){
                    checkoutArea.GetComponent<CheckoutAreaManager>().removeBasket();
                }
                LeftButton.SetActive(true);
            }
            
        }
    }

    public void pickUpBasket()
    {
        checkoutArea.GetComponent<CheckoutAreaManager>().pickUpBasket();
    }

    public bool checkIfComplete()
    {
        if (currentSentence == sentencesList.Count - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Reset() {
        inProgress = false;
    }

}
