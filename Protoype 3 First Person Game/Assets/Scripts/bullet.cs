using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        shootTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
        
    }
}
