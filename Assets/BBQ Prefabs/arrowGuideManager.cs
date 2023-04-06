using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowGuideManager : MonoBehaviour
{   
    public static int tutorialStage = 0;
    public GameObject TongArrow;
    public GameObject MeatArrow;
    public GameObject GrillArrow;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // change arrow guide
        if(tutorialStage==1) {
            TongArrow.SetActive(false);
            MeatArrow.SetActive(true);
        } else if(tutorialStage==2) {
            MeatArrow.SetActive(false);
            GrillArrow.SetActive(true);
        } else{
            GrillArrow.SetActive(false);
        }
    }
}
