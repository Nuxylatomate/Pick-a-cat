using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void MoveUpOrDown(float verticalAxis,float speed)
    {
        this.gameObject.transform.position += new Vector3(0, verticalAxis * speed * Time.deltaTime, 0);
    }

    public void MoveLeftOrRight(float horizontalAxis, float speed)
    {
        this.gameObject.transform.position += new Vector3(horizontalAxis * speed * Time.deltaTime, 0, 0);
    }

    public void Move(float verticalAxis, float horizontalAxis, float speed)
    {
        //Input Up or Down from Player
        if (verticalAxis != 0)
        {
            MoveUpOrDown(verticalAxis, speed);
        }

        //Input Left or Right from Player
        if (horizontalAxis != 0)
        {
            MoveLeftOrRight(horizontalAxis, speed);
        }
    }

}
