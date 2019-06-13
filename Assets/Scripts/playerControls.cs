using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    public GameObject fireBall;
    public float cooldownTime;
    public float movementSpeed;

    private Rigidbody2D rigidBody;
    private Vector2 movementVector;
    private Vector2 directionVector;
    private float nextCooldown;
    
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

            

        if (Input.GetAxis("Fire1") != 0 & (nextCooldown < Time.time))
        {
            // Creates an angle from the axes.
            directionVector.x = Input.GetAxis("HorizontalTurn");
            directionVector.y = Input.GetAxis("VerticalTurn");
            directionVector.Normalize();
            Debug.Log(directionVector);
            float directionAngle = (Mathf.Atan2(directionVector.x, directionVector.y) * 180 / Mathf.PI);

            Debug.Log(directionAngle);

            transform.eulerAngles = new Vector3 (0f, 0f, 90 - directionAngle);

            GameObject ball = Instantiate(fireBall, transform.position, Quaternion.identity) as GameObject;
            ball.GetComponent<Rigidbody2D>().velocity = transform.right * 10;

            nextCooldown = Time.time + cooldownTime;
        }

    }
}
