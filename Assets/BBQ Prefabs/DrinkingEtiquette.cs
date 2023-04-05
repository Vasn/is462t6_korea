using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class DrinkingEtiquette : MonoBehaviour
    {
        public bool isDrinking = false;
        public GameObject correctDrinkingAmount;
        float totalTime = 0.0f;
        float correctTime = 0.0f;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (isDrinking == true) {
                // check if y rotation is less than -45 degrees and 
                totalTime += Time.deltaTime;
                if (transform.eulerAngles.y > 135 && transform.eulerAngles.y < 225) {
                    // play animation
                }
                else {
                    correctTime += Time.deltaTime;
                }
                int percentage = (int)(((correctTime % 60) / (totalTime % 60)) * 100);
                correctDrinkingAmount.GetComponent<UnityEngine.UI.Text>().text = (percentage).ToString();
            }


        }
    }

