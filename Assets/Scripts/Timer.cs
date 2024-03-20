using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class Timer : NetworkBehaviour
{
    //https://www.youtube.com/watch?v=27uKJvOpdYw
    //Used this tutorial as foundation for my timer
    private float duration = 1f*60f+1;  //timer cycle
    private NetworkVariable<float> timer = new NetworkVariable<float>(0f); //networked time variable
    public TextMeshProUGUI display;  //onscreen timer
    public NetworkVariable<float> power = new NetworkVariable<float>(0f);  //factor to increase attack strength
    private Score board;    //script for changing the score
    private AudioSource sound; //sound to play when timer hits 0
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();  
        board = GetComponent<Score>();
        if (IsServer) { ResetTime(); } 
    }

    // Update is called once per frame
    void Update()
    {
        if (IsServer)
        {
            if (timer.Value > 0f)
            {
                timer.Value -= Time.deltaTime; //decrement the timer
            }
            else
            {
                UpdateTimerDisplay(0f); 
                if (board.GameEnd) //reset the attack power when a player wins
                {
                    
                    power.Value = 0f;
                }
                else { ResetTime(); sound.Play(0); } //reset timer and increase power when timer hits 0
                
            }
        }
        UpdateTimerDisplay(timer.Value);  //update the onscreen timer

    }

    //reset timer and increase power
    private void ResetTime()
    {
        if (IsServer)
        {
            timer.Value = duration;
            power.Value += 1f;
        }
    }

    //turn a float value into minutes and seconds string
    public void UpdateTimerDisplay(float time)
    {
        if (IsServer) { timer.Value = time; }
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        string currentTime = string.Format("{00:00}:{1:00}",minutes,seconds);
        display.text = currentTime;
    }
}
