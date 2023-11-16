using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Action : MonoBehaviour
{
    //Public Parameters
    public float offsetCatAbovePlayer= 1f;
    public float offsetCatInFrontPlayer = 1f;

    //Private Parameters
    bool pickUpAllowed;
    bool catOnPlayerHead = false;
    Vector3 playerPosition;
    Collider2D catCollider;
    GameObject cat;

    public void PickUpOrLayCat() //Player try to Pick or Lay a Cat
    {
        if (pickUpAllowed && !catOnPlayerHead && cat != null) //Pick up a cat 
        {
            /*Debug.Log("I try my best to pick him I Sware !"); //DEBUG */

            catOnPlayerHead = true; //Prohibit Player to pick another cat (thats rude !!!)
            pickUpAllowed = false; //Reset pickUpAllowed

            Vector3 abovePlayer = playerPosition + new Vector3(0, offsetCatAbovePlayer, 0); //Create a new position to put a cat on the head of the Player
            cat.transform.position = abovePlayer; //Update the cat position to be on the player
            cat.transform.SetParent(this.transform); //Put the cat child to the Player
            
        }

        else if (catOnPlayerHead) //Lay the cat
        {
            catOnPlayerHead = false; //Reset catOnPlayerHead

            Vector3 inFrontPlayer = playerPosition + new Vector3(offsetCatInFrontPlayer, 0, 0); //Create a new position to put the cat in front of the Player
            cat.transform.position = inFrontPlayer; //Update the cat position to be in front of the player
            cat.transform.parent = null; //Cat is not anymore a child of Player
        }

        else //Player can't pick a cat there is no cat
            Debug.Log("There is no cats near by !"); //DEBUG
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Debug.Log("Enter Trigger Zone !"); //DEBUG*/

        if (collision.CompareTag("Cat")) //Player are close to a cat
        {
        /*Debug.Log("Ho hello mister or miss cat :)"); //DEBUG*/

        pickUpAllowed = true; 
        catCollider = collision;
        cat = catCollider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Cat"))
        {
            cat = null; //Reset the gameobject cat
            pickUpAllowed = false; //You are not near a cat

            /*Debug.Log("Exit Trigger Zone !"); //DEBUG*/
        }
    }

    private void Update()
    {
        //pickUpAllowed = false; //Reset the condition if there is not cats
        if (this.transform != null) //Its a safety check
        {
            playerPosition = this.transform.position;
        }
    }
}
