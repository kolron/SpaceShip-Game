using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a simple coillider script for the walls outside the map, it destorys every object that collides with them.
//this is useful because in the previous iteration, the objects simply went on beyond the edge of the map and were never destroyed, causing performance issues
public class WallCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            Destroy(other.gameObject);
        }

    }
}
