using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectPool bulletPool;
    public Transform firepoint;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float bulletSpeed;

    public float shootRate;
    public float lastShootTime;
    private bool isPlayer;



    void Awake()
    {
        //Are we attached to the player
        if(GetComponent<PlayerController>())
        {    
            isPlayer = true;
        }
    }
    //Can we shoot a bullet
    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
            {
                return true;
            }
        }

        return false;
    }
    public void Shoot()
    {
        //Adjust shoot time and reduce ammo by one
        lastShootTime = Time.time;
        curAmmo --;
        //Create projectile
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = firepoint.position;
        bullet.transform.rotation = firepoint.rotation;

        //Velocity of bullet
        bullet.GetComponent<Rigidbody>().velocity = firepoint.forward * bulletSpeed;
    }

    // Update is called once per frame
    
}
