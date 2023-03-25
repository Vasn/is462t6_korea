using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int pourThreshold = 90;
    public GameObject streamPrefab = null;

    private bool isPouring = false;

    private void Update(){
        bool pourCheck = CalculatePourAngle() > pourThreshold;
        if (isPouring != pourCheck){
            isPouring = pourCheck;
            if (isPouring){
                StartPour();
            }
            else{
                EndPour();
            }
        }
    }

    private void StartPour(){
        print("Start");
        // create streamPrefab object at origin
        // streamPrefab has to be a child
        // of the object this script is attached to
        // so that it rotates with the object
        // and the stream is always facing the camera

        var newObject = Instantiate(streamPrefab);
        newObject.transform.parent = transform;
        newObject.transform.localPosition = Vector3.zero;
        
        

    }

    private void EndPour(){
        print("End");
        // destroy streamPrefab object
        Destroy(transform.GetChild(0).gameObject);

    }

    private float CalculatePourAngle(){
        float angle = Vector3.Angle(transform.up, Vector3.up);
        return angle;
    }

}
