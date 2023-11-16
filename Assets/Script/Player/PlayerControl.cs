using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    //Public parameters
    public float speed = 10f;

    //Private parameters
    Movement movement;
    Player_Action action;

    
    float CheckPlayer_HorizontalAxis() //Check if the Player want to move horizontally
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        return horizontalAxis;
    }

    float CheckPlayer_VerticalAxis() //Check if the Player want to move vertically
    {
        float verticalAxis = Input.GetAxis("Vertical");
        return verticalAxis;
    }

    bool CheckPlayer_TriesToPickOrLayCat() //Check if the Player want to pick a Cat
    {
        return Input.GetButtonDown("PickUpACatKey");
    }

    //TO DO : ADD A LIMITER

    private void Start()
    {
        movement = GetComponent<Movement>(); //Import the Movement Script placed in the gameobject Player
        action = GetComponent<Player_Action>(); //Import the Player_Action Script placed in the gameobject Player

    }

    private void Update()
    {
        movement.Move(CheckPlayer_VerticalAxis(), CheckPlayer_HorizontalAxis(), speed); //Move the player

        if (CheckPlayer_TriesToPickOrLayCat()) //The Player try to pick a cat
        {
            action.PickUpOrLayCat(); //Pick or lay a cat
        }
    }
}
