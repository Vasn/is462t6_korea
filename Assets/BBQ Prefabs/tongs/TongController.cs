using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongController : MonoBehaviour
{
    public GameObject TongLeft;
    public GameObject TongRight;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseTong()
    {
        // Play animation of TongLeft
        TongLeft.GetComponent<Animation>().Play("TongLeftClose");
        TongRight.GetComponent<Animation>().Play("TongRightClose");
        
    }

    public void OpenTong()
    {
        // Reset animation
        TongLeft.GetComponent<Animation>().Rewind();
        TongRight.GetComponent<Animation>().Rewind();
        TongLeft.GetComponent<Animation>().Stop("TongLeftClose");
        TongRight.GetComponent<Animation>().Stop("TongRightClose");
        
    }
}
