using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    public float speed = 25.0f;
    
    void Update()
    {

        
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    
    }
}
