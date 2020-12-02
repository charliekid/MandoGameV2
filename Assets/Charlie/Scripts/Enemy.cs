using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform enemy; 
    
    public float maxBoundaryX, minBoundaryX;
    
    private float velocityEnemy = 0;
    private float amplitude = 1;
    private float speed = 1; 

    private bool isFacingRight = true;

    private Vector3 facingDirection = Vector3.left;
    
    
    // Start is called before the first frame update
    
    void Start()
    {
        //InvokeRepeating("MoveEnemy", .1f, .3f);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.position += (facingDirection * speed * Time.deltaTime) / 2;
        enemy.GetComponent<Animator>().SetTrigger("Walk");
        // velocityEnemy = Input.GetAxis("EnemyInput");
        //
        // // Deals with movement within a boundary
        // // TODO: need to figure out boundarys when the player moves
        //Debug.Log(("current position " + enemy.position.x ));
        if (enemy.position.x < minBoundaryX)
        {
            // flips the enemy and goes in the other direction
            //enemy.position += (Vector3.right * speed * Time.deltaTime) / 4;
            facingDirection = Vector3.right;
            enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        } 
        else if (enemy.position.x > maxBoundaryX)
        {
            //enemy.position += (Vector3.left * speed * Time.deltaTime) / 4;
            facingDirection = Vector3.left;
            enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        // else
        // {
        //enemy.position += (Vector3.right * velocityEnemy * amplitude) / 10;
        // }

        // Get the character to face a certain way
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     enemy.GetComponent<Animator>().SetTrigger("Walk");
        //     Debug.Log("A key pushed " + isFacingRight);
        //     if (isFacingRight)
        //     {
        //         isFacingRight = false; 
        //         enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        //     }
        // } 
        // if (Input.GetKey(KeyCode.D))
        // {
        //     enemy.GetComponent<Animator>().SetTrigger("Walk");
        //     Debug.Log("D key is pushed " + isFacingRight);
        //     if (!isFacingRight)
        //     {
        //         isFacingRight = true;
        //         enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        //     }
        // }
    }

    void MoveEnemy()
    {
        enemy.position += Vector3.right * speed;
        if (enemy.position.x < minBoundaryX || enemy.position.x > maxBoundaryX)
        {
            speed = -speed; // changes direction
            enemy.position += Vector3.down * 0.5f; // moves enemies down
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("We hit the player!");
            // We need it to throw a punch. 
            //enemy.GetComponent<Animator>().SetTrigger("Punch");
        }
    }
}
