using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player1;

    public GameObject player2;

    private Camera cam;

    private Vector3 zOffset;

    // Start is called before the first frame update
    void Start()
    {
        zOffset = transform.position;
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = zOffset + (player1.transform.position + player2.transform.position)/2;
        float distance = Vector2.Distance(player1.transform.position, player2.transform.position);
        cam.orthographicSize = distance/2;
    }
}
