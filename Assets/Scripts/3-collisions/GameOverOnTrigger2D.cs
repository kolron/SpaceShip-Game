using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string[] triggeringTags;

    private void OnTriggerEnter2D(Collider2D other) {
        bool gameOver = false;
        for (int i = 0; i < triggeringTags.Length && (!gameOver); i++)
        {
            if (triggeringTags[i] == other.tag)
            {
                gameOver = true;
            }
        }
        if (gameOver && enabled) {
            Debug.Log("Game over!");
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }

}
