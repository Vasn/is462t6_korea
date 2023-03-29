using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DialogBox;
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
            default:
                break;
        }
    }
}
