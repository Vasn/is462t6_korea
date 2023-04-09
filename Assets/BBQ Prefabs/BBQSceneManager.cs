using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBQSceneManager : MonoBehaviour
{
    public GameObject firstAmount;
    public GameObject secondAmount;
    public GameObject thirdAmount;
    public GameObject fourthAmount;
    public GameObject timer;
    
    // integer score
    public int score;
    
    // boolean ifWon
    public bool ifOver = false;
    // Start is called before the first frame update
    public GameObject stampManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown from 2 minutes
        timer.GetComponent<UnityEngine.UI.Text>().text = (10 - Time.timeSinceLevelLoad).ToString("F0");
        if (timer.GetComponent<UnityEngine.UI.Text>().text == "0")
        {
            // Game over
            if (ifOver == false) {
                AddScore();
            }
            ifOver = true;

        }
    }
    
    public void AddScore()
    {
        ifOver = true;
        if (ifOver)
        {
            if (firstAmount.GetComponent<UnityEngine.UI.Text>().text == "0")
            {
                if (fourthAmount.GetComponent<UnityEngine.UI.Text>().text == "6")
                {
                    score += 1;
                }
            }
            if (secondAmount.GetComponent<UnityEngine.UI.Text>().text == "100")
            {
                score += 1;
            }
            if (thirdAmount.GetComponent<UnityEngine.UI.Text>().text == "100")
            {
                score += 1;
            }
            {
                // You lose
            }

            if (score <= 1)
            {
                stampManager.GetComponent<StampManager>().setStars(1);
            }
            else if (score == 2)
            {
                stampManager.GetComponent<StampManager>().setStars(2);
            }
            else if (score == 3)
            {
                stampManager.GetComponent<StampManager>().setStars(3);
            }
            
        }
    }
    
    
}
