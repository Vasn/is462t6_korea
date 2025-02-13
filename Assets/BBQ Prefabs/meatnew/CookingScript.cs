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

    // burnt meat popup
    public GameObject MeatReadyMsgPrefab; // to create these prefabs and follow bacon
    public GameObject MeatBurntMsgPrefab; // to create these prefabs and follow bacon
    public GameObject bacon;
    public AudioSource audioSource;
    public AudioClip meatSizzleSound;
    public AudioClip meatReadySound;
    GameObject meatReadyMsg;
    GameObject meatBurntMsg;
    // for arrow guide check
    private bool firstGrab = false;

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

            // sizzle sound only if uncooked
            if(cookingStage == 0){
                audioSource.clip = meatSizzleSound;
                audioSource.Play();
            }

            // update arrow guide
            if(!firstGrab){
                arrowGuideManager.tutorialStage=3;
                firstGrab = true;
            }
        }

    }



    void OnCollisionExit(Collision collision){
        print("no longer cookin");
        isColliding = false;
        audioSource.Stop();
        // if meatreadymsgprefab is instantiated as a clone, destroy it
        if(meatReadyMsg != null){
            meatReadyMsg.SetActive(false);
        }
        if(meatBurntMsg != null){
            meatBurntMsg.SetActive(false);
        }
        
    }

    void UpdateCookingStage(){
        if( timer > 10 && cookingStage == 1){
            cookingStage = 2;
            ChangeColor(burn);
            burnAmount.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(burnAmount.GetComponent<UnityEngine.UI.Text>().text) + 1).ToString();
            cookAmount.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(cookAmount.GetComponent<UnityEngine.UI.Text>().text) - 1).ToString();
            // MeatReadyMsg.SetActive(false);
            // disable meatReadyMsg
           
            meatReadyMsg.SetActive(false);
                // MeatBurntMsg.SetActive(true);
            meatBurntMsg = Instantiate(MeatBurntMsgPrefab, transform.position, Quaternion.identity);
            meatBurntMsg.SetActive(true);
            // rotate the prefab 180 degrees
            meatBurntMsg.transform.position = new Vector3(meatBurntMsg.transform.position.x, meatBurntMsg.transform.position.y + 0.1f, meatBurntMsg.transform.position.z);
            // rotate the prefab 180 degrees
            meatBurntMsg.transform.Rotate(0, 180, 0);

            // MeatBurntMsg.SetActive(false);
            
            
        }
        else if(timer > 5 && cookingStage == 0){
            cookingStage = 1;
            ChangeColor(cook);
            cookAmount.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(cookAmount.GetComponent<UnityEngine.UI.Text>().text) + 1).ToString();

            // alert for meat is ready
            // MeatReadyMsg.SetActive(true);
            // show message above current object position facing the camera
            meatReadyMsg = Instantiate(MeatReadyMsgPrefab, transform.position, Quaternion.identity);
            meatReadyMsg.SetActive(true);
            // move prefab up y 0.75 unit
            meatReadyMsg.transform.position = new Vector3(meatReadyMsg.transform.position.x, meatReadyMsg.transform.position.y + 0.1f, meatReadyMsg.transform.position.z);
            // rotate the prefab 180 degrees
            meatReadyMsg.transform.Rotate(0, 180, 0);

            //meatReadyMsg = Instantiate(MeatReadyMsgPrefab, transform.position, Quaternion.identity);
            // rotate the prefab 180 degrees
            audioSource.clip = meatReadySound;
            audioSource.Play();
            
        }
    }


    void ChangeColor(Material[] materials)
    {
        GetComponent<MeshRenderer>().materials = materials;
    }

    
}
