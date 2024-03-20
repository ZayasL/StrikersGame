using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class PlayerHit : NetworkBehaviour
{
    public GameObject puck;  //puck ie the yellow ccircle we hit
    private PlayerAim aim;   //script for aiming behavior
    private Timer timer;    //script for time behavior
    private AudioSource[] sound;   //sounds to play
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponents<AudioSource>();
        puck = GameObject.Find("puck");
        timer = GameObject.Find("Canvas").GetComponent<Timer>();
        aim = GetComponent<PlayerAim>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnHit(InputValue value)
    {   
        if ((puck.transform.position - transform.position).sqrMagnitude < 3.0f)   //checks if player is near puck
        {
            if((15f + (2f * timer.power.Value)) >= 25)   //if hit power is higher than 25 play a different sound
            {
                sound[1].Play(0);
            }
            else { sound[0].Play(0); }   //play sound when hitting puck
            puck.GetComponent<Rigidbody>().velocity = aim.direction * (15f+(2f* timer.power.Value));           //sets puck velocity to direction of hit
        }
        
    }
}
