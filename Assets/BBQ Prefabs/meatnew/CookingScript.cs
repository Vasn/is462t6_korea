using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingScript : MonoBehaviour
{   

    // array of materials
    public Material[] cook;
    public Material[] burn;
    
    // ui object
    public GameObject cookAmount;
    public GameObject burnAmount;
    


    // Start is called before the first frame update
    void Start()
    {

        // set meshrenderer's second material to materials[0]
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // change cookAmount's text, to increase the number by 1
        // code begins
    }
    // When this object touches another object tagged "Stove" for 5 seconds, change the color of the object to red
    // after another 5 seconds, change the color to black
    // code begins
    void OnCollisionEnter(Collision collision)
    {
        // change meshrenderer's second material to materials[0]
        
        



        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Stove")
        {
            StartCoroutine(ChangeColor(cook, 5));
            StartCoroutine(ChangeColor(burn, 10));
        }
    }

    IEnumerator ChangeColor(Material[] materials, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (materials == cook)
        {
            cookAmount.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(cookAmount.GetComponent<UnityEngine.UI.Text>().text) + 1).ToString();
        }
        else
        {
            burnAmount.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(burnAmount.GetComponent<UnityEngine.UI.Text>().text) + 1).ToString();
            cookAmount.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(cookAmount.GetComponent<UnityEngine.UI.Text>().text) - 1).ToString();
        }
        GetComponent<MeshRenderer>().materials = materials;
    }

    
}
