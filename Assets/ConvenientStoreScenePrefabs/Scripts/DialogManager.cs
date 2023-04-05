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
    public GameObject Cashier;
    private List<string> sentencesList = new List<string>();
    private List<string> leftOptionsList = new List<string>();
    private List<string> rightOptionsList = new List<string>();
    private int currentSentence = -1;
    // Start is called before the first frame update
    private bool inProgress = false;


    void Start()
    {
        // sentences = new Queue<string>();
        // Add sentences to the list
        sentencesList.Add("안녕하세요 어떻게 도와드릴까요?\nHello! How may I help you?");
        sentencesList.Add("봉투 필요하세요? 100원입니다\nDo you need a plastic bag, it will be 100won!");
        sentencesList.Add("9천 900원 입니다. 현금아니면 카드로 결제하시겠어요?\nThat will be 9900won. Pay by Cash or Card?");
        sentencesList.Add("감사합니다! 좋은 하루되세요!\nThank you for shopping with us! Have a nice day!");
        
        // Add left options to the list
        leftOptionsList.Add("");
        leftOptionsList.Add("Yes");
        leftOptionsList.Add("");
        leftOptionsList.Add("");

        // Add right options to the list
        rightOptionsList.Add("Next");
        rightOptionsList.Add("No");
        rightOptionsList.Add("Card");
        rightOptionsList.Add("");
        
        Debug.Log("sentencesList.Count: " + sentencesList.Count);
    }

    public void goToNext(){
        Debug.Log("goToNext");
        // Insert checks update the options accordingly
        DisplayNextSentence();
        renderOptions();
    }

    public void goToPrevious(){
        Debug.Log("goToPrevious");
        DisplayPreviousSentence();
        renderOptions();
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
        // Play the audio
        Cashier.GetComponent<CashierInteractable>().playAudio(currentSentence);
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayCurrentSentence()
    {
        // string sentence = sentences.Dequeue();
        string sentence = sentencesList[currentSentence];
        // Play the audio
        Cashier.GetComponent<CashierInteractable>().playAudio(currentSentence);
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayPreviousSentence()
    {
        // string sentence = sentences.Dequeue();
        currentSentence--;
        string sentence = sentencesList[currentSentence];
        // Play the audio
        Cashier.GetComponent<CashierInteractable>().playAudio(currentSentence);
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

    void renderOptions()
    {
        string leftOption = leftOptionsList[currentSentence];
        string rightOption = rightOptionsList[currentSentence];

        //If currentsentence is 1, change Left Button's action to recyclableBag
        if (currentSentence == 1)
        {
            LeftButton.GetComponent<UIButtonClick>().ChangeAction("noBag");
            RightButton.GetComponent<UIButtonClick>().ChangeAction("yesBag");
        }
        else
        {
            LeftButton.GetComponent<UIButtonClick>().ChangeAction("previous");
            RightButton.GetComponent<UIButtonClick>().ChangeAction("next");
        }

        if (leftOption == "")
        {
            // Disable the left button
            LeftButton.SetActive(false);
        }
        else
        {
            // Enable the left button
            LeftButton.SetActive(true);
            // Render the left option
            LeftButton.GetComponent<UIButtonClick>().ChangeText(leftOption);
        }
        if (rightOption == "")
        {
            // Disable the right button
            RightButton.SetActive(false);
        }
        else
        {
            // Enable the right button
            RightButton.SetActive(true);
            // Render the right option
            RightButton.GetComponent<UIButtonClick>().ChangeText(rightOption);
        }
    }

    public void noBag()
    {
        // Spawn the Recyclable Bag
        checkoutArea.GetComponent<CheckoutAreaManager>().spawnItems();
        // go to next sentence
        goToNext();
    }

    public void yesBag()
    {
        // Spawn the Plastic Bag
        checkoutArea.GetComponent<CheckoutAreaManager>().spawnPlasticBag();
        // go to next sentence
        goToNext();
    }

}
