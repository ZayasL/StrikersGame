using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class Players : NetworkBehaviour
{
    public bool newSpawn = false;
    public GameObject[] players;
    public Material RED;  //red team color
    public Material BLUE; //blue team color
    public GameObject bluespawn;
    public GameObject redspawn;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (newSpawn)
        {
            bool flip = true;
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                if (flip)
                {
                    player.GetComponent<PlayerMovement>().spawn = bluespawn.transform.position;
                    player.GetComponent<Renderer>().material = BLUE;
                    player.transform.position = bluespawn.transform.position;
                }
                else
                {
                    player.GetComponent<PlayerMovement>().spawn = redspawn.transform.position;
                    player.GetComponent<Renderer>().material = RED;
                    player.transform.position = redspawn.transform.position;
                }
                flip = !flip;
            }
            newSpawn = false;
        }

    }
    public void ResetPlayers()
    {
        foreach (GameObject player in players)
        {
            player.transform.position = player.GetComponent<PlayerMovement>().spawn;
        }
    }
}
