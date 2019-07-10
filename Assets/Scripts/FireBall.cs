using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float duration;
    public float speed;
    public float strength;
    private Vector3 direction;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duration);
        Debug.Log(player);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += direction * speed;
    }

    public void SetOwner(GameObject player) 
    {
        this.player = player;
        Debug.Log(player);
    }

    public void SetDirection(Vector3 direction) 
    {
        this.direction = direction;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject != player)
        {
            Vector3 difference = col.transform.position - transform.position;
            difference.Normalize();
            Debug.Log("difference: (for Alex)   " + difference);
            col.gameObject.GetComponent<PlayerControls>().AddForce(difference, strength);

            // End this projectile's life
            Destroy(this.gameObject);
        }

    }
}
