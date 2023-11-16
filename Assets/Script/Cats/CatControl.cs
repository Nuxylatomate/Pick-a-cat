using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatControl : MonoBehaviour
{
    Movement movement;
    public float minAxis;
    public float maxAxis;
    public float speed;


    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        float horizontalAxis = Random.Range(minAxis, maxAxis);
        float verticalAxis = Random.Range(minAxis, maxAxis);

        movement.Move(verticalAxis, horizontalAxis, speed);
    }
}
