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
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use

            }
            else if (gameObject.name == "MinePowerup(Clone)")
            {
                Debug.Log("Collided with minePowerUp");
                var mineSpawner = other.GetComponent<MineSpawner>();
                mineSpawner.gotMine();
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
