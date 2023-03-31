using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DialogBox;
    public TextMeshProUGUI dialogText;
    public string action;
    private DialogManager dialogManager;
    void Start()
    {
        dialogManager = DialogBox.GetComponent<DialogManager>();
    }

    public void performClickAction()
    {
        switch (action)
        {
            case "previous":
                dialogManager.goToPrevious();
                break;
            case "next":
                dialogManager.goToNext();
                break;
            case "yesBag":
                dialogManager.yesBag();
                break;
            case "noBag":
                dialogManager.noBag();
                break;
            default:
                break;
        }
    }
    public void ChangeText(string text)
    {
        // Change the text of the button
        dialogText.text = text;
    }

    public void ChangeAction(string action)
    {
        // Change the action of the button
        this.action = action;
    }
}
