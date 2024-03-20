using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class Score : NetworkBehaviour
{
    public TextMeshProUGUI leftDisplay; //blue side score
    public TextMeshProUGUI rightDisplay; //red side score
    public TextMeshProUGUI winDisplay;  //player win text
    public bool GameEnd = false;    //boolean to determine if game has been won
    public NetworkVariable<int> left = new NetworkVariable<int>(0);  //networked integer for left scoreboard
    public NetworkVariable<int> right = new NetworkVariable<int>(0); //networked integer for right scoreboard

    private AudioSource[] sound; //sound to be played
    private bool playOnce = true; //boolean to help sound play only once per win
    private float delay = 0f; //float to create a delay before starting a new game
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameEnd) //calculate delay of 5 seconds
        {
            delay = Time.time + 5f;
        }

        //if enough time elapsed restart the game
        if(GameEnd && Time.time >= delay)
        {
            restartRound();
        }

        //left win
        if(left.Value >= 3)
        {
            winDisplay.text = "blue wins!!!!";
            GameEnd = true;
            if (playOnce) {
                sound[1].Play(0);
                playOnce = false;
            }
            
        }
        //right win
        else if (right.Value >= 3)
        {
            winDisplay.text = "red wins!!!!";
            GameEnd = true;
            if (playOnce)
            {
                sound[1].Play(0);
                playOnce = false;
            }
        }
        //hide display when no win
        else
        {
            winDisplay.text = "";
        }
        leftDisplay.text = left.Value.ToString()+"/3";
        rightDisplay.text = right.Value.ToString() + "/3";
    }

    //reset game
    private void restartRound()
    {
        GameEnd = false;
        left.Value = 0;
        right.Value = 0;
        playOnce = true;
    }
}
