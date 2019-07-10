using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public GameObject fireBall;
    public float cooldownTime;
    public float movementSpeed;
    public float knockBackDuration;

    public float knockbackPercent;
    public GameObject percentText;

    private Vector2 movementVector;
    private Vector2 aimVector;
    private Vector2 forceDirection;
    private float forceStrength;
    private float forceTime; 
    private float nextCooldown;
    public string playerNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        Text text = percentText.GetComponent<Text>();
        text.text = this.knockbackPercent + "%";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementVector.x = Input.GetAxis(playerNumber+"Horizontal") * movementSpeed;
        movementVector.y = Input.GetAxis(playerNumber+"Vertical") * movementSpeed;
        Vector3 velocity = movementVector * movementSpeed;

        Vector3 forceVelocity = Vector3.zero;
        if(Time.time - forceTime < knockBackDuration) {
            forceVelocity = Vector3.Lerp(forceDirection*forceStrength, Vector3.zero, (Time.time-forceTime)/knockBackDuration);
        }

        transform.position += velocity + forceVelocity;

        if (Input.GetAxis(playerNumber+"Fire") != 0 & (nextCooldown < Time.time))
        {
            // Creates an angle from the axes.
            aimVector.x = Input.GetAxis(playerNumber+"HorizontalTurn");
            aimVector.y = Input.GetAxis(playerNumber+"VerticalTurn");
            aimVector.Normalize();
            Debug.Log(aimVector);
            float directionAngle = (Mathf.Atan2(aimVector.x, aimVector.y) * 180 / Mathf.PI);

            Debug.Log(directionAngle);

            transform.eulerAngles = new Vector3 (0f, 0f, 90 - directionAngle);

            GameObject ball = Instantiate(fireBall, transform.position, Quaternion.identity) as GameObject;
            ball.GetComponent<FireBall>().SetDirection(transform.right);
            ball.GetComponent<FireBall>().SetOwner(this.gameObject);

            nextCooldown = Time.time + cooldownTime;
        }

    }

    public void AddForce(Vector3 forceDirection, float forceStrength) {
        forceTime = Time.time;
        this.forceDirection = forceDirection;

        float percentKnockback = 2.0f;

        this.forceStrength = forceStrength * (1 + this.knockbackPercent*percentKnockback/100.0f);

        // Add % 
        this.knockbackPercent += 150;

        Text text = percentText.GetComponent<Text>();
        text.text = this.knockbackPercent + "%";
    }
}
