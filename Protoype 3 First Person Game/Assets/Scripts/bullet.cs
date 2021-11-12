using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
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

    void OnTriggerEnter(Collider other)
    {
        //Did we hit the target aka player
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
        else
            if(other.CompareTag("Enemy"))
                other.GetComponent<Enemy>().TakeDamage(damage);
        //Disable Bullet
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
        
    }
}
