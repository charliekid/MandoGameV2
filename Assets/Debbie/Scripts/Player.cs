using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 2;
    public GameObject bullet;
    public Transform shootingOffset;
    private Rigidbody rb;
    private Animator anim;

    public bool Blaster = false;
    public int Grenade = 0;
    public int health = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Moves player right and faces right
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
        }

        // When 'Space' is pressed, player shoots
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiates new copy of the bullet prefab
            GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);

            // Shot is destroyed after 3 sec
            Destroy(shot, 3f);
        }

        // Moves player up and down by axis and transform
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, verticalInput) * moveSpeed * Time.deltaTime);

        // When pressing 'S', player attacks (punches)
        if (Input.GetKeyDown(KeyCode.S))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Animation for attack
        anim.SetTrigger("Attack");
    }

}
