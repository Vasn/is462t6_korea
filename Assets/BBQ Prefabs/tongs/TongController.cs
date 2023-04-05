using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongController : MonoBehaviour
{
    public GameObject TongLeft;
    public GameObject TongRight;
    public GameObject SnapPoint;
    public bool isClosed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // print out the item the object is colliding with based on box collider



        
    }



    public void CloseTong()
    {
        // Play animation of TongLeft
        if (isClosed == false) {
            TongLeft.GetComponent<Animation>().Play("TongLeftClose");
            TongRight.GetComponent<Animation>().Play("TongRightClose");
            print("Tong Closed");
            
            




            isClosed = true;
        }
    }

    public void OpenTong()
    {
        // Reset animation to start
        if (isClosed == true) {
            TongLeft.GetComponent<Animation>().Play("TongLeftOpen");
            TongRight.GetComponent<Animation>().Play("TongRightOpen");
            print("Tong Opened");
            isClosed = false;
        }
    }
}
