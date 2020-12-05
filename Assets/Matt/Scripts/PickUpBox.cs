using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{
    private float healthCompare = 0;
    private float healthGainer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        //Accessing the player script for reasons
        GameObject thePlayer = GameObject.Find("Player");
        Player playerScript = thePlayer.GetComponent<Player>();
        //Gives the item according to what item this script is attached to.
        if(gameObject.name == "Blaster")
        {
            //Enables Player to shoot
            playerScript.Blaster = true;
            Debug.Log("Hello!");

            Destroy(gameObject);
        }
        else if (gameObject.name == "Grenade")
        {
            //Gives Player Grenade
            playerScript.Grenade += 1;

            Destroy(gameObject);
        }
        else if (gameObject.name == "HealthPack")
        {
            //Increases health, For loop to make sure it doesn't overheal
            healthCompare = playerScript.health;
            for(int i = 0; i < 10; i++)
            {
                if(healthCompare < 100)
                {
                    playerScript.health += 1;
                }
            }
            Destroy(gameObject);
        }
        
    }
}
