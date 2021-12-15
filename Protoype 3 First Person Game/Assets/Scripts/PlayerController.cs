using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public int curHP;
    public int maxHP;
    [Header("Movement")]//Movement
    public float MoveSpeed; //how fast they move
    public float jumpForce; //how high they jump
    [Header("Camera")]//Camera
    public float lookSensitivity; //Mouse speed/sensitivity
    public float maxLookx; //lowest we can look down
    public float minLookx; //highest we can look up
    private float rotx; //current x rotation of the camera
    [Header("Componets")] //Componets
    private Camera cam;
    private Rigidbody rb;
    private Weapon weapon;

    

    void Awake()
    {
        //Get components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        weapon = GetComponent<Weapon>();
        //Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        //Initialize the UI
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    void Update()
    {
        //Don't do anything when the game is paused
        if(GameManager.instance.gamePaused == true)
            return;

        Move();
        CamLook();
        //Jump Button
        if(Input.GetButtonDown("Jump"))
            Jump();
        //fire button
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
    }
    void Move()
    {
        //Getting keyboared input
        float x = Input.GetAxis("Horizontal") * MoveSpeed;
        float z = Input.GetAxis("Vertical") * MoveSpeed;
        //Applying movment to the rigidbody
        Vector3 dir = transform.right * x + transform.forward * z;
        //jump direction
        dir.y = rb.velocity.y;
        // apply direction to camera movement
        rb.velocity = dir;
    }

    void Jump()
    {
        //cast ray to ground
        Ray ray = new Ray(transform.position, Vector3.down);

        //check for information
        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    void CamLook()
    {
        //Get mouse unput so we can look around with the mouse
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotx += Input.GetAxis("Mouse Y") * lookSensitivity;

        //Clamp the vertical rotation of the camera
        rotx = Mathf.Clamp(rotx, minLookx, maxLookx);

        //Applying the rotation to Camera
        cam.transform.localRotation = Quaternion.Euler(-rotx, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        
        if(curHP <= 0)
            Die();
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }
    void Die()
    {
        GameManager.instance.LoseGame();
        print("You have perished!!! Game Over");
    }

    public void GiveHealth(int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }
    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }
}
