using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //the audio for the pickups
    public AudioClip beep;
    //keeps tracks of points of player
    public int boop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if the entity that collided with the pickup was player
        if (collision.gameObject.tag == "Player")
        {
            //rewards player with points
            gamemanager.instance.score += boop;
            //plays coin sound effect
            AudioSource.PlayClipAtPoint(beep, transform.position);
            //Destroy the pickup
            Destroy(this.gameObject);
        }
    }
}
