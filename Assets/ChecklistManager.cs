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

    public Transform ramenTransform;
    public Transform sojuTransform;
    public Transform toothpasteTransform;

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

    void OnTriggerEnter(Collider other)
    {
        // make the object a child of the collided object, set rotation to 0 and go to each tag's position. disable rigidbody and collider
        
        if (other.gameObject.tag == "Ramen")
        {
            if(!ramen){
                ramen = true;
                other.gameObject.transform.SetParent(this.transform);
                other.gameObject.transform.rotation = Quaternion.identity;
                other.gameObject.transform.position = ramenTransform.position;
                // destroy rigidbody and collider
                Destroy(other.gameObject.GetComponent<Rigidbody>());
                other.gameObject.GetComponent<Collider>().enabled = false;
            }
            
        }
        if (other.gameObject.tag == "Soju")
        {
            if(!soju){
                soju = true;
                other.gameObject.transform.SetParent(this.transform);
                other.gameObject.transform.rotation = Quaternion.identity;
                other.gameObject.transform.position = sojuTransform.position;
                Destroy(other.gameObject.GetComponent<Rigidbody>());
                other.gameObject.GetComponent<Collider>().enabled = false;
            }
        }
        if (other.gameObject.tag == "Toothpaste")
        {
            if(!toothpaste){
                ramen = true;
                other.gameObject.transform.SetParent(this.transform);
                other.gameObject.transform.rotation = Quaternion.identity;
                other.gameObject.transform.position = toothpasteTransform.position;
                Destroy(other.gameObject.GetComponent<Rigidbody>());
                other.gameObject.GetComponent<Collider>().enabled = false;
            }
        }

        Debug.Log("Ramen: " + ramen + " Soju: " + soju + " Toothpaste: " + toothpaste);
        //  build the chceklist strings
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

        Debug.Log("Ramen: " + ramen + " Soju: " + soju + " Toothpaste: " + toothpaste);
       
        
    }

    public void update_me(GameObject grabbable)
    {
        if (grabbable.tag == "Ramen")
        {
            ramen = true;
        }
        if (grabbable.tag == "Soju")
        {
            soju = true;
        }
        if (grabbable.tag == "Toothpaste")
        {
            toothpaste = true;
        }

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

        Debug.Log("Ramen: " + ramen + " Soju: " + soju + " Toothpaste: " + toothpaste);
    }
}
