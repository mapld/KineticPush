using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float movementSpeed;

    private Rigidbody2D rigidBody;

    private Vector2 movementVector;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxis("Horizontal") * movementSpeed;

        movementVector.y = Input.GetAxis("Vertical") * movementSpeed;

        rigidBody.velocity = movementVector;
    }
}
