using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupspawn : MonoBehaviour
{
    //Powerup to spawn:
    public GameObject powerupPerfab;
    private GameObject Powerup;

    void Start()
    {
        SpawnPowerup();
    }

    public void SpawnPowerup()
    {
        if(Powerup == null)
        {
            Powerup = Instantiate(powerupPerfab, transform.position, Quaternion.identity);
        }
    }
}
