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
    public bool isColliding = false;
    int cookingStage = 0;
    public float timer = 0f;

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
        if (isColliding)
        {
            timer += Time.deltaTime;
            UpdateCookingStage();
        }
    }
    // When this object touches another object tagged "Stove" for 5 seconds, change the color of the object to red
    // after another 5 seconds, change the color to black
    // code begins
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stove")
        {
            // change meshrenderer's second material to materials[0]
            isColliding = true;
        }

    }

    void OnCollisionExit(Collision collision){
        print("no longer cookin");
        isColliding = false;
    }

    void UpdateCookingStage(){
        if( timer > 10 && cookingStage == 1){
            cookingStage = 2;
            ChangeColor(burn);
            burnAmount.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(burnAmount.GetComponent<UnityEngine.UI.Text>().text) + 1).ToString();
            cookAmount.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(cookAmount.GetComponent<UnityEngine.UI.Text>().text) - 1).ToString();
        }
        else if(timer > 5 && cookingStage == 0){
            cookingStage = 1;
            ChangeColor(cook);
            cookAmount.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(cookAmount.GetComponent<UnityEngine.UI.Text>().text) + 1).ToString();
        }
    }


    void ChangeColor(Material[] materials)
    {
        GetComponent<MeshRenderer>().materials = materials;
    }

    
}
