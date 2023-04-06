using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChaser : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentObject;
    public GameObject playerHead;
    public string position;
    private Vector3 playerHeadPosWithOffset;

    void Start()
    {
        Move();
    }

    void getPositionVector()
    {
        if (position == "top right")
        {
            playerHeadPosWithOffset = new Vector3(playerHead.transform.position.x + 0.5f, playerHead.transform.position.y + 0.5f, playerHead.transform.position.z+0.5f);
        }
        else if (position == "top left")
        {
            playerHeadPosWithOffset = new Vector3(playerHead.transform.position.x - 0.5f, playerHead.transform.position.y + 0.5f, playerHead.transform.position.z+0.5f);
        }
        else if (position == "bottom right")
        {
            playerHeadPosWithOffset = new Vector3(playerHead.transform.position.x + 0.5f, playerHead.transform.position.y - 0.5f, playerHead.transform.position.z+0.5f);
        }
        else if (position == "bottom left")
        {
            playerHeadPosWithOffset = new Vector3(playerHead.transform.position.x - 0.5f, playerHead.transform.position.y - 0.5f, playerHead.transform.position.z+0.5f);
        }
    }

    void Move()
    {
        // Move the object to the player's head
        // currentObject.transform.position = playerHead.transform.position;
        getPositionVector();
        currentObject.transform.position = playerHeadPosWithOffset;
    }

    // Update is called once per frame
    void Update()
    {
        // Position of this object will be the position of the player's head with an offset 
        // depending on the position of the object
        Move();
    }
}
