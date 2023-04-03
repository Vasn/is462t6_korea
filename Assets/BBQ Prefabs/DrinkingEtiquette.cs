using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class DrinkingEtiquette : MonoBehaviour
    {
        public bool isDrinking = false;
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (isDrinking == true) {
                // check if y rotation is less than -45 degrees and 
                if (transform.eulerAngles.y > 135 && transform.eulerAngles.y < 225) {
                    // play animation
                    print("You are not drinking with etiquette!");
                }
            }
        }
    }

