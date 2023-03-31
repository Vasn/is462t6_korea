using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutAreaManager : MonoBehaviour
{
    public GameObject basket;
    public GameObject checklist;
    private bool basketDown = false;
    private GameObject newBasket;
    public GameObject plasticBag;
    
    public void placeBasket()
    {
        if (basketDown == true || newBasket != null)
        {
            return;
        }
        Debug.Log("placeBasket");
        // Get the position of the this game object
        Vector3 position = this.transform.position;
        // Instantiate the basket
        newBasket = Instantiate(basket, position, Quaternion.identity);
        // Set the basket as a child of this game object
        newBasket.transform.parent = this.transform;

        //Hide the basket
        basket.SetActive(false);
        checklist.SetActive(false);

        // Get center of basket
        Vector3 basketCenter = newBasket.GetComponent<Renderer>().bounds.center;
        // Put all children of original basket into new basket
        foreach (Transform child in basket.transform)
        {
            if (child.gameObject.tag == "Basket")
            {
                continue;
            }
            child.parent = newBasket.transform;
            // Move child to center of basket
            child.position = basketCenter;
        }
    }

    public void clearItemsInBasket()
    {
        // Clear the basket if it is not empty
        if (newBasket != null)
        {
            foreach (Transform child in newBasket.transform)
            {
                if (child.gameObject.tag == "Basket")
                {
                    continue;
                }
                Destroy(child.gameObject);
            }
        }
    }

    public void removeBasket()
    {
        this.transform.DetachChildren();
        Destroy(newBasket);
        newBasket = null;
    }

    public void pickUpBasket()
    {
        // Show the basket
        basket.SetActive(true);
        checklist.SetActive(true);
        basketDown = false;
        // Clear the basket if it is not empty
        if (newBasket != null)
        {
            clearItemsInBasket();
            removeBasket();
        }        
    }

    public void spawnItems()
    {
        // Get all items in the basket and spawn them in checkout area
        foreach (Transform child in newBasket.transform)
        {
            if (child.gameObject.tag == "Basket")
            {
                continue;
            }
            // Get the position of the basket
            Vector3 basketPosition = newBasket.transform.position;
            // Get the position of the item
            Vector3 itemPosition = child.transform.position;
            // Get the difference between the two positions
            Vector3 difference = itemPosition - basketPosition;
            // Get the position of the item in the world
            Vector3 worldPosition = basketPosition + difference;
            // Spawn the item in the world
            Instantiate(child.gameObject, worldPosition, Quaternion.identity);
        }
        //Destroy the basket
        removeBasket();
    }

    public void spawnPlasticBag()
    {
        // unhide the plastic bag
        plasticBag.SetActive(true);

        // Put Items from basket into plastic bag
        foreach (Transform child in newBasket.transform)
        {
            if (child.gameObject.tag == "Basket")
            {
                continue;
            }
            // Get the position of the plastic bag
            Vector3 plasticPosition = plasticBag.transform.position;
            // Get the position of the item
            Vector3 itemPosition = child.transform.position;
            // Get the difference between the two positions
            Vector3 difference = itemPosition - plasticPosition;
            // Get the position of the item in the world
            Vector3 worldPosition = plasticPosition + difference;
            // Spawn the item in the world
            Instantiate(child.gameObject, worldPosition, Quaternion.identity);
        }

        // Destroy the basket
        removeBasket();
    }
}
