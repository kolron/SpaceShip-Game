using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPowerup : MonoBehaviour
{
    //This is the code of the cannon powerup collision.
   
    [Tooltip("The number of seconds that the Cannon remains active")] [SerializeField] float duration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            if (gameObject.name == "CannonPowerup(Clone)")
            {
                //when colliding with the player.

                //get the LaserShooter component, and activate the gotCannon method in it, for the above duration. 
                var shooter = other.GetComponent<LaserShooter>();
                shooter.gotCannon(duration);
                
                //Display instructions
                var text = GameObject.Find("TextLaser").GetComponent<DisplayInstructions>();
                text.display();
                Destroy(gameObject);  // Destroy the powerup itself - prevent double-use

            }
            else if (gameObject.name == "MinePowerup(Clone)")
            {
                
                var mineSpawner = other.GetComponent<MineSpawner>();
                mineSpawner.gotMine();
                var text = GameObject.Find("TextMines").GetComponent<DisplayInstructions>();
                text.display();
                Destroy(gameObject);
            }
            else if(gameObject.name == "ShieldPowerup(Clone)")
            {
                var shielder = other.GetComponent<ShieldSpawner>();
                shielder.gotShield(duration);
                Destroy(gameObject);
            }
        }
    }
  
// Update is called once per frame
void Update()
    {
        
    }
}
