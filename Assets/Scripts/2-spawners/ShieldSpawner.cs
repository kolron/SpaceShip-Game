using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    //refrences to the shield Child Object of the spaceship.
    Transform shieldTransform;
    GameObject shieldObject;
    SpriteRenderer renderer;

    //floats to time the fadeout correctly.
    float timeout = 0.05f; // time between each fadeout, needs to be small enough to be smooth.
    float fadeAmount; //How much will be faded each loop, can't be set now as it depends on duration
    float minimumFadeOut = 0f; // end and starting fade levels, where the range is between 1(max) and 0(min)
    float startingFadeAmount = 1f;

    //Shield Powerup calls this method
    public void gotShield(float duration)
    {
        //activates the Shield child object, which has a Collider
        shieldObject.SetActive(true);
        //start the routine to fadeout the shield in the duration window.
        StartCoroutine(ShieldActiveAndFade(renderer, duration));

    }
    // Start is called before the first frame update
    void Start()
    {
        //Initialize references.
        shieldTransform = transform.Find("Shield");
        shieldObject = shieldTransform.gameObject;
        renderer = shieldTransform.GetComponent<SpriteRenderer>();
        shieldObject.SetActive(false); //Make sure shield isn't active at game start.
    }

    //Method that fades out the shield, and deactivates it once faded.
    IEnumerator ShieldActiveAndFade(SpriteRenderer renderer, float duration)
    {
        //Setting the fadeAmount to line up with all our variables, this will make it so the object is faded out in exactly <duartion> seconds.
        fadeAmount = startingFadeAmount / (duration / timeout);
        for (float f = startingFadeAmount; f >= minimumFadeOut; f -= fadeAmount) //notice we use -= to reduce fade.
        {
            Color temp = renderer.material.color; 
            temp.a = f; //Set the A in RGBA to be the current fade amount.
            renderer.material.color = temp; //apply the change.
            yield return new WaitForSeconds(timeout);
        }
        shieldObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
