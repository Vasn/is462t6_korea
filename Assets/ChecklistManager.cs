using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ChecklistManager : MonoBehaviour
{
    public bool ramen;
    public bool soju;
    public bool toothpaste;
    public TextMeshProUGUI checklistText;

    private string tobuy;
    private string bought;
    // Start is called before the first frame update
    void Start()
    {
        ramen=false;
        soju=false;
        toothpaste=false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ramen")
        {
            ramen = true;
        }
        if (collision.gameObject.tag == "Soju")
        {
            soju = true;
        }
        if (collision.gameObject.tag == "Toothpaste")
        {
            toothpaste = true;
        }

        Destroy(collision.gameObject);
        //Debug.Log("Ramen: " + ramen + " Soju: " + soju + " Toothpaste: " + toothpaste);
    // build the chceklist strings
        tobuy = "To buy: \n";
        bought = "\nBought: \n";
        if (soju == true)
        {
            bought += "1. Soju \n";
        }
        else
        {
            tobuy += "1. Soju \n";
        }

        if (ramen == true)
        {
            bought += "2. Instant Ramen \n";
        }
        else
        {
            tobuy += "2. Instant Ramen \n";
        }

        if (toothpaste == true)
        {
            bought += "3. Toothpaste \n";
        }
        else
        {
            tobuy += "3. Toothpaste \n";
        }

        string compiled = tobuy +"\n"+ bought;
        checklistText.text = compiled.Replace("\n", Environment.NewLine);
    }
}
