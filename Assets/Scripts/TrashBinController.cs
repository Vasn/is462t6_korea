using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinController : MonoBehaviour
{
    public GameObject bin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Types of waste: 
        //General Waste
        //Glass(i.e.Beer bottles)
        //Cans(i.e.aluminium or Iron)
        //Paper(i.e.printing paper, magazines, newspaper, boxes, cartons, etc.) //Paper Pack(i.e.juice packs, milk packs, etc)
        //Plastic(NOT including Toys, stationery pens, small candy wraps)
        //PET Bottles
        //Vinyl(i.e.snack bags, dessert wraps, etc)
        //Food Waste (!!egg shells, crustacean shells(Crab, Lobster, Shrimp, etc), clam shells, onion and garlic paper - like skin, animal bones(beef, pork, chicken, lamb, etc), tea bags or tea leaves.All of these are considered GENERAL WASTE.)

        if (other.gameObject.CompareTag(bin.tag)) // For Food Waste
        {
            // THE FOLLOWING ARE CONSIDERED GENERAL WASTE
            // egg shells, crustacean shells(Crab, Lobster, Shrimp, etc), clam shells, onion and garlic paper - like skin, animal bones(beef, pork, chicken, lamb, etc), tea bags or tea leaves

            Debug.Log("CORRECT!! You have placed '" + other.tag + "' in a '" + bin.tag + "' bin.");
            ScoreBoardController.startPoints += 1;
        }
        else if (other.gameObject.CompareTag("Food") || other.gameObject.CompareTag("General") || other.gameObject.CompareTag("Can") || other.gameObject.CompareTag("Glass") || other.gameObject.CompareTag("Paper"))
        {
            Debug.Log("WRONG!! You have placed '" + other.tag + "' in a '" + bin.tag + "' bin.");
            ScoreBoardController.startPoints -= 1;
        }

    }
}
