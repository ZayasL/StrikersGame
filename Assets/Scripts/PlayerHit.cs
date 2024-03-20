using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class PlayerHit : NetworkBehaviour
{
    public GameObject puck;
    private PlayerAim aim;
    private Timer timer;
    private AudioSource[] sound;
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
        if ((puck.transform.position - transform.position).sqrMagnitude < 3.0f)
        {
            if((15f + (2f * timer.power.Value)) >= 25)
            {
                sound[1].Play(0);
            }
            else { sound[0].Play(0); }
            puck.GetComponent<Rigidbody>().velocity = aim.direction * (15f+(2f* timer.power.Value));           
        }
        
    }
}
