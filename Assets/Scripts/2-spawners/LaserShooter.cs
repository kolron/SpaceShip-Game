using UnityEngine;
using System.Collections;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 * This class orignally inherited the KeyboardSpawner class, but it caused some issues so I optd to remove it.
 */
public class LaserShooter : MonoBehaviour
{
    [SerializeField] protected KeyCode keyToPress;
   
    [SerializeField] protected GameObject[] prefabToSpawn; //Array that holds which prefabs we want to spawn, we will spawn by index. the best way to do this is to make this a struct simulating a hashmap.
    [SerializeField] protected Vector3 velocityOfSpawnedObject;
    [SerializeField] NumberField scoreField;
    //Added a bool to indicate if we want to use the laser cannon powerup or not.
    [SerializeField] bool cannonActive = false;

    [Tooltip("Fire between shots in seconds")] [SerializeField] protected float fireRate = 0.5f;
    private float nextFireTime;
    //indicate the id for each prefab, of course, a more correct approach is not to use this type of accessing.(Hashmap is better)
    private int baseLaserId = 0;
    private int cannonPowerupId = 1;
    
    //Used to show.hide the cannon sprite
    private SpriteRenderer cannonRenderer;

    //this method is activated by the CannonPowerup
    public void gotCannon(float duration)
    {   
        cannonRenderer.enabled = true; //show(render) cannon
        cannonActive = true; //enables the cannon usage.
        StartCoroutine(CannonRoutine(duration)); //sets a timer for the duration(Duration is passed and determined by the powerup prefab)
    }
    private IEnumerator CannonRoutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        cannonRenderer.enabled = false;
        cannonActive = false; //once timer ends, disable cannon.
    }

    //Changed from original, as in its parent class, we now accept an int index as an argument.
    // when we call the method in the base class, we also pass the index of which weapon we want to fire.
    protected GameObject spawnShot()
    {
        GameObject newObject;
        Vector3 positionOfSpawnedObject = transform.position;  // span at the containing object position.
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
      
        if (!cannonActive)
        {
             newObject = Instantiate(prefabToSpawn[baseLaserId], positionOfSpawnedObject, rotationOfSpawnedObject); // if the cannon is not active, we use regular shot.
        }
        else
        {
            newObject = Instantiate(prefabToSpawn[cannonPowerupId], positionOfSpawnedObject, rotationOfSpawnedObject); ; //else, we use this shot..
        }
        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover)
        {
            newObjectMover.SetVelocity(velocityOfSpawnedObject);
        }
        // Modify the text field of the new object.
        ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
        if (newObjectScoreAdder)
            newObjectScoreAdder.SetScoreField(scoreField);

        return newObject;
        
    }
   void Start()
    {
        cannonRenderer = transform.Find("CannonSprite").GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKey(keyToPress))
        {
            if (Time.time > nextFireTime)
            {
                Debug.Log("Got Key");
                spawnShot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }
}
