using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 2;
    float speed = 10;
    public GameObject bullet;
    public Transform shootingOffset;
    private Rigidbody rb;
    private Animator anim;

    //Boundaries
    public float zMaxBoundary, zMinBoundary;

    //PickUpVariables
    public int health = 100;
    public int Grenade = 0;
    public bool Blaster = false;

    public HealthBar healthbar;

    public bool MoveBack = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        //Health intialize
        healthbar.SetMaxHealth(100);
    }

    void Update()
    {
        // Moves player left and right by axis, transform, and rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Moves player left and faces left
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(new Vector3(-horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
            Walk();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Moves player right and faces right
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
            Walk();
        }

        // Moves player back and front by axis and transform
        if(MoveBack == true)
        {
            float zAxis = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(0, 0, zAxis) * moveSpeed * Time.deltaTime);
        }
        

        // When 'Space' is pressed, player shoots
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiates new copy of the bullet prefab
            GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);

            // Shot is destroyed after 3 sec
            Destroy(shot, 3f);
        }

        // When pressing 'S', player punches
        if (Input.GetKeyDown(KeyCode.S))
        {
            Punch();
        }

        // When pressing 'D', player kicks
        if (Input.GetKeyDown(KeyCode.D))
        {
            Kick();
        }


        //Moves the player within the boundaries
        
        if (transform.position.z < zMinBoundary)
        {
            MoveBack = false;//moveSpeed = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y, zMinBoundary + 0.1f);
        }
        else if (transform.position.z > zMaxBoundary)
        {
            MoveBack = false;//moveSpeed = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y, zMaxBoundary - 0.1f);
        }
        else
        {
            MoveBack = true;
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Get Rekt Kid");
            Enemy currentEnemy = other.gameObject.GetComponent<Enemy>(); //Long ago in a land far away, there once was a knight who went to slay a dragon. Along their journey they met a scarecrow who, contrary to popular tales, wasn't missing his brain
            currentEnemy.health -= 30;
            Debug.Log("Enemy Health from Player Perspective" + currentEnemy.health);
            //currentEnemy.TakeDamage(30);
            //Destroy(other);
        }
    }


    void Punch()
    {
        // Animation for attack
        anim.SetTrigger("Punch");
    }

    void Kick()
    {
        // Animation for kicking
        anim.SetTrigger("Kick");
    }

    void Walk()
    {
        // Animation for walking
        anim.SetTrigger("Walk");
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        healthbar.SetHealth(health);
    }

}
