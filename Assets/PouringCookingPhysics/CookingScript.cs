using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // When this object touches another object tagged "Stove" for 5 seconds, change the color of the object to red
    // after another 5 seconds, change the color to black
    // code begins
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Stove")
        {
            StartCoroutine(ChangeColor(Color.red, 5));
            StartCoroutine(ChangeColor(Color.black, 10));
        }
    }

    IEnumerator ChangeColor(Color color, float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Renderer>().material.color = color;
    }

    
}
