using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ChecklistManager : MonoBehaviour
{
    public Transform anchor;
    public bool ramen;
    public bool soju;
    public bool chips;
    public TextMeshProUGUI checklistText;

    private string tobuy;
    private string bought;

    public Transform ramenTransform;
    public Transform sojuTransform;
    public Transform chipsTransform;

    // Start is called before the first frame update
    void Start()
    {
        ramen=false;
        soju=false;
        chips=false;

    }

    // Update is called once per frame
    void Update()
    {
        // fix this object's transform to anchor's transform
        // this.transform.position = anchor.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // make the object a child of the collided object, set rotation to 0 and go to each tag's position. disable rigidbody and collider
        
        if (other.gameObject.tag == "Ramen")
        {
            if(!ramen){
                ramen = true;
                instantiateRamenAtRamenTransform(other);
                // Destroy(other.gameObject.GetComponent<Rigidbody>());
                // other.gameObject.RemoveComponent<Grabbable>();
                // other.gameObject.GetComponent<Collider>().enabled = false;
                // other.gameObject.transform.rotation = Quaternion.identity;
                // // set this position to 0,0,0
                // // other.gameObject.transform.SetParent(ramenTransform.transform,false);
                // // other.gameObject.transform.position = ramenTransform.transform.position;
                // other.gameObject.transform.parent = ramenTransform;
                // other.gameObject.transform.localPosition = new Vector3(0,0,0);
                
            }
            
        }
        if (other.gameObject.tag == "Soju")
        {
            if(!soju){
                soju = true;
                instantiateSojuAtSojuTransform(other);
                // Destroy(other.gameObject.GetComponent<Rigidbody>());
                // other.gameObject.RemoveComponent<Grabbable>();
                // other.gameObject.GetComponent<Collider>().enabled = false;
                // other.gameObject.transform.rotation = Quaternion.identity;
                // // other.gameObject.transform.SetParent(sojuTransform.transform,false);
                // // other.gameObject.transform.position = sojuTransform.transform.position;
                // other.gameObject.transform.parent = sojuTransform;
                // other.gameObject.transform.localPosition = new Vector3(0,0,0);
                // other.gameObject.transform.position = new Vector3(0,0,0);
            }
        }
        if (other.gameObject.tag == "Chips")
        {
            if(!chips){
                chips = true;
                instantiateChipsAtChipsTransform(other);
                // Destroy(other.gameObject.GetComponent<Rigidbody>());
                // other.gameObject.RemoveComponent<Grabbable>();
                // other.gameObject.GetComponent<Collider>().enabled = false;
                // other.gameObject.transform.rotation = Quaternion.identity;
                // // other.gameObject.transform.SetParent(chipsTransform.transform,false);
                // // other.gameObject.transform.position = chipsTransform.transform.position;
                // other.gameObject.transform.parent = chipsTransform;
                // other.gameObject.transform.localPosition = new Vector3(0,0,0);
                // other.gameObject.transform.position = new Vector3(0,0,0);
                
            }
        }

        Debug.Log("Ramen: " + ramen + " Soju: " + soju + " Chips: " + chips);
        //  build the chceklist strings
        tobuy = "To buy: \n";
        bought = "\nBought: \n";
        if (soju){
            bought += "1. Soju \n";
        }else
        {
            tobuy += "1. Soju \n";
        }

        if (ramen){
            bought += "2. Instant Ramen \n";
        }else
        {
            tobuy += "2. Instant Ramen \n";
        }

        if (chips){
            bought += "3. Chips \n";
        }else
        {
            tobuy += "3. Chips \n";
        }

        string compiled = tobuy +"\n"+ bought;
        checklistText.text = compiled.Replace("\n", Environment.NewLine);

        Debug.Log("Ramen: " + ramen + " Soju: " + soju + " Chips: " + chips);
       
        
    }

    public bool getCheckoutEligibility(){
        if(ramen && soju && chips){
            return true;
        }else{
            return false;
        }
    }

    void instantiateRamenAtRamenTransform(Collider other){
        // instantiate ramen at ramenTransform, set parent to ramenTransform
        GameObject ramen = Instantiate(other.gameObject, ramenTransform.transform.position, Quaternion.identity);
        ramen.transform.parent = ramenTransform.transform;
        ramen.transform.position = ramenTransform.transform.position;
        ramen.transform.rotation = Quaternion.identity;
        // Remove all scripts component        
        ramen.GetComponent<Rigidbody>().isKinematic = true;
        ramen.GetComponent<BoxCollider>().enabled = false;

        // Destroy original
        Destroy(other.gameObject);
    }

    void instantiateSojuAtSojuTransform(Collider other){
        // instantiate ramen at ramenTransform, set parent to ramenTransform
        GameObject soju = Instantiate(other.gameObject, sojuTransform.transform.position, Quaternion.identity);
        soju.transform.parent = sojuTransform.transform;
        soju.transform.position = sojuTransform.transform.position;
        soju.transform.rotation = Quaternion.identity;
        soju.GetComponent<Rigidbody>().isKinematic = true;
        soju.GetComponent<BoxCollider>().enabled = false;
        // Destroy original
        Destroy(other.gameObject);
    }

    void instantiateChipsAtChipsTransform(Collider other){
        // instantiate ramen at ramenTransform, set parent to ramenTransform
        GameObject chips = Instantiate(other.gameObject, chipsTransform.transform.position, Quaternion.identity);
        chips.transform.parent = chipsTransform.transform;
        chips.transform.position = chipsTransform.transform.position;
        chips.transform.rotation = Quaternion.identity;
        chips.GetComponent<Rigidbody>().isKinematic = true;
        chips.GetComponent<BoxCollider>().enabled = false;
        // Destroy original
        Destroy(other.gameObject);
    }
}
