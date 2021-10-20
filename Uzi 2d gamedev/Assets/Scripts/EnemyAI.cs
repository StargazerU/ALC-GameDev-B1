using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    void OntTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject,CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }

}
