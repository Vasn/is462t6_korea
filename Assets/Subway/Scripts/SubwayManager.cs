using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayManager : MonoBehaviour
{    
    private GameObject button;
    private GameObject innerLeft;
    private GameObject innerRight;
    private GameObject outerLeft;
    private GameObject outerRight;

    private bool trainMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("/Subway/Mutable/Subway/ButtonRound/GFX/InnerButton");
        innerLeft = GameObject.Find("/Subway/Mutable/Subway/TriggerLeft");
        innerRight = GameObject.Find("/Subway/Mutable/Subway/TriggerRight");
        outerLeft = GameObject.Find("/TrainStationDoor/OpenDoor/TriggerLeft");
        outerRight = GameObject.Find("/TrainStationDoor/OpenDoor/TriggerRight");
    }

    // Update is called once per frame
    void Update()
    {
        if (button.activeInHierarchy == false){
            if (!trainMoving){
                innerLeft.GetComponent<DoorManager>().enabled = true;
                innerRight.GetComponent<DoorManager>().enabled = true;
                outerLeft.GetComponent<DoorManager>().enabled = true;
                outerRight.GetComponent<DoorManager>().enabled = true;
            }
            else {
                innerLeft.GetComponent<DoorManager>().enabled = false;
                innerRight.GetComponent<DoorManager>().enabled = false;
                outerLeft.GetComponent<DoorManager>().enabled = false;
                outerRight.GetComponent<DoorManager>().enabled = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("attack");
        }
    }
    
}