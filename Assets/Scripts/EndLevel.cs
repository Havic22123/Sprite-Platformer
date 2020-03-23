using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if the game object that entered the trigger is our player, then load the next level
        if (collision.gameObject.name == "Player")
        {
            gamemanager.instance.LoadNextScene();
        }
    }
}
