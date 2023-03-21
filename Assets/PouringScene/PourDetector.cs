using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int pourThreshold = 30;
    public GameObject streamPrefab = null;

    private bool isPouring = false;

    private void Update(){
        print(CalculatePourAngle());
        bool pourCheck = Math.Abs(CalculatePourAngle()) > pourThreshold;
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

    private float CalculatePourAngle()
    {
        var xAngle = Math.Abs(transform.rotation.x * Mathf.Rad2Deg);
        var yAngle = Math.Abs(transform.rotation.z * Mathf.Rad2Deg);
        return Math.Max(xAngle, yAngle);
    }

}
