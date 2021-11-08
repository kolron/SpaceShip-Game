using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] NumberField scoreField;
    [SerializeField] KeyCode KeyToPress;
    [SerializeField] GameObject[] prefabToSpawn;
    [SerializeField] int maxMineNumber=2; //Default mineNumber
    [SerializeField] private int currentMineNumber;
    private int MineId = 0;
    
    //used to show/hide mines on the spaceship.
    private SpriteRenderer mineRenderer;

    //When we got the mine powerup, replenish mine stock.
    public void gotMine()
    {
        currentMineNumber += maxMineNumber - currentMineNumber;
        mineRenderer.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        mineRenderer = transform.Find("MineSprite").GetComponent<SpriteRenderer>();
        currentMineNumber = 0;
    }
    GameObject spawnMine(int index)
    {
        Vector3 positionOfSpawnedObject = transform.position;
        Quaternion rotationOfSpawnedObject = Quaternion.identity;
        GameObject newObject = Instantiate(prefabToSpawn[index], positionOfSpawnedObject, rotationOfSpawnedObject);
        currentMineNumber -= 1;

        ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
        if (newObjectScoreAdder)
            newObjectScoreAdder.SetScoreField(scoreField);

        return newObject;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            if(currentMineNumber > 0)
            {
                spawnMine(MineId);
                if(currentMineNumber == 0)
                {
                    mineRenderer.enabled = false;
                }
            }
        }
    }

}
