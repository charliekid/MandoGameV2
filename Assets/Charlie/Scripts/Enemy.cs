﻿using System;
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
    float duration = 0.5f;

    private bool isFacingRight = true;

    private Vector3 facingDirection = Vector3.left;

    //health
    public int health = 100;
    public HealthBar healthbar;


    private int counter = 0;
    
    // Start is called before the first frame update
    
    void Start()
    {
        //InvokeRepeating("MoveEnemy", .1f, .3f);

        //Health intialize
        healthbar.SetMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        //Die
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

        //HealthBar
        healthbar.SetHealth(health);

        enemy.position += (facingDirection * speed * Time.deltaTime) / 2;
        enemy.GetComponent<Animator>().SetTrigger("Walk");
        // velocityEnemy = Input.GetAxis("EnemyInput");
        //
        // // Deals with movement within a boundary
        // // TODO: need to figure out boundarys when the player moves
        //Debug.Log(("current position " + enemy.position.x ));
        //MoveEnemy();

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

    IEnumerator OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.GetComponent<Animator>().SetTrigger("Idle");
            //KnockedBack();
            speed = -1.5f;
            yield return new WaitForSeconds(duration);
            speed = 1;

        }
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthbar.SetHealth(health);
    }

    private void KnockedBack()
    {
        if(counter < 9)
        {
            speed = -0.5f;
            counter += 1;
        }
        else
        {
            speed = 1;
            return;
        }
    }
}
