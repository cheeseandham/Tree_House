using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charater_Control : MonoBehaviour {

    Rigidbody rb;
    Place_Ladder placeLadderMe;

    public float movementSpeed;
    public float xSpeed;
    public float ySpeed;

    Camera mainCam;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        placeLadderMe = GetComponent<Place_Ladder>();

        mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 playerPos;

        playerPos = transform.localPosition;

        playerPos += transform.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        playerPos += transform.forward * Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        rb.MovePosition(playerPos);

        float rotationX = Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        transform.Rotate(0.0f, rotationX, 0.0f);
        
        float rotationY = Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
        mainCam.transform.Rotate(-rotationY, 0.0f, 0.0f);

        if (Input.GetMouseButtonDown(0))
        {
            placeLadderMe.instaNewPlank();
        }
        
    }
}
