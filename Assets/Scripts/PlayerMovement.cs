using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 720;

    private void Start()
    {

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(verticalInput, 0, -horizontalInput);
        Vector3 rotationDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        rotationDirection.Normalize();

        transform.Translate(speed * Time.deltaTime * movementDirection, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(rotationDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
