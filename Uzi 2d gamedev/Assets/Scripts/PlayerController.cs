using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 15.0f;

    private float hInput;
    private float vInput;

    public float xRange = 10.5f;
    public float yRange = 4.5f;

    public GameObject projectile;
    public transform firePoint;
    
    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
        transform.Rotate(Vector3.back, turnSpeed * hInput * Time.deltaTime);

        //Creates wall on the left side
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange.transform.position.y,transform.position.z);
        }
        //Right wall
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange.transform.position.y,transform.position.z);
        }
        //Top wall
        if(transform.position.x > yRange)
        {
            transform.position = new Vector3(xRange.transform.position.x, yRange, transform.position.z);
        }
        //Bottom wall
        if(transform.position.x < -yRange)
        {
            transform.position = new Vector3(xRange.transform.position.x, -yRange, transform.position.z);
        }
        //Hit spacebar is shoot projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        
        }


    }
}
