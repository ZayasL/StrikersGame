using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Goal : NetworkBehaviour
{
    public bool BlueSide = false;
    public Canvas canvas;
    private Score board;
    private float delay = 3f;
    private bool NewRound = false;
    private Collider collision;
    private Timer timer;
    private AudioSource[] sound;
    
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponents<AudioSource>();
        timer = canvas.GetComponent<Timer>();
        board = canvas.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!board.GameEnd && Time.time > delay && NewRound) //move puck to center after 3 seconds after scoring
        {
            if (IsServer)
            {
                collision.transform.position = Vector3.zero;
                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * 10 * (Random.Range(0, 2) * 2 - 1);   //sets puck velocity when being teleported back to middle, this is to combat camping the puck spawn
                NewRound = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Puck"&&!board.GameEnd)   //checks for puck collision
        {
            //increase score and play sound
            if(IsServer){
                if (!BlueSide) { board.left.Value += 1; }
                else { board.right.Value += 1; }
            }
            sound[0].Play(0);


            //save collision object and setup variables to delay respawn
            collision = other;
            delay = Time.time + 3f;
            NewRound = true;
            if (IsServer)
            {
                
                timer.UpdateTimerDisplay(4f);
            }

        }
    }
}
