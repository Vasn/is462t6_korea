using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutAreaManager : MonoBehaviour
{
    public GameObject basket;
    public GameObject checklist;
    private bool basketDown = false;
    private GameObject newBasket;
    
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
}
