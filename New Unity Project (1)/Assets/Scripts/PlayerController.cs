using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnspeed;
    //Left and Right input
    public float hInput;
    //forward and back input
    public float vInput;
    //projectile

    // Update is called once per frame
    void Update()
    {
        //Getting button press values for horizontal and vertical value
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        //Makes vechicale go left and right
        transform.Rotate(Vector3.up, turnspeed * hInput * Time.deltaTime);
        //Makes the vechicle go forward and back
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
    }
}
