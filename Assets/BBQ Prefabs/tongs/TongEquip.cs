using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class TongEquip : MonoBehaviour
{
    public GameObject Tong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // get the nearest object with tag "meat" and make it a child of the tong
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Meat")){
            if (Tong.GetComponent<TongController>().isClosed == true) {
                // Get script called "SnapZone"
                other.gameObject.GetComponent<CookingScript>().isColliding = false;
                print (other.gameObject.tag);
                


                // disable rigidbody and collider
                Destroy(other.gameObject.GetComponent<Rigidbody>());
                
                other.gameObject.GetComponent<Collider>().enabled = false;

                // make the object a child of the tong
                other.gameObject.transform.SetParent(this.transform);
            }
        }
    }


    public void ReleaseObject()
    {
        if (this.transform.childCount == 1) {
            
        
            // get the object that is a child of the tong
            GameObject Picked = this.transform.GetChild(0).gameObject;
            // add back rigidbody
            Picked.AddComponent<Rigidbody>();
            Picked.GetComponent<Collider>().enabled = true;

            // unparent the object
            Picked.transform.SetParent(null);
        }
    }
}
