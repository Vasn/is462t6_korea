using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiquidVolumeFX;

public class GuestChecker : MonoBehaviour
{
    public GameObject guestSojuAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get level from the liquid settings in liquid volume script
        guestSojuAmount.GetComponent<UnityEngine.UI.Text>().text = (this.GetComponent<LiquidVolume>().level * 100).ToString();

    }
}
